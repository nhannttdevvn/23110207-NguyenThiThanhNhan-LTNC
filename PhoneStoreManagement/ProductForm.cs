using PhoneStoreManagement.Entity.Entities;
using PhoneStoreManagement.Services.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneStoreManagement.Winforms;

public partial class ProductForm : Form
{
    private readonly IProductService _productService;
    private readonly ISupplierService _supplierService; 
    private CancellationTokenSource _cts = new();

    public ProductForm(IProductService productService, ISupplierService supplierService)
    {
        _productService = productService;
        InitializeComponent();
        //ConfigureNumeric();
        ConfigureGrid();
        _supplierService = supplierService;
    }

    // ================= FORM LOAD =================
    private async void ProductForm_Load(object sender, EventArgs e)
    {
        LoadCombos();
        await LoadSupplierAsync();
        await LoadDataAsync();
        
    }

    private async Task LoadSupplierAsync()
    {
        cboSupplier.DataSource = await _supplierService.GetAllAsync();
        cboSupplier.DisplayMember = "SupplierName";
        cboSupplier.ValueMember = "SupplierId";
        cboSupplier.SelectedIndex = -1;
    }


    //// ================= CONFIG =================
    //private void ConfigureNumeric()
    //{
    //    numStock.Maximum = 100_000;
    //}

    // ================= DATA =================
    private async Task LoadDataAsync(string keyword = "")
    {
        var products = await _productService.SearchAsync(keyword, _cts.Token);

        dgvProducts.DataSource = products;

        foreach (DataGridViewRow row in dgvProducts.Rows)
        {
            if (row.DataBoundItem is Product p)
            {
                row.Cells["SupplierName"].Value = p.Supplier?.SupplierName;
            }
        }
    }

    private void ConfigureGrid()
    {
        dgvProducts.AutoGenerateColumns = false;
        dgvProducts.Columns.Clear();

        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "ProductCode",
            HeaderText = "Mã SP",
            Width = 90
        });

        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "ProductName",
            HeaderText = "Tên sản phẩm"
        });

        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Brand",
            HeaderText = "Hãng"
        });

        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Variant",
            HeaderText = "Phiên bản"
        });

        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Origin",
            HeaderText = "Xuất xứ"
        });

        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "SalePrice",
            HeaderText = "Giá bán",
            DefaultCellStyle = { Format = "N0" }
        });

        
        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "SupplierName",
            HeaderText = "Nhà cung cấp"
        });
    }

    // ================= COMBO =================
    private void LoadCombos()
    {
        cboBrand.Items.AddRange(new object[]
        {
            "Apple", "Samsung", "Xiaomi", "Oppo"
        });

        cboVariant.Items.AddRange(new object[]
        {
            "Xanh 128GB", "Xanh 256GB",
            "Titan 128GB", "Titan 256GB",
            "Hồng 128GB", "Hồng 256GB",
            "Vàng 128GB", "Vàng 256GB"
        });

        cboOrigin.Items.AddRange(new object[]
        {
            "Việt Nam", "Trung Quốc", "Nhật Bản", "Đức"
        });
    }

  

    // ================= VALIDATE =================
    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtName.Text)) return false;
        if (cboBrand.SelectedIndex < 0) return false;
        if (cboVariant.SelectedIndex < 0) return false;
        if (cboOrigin.SelectedIndex < 0) return false;
        //if (!decimal.TryParse(txtPurchase.Text.Replace(",", ""), out var purchase) || purchase <= 0)
        //    return false;

        if (!decimal.TryParse(txtSale.Text.Replace(",", ""), out var sale) || sale <= 0)
            return false;

        return true;
    }

    // ================= EVENTS =================
    private async void btnSearch_Click(object sender, EventArgs e)
        => await LoadDataAsync(txtSearch.Text.Trim());

    private async void btnAdd_Click(object sender, EventArgs e)
    {
        if (!ValidateInput()) return;

        var p = new Product
        {
            ProductName = txtName.Text.Trim(),
            Brand = cboBrand.Text,
            Variant = cboVariant.Text,
            Origin = cboOrigin.Text,
            //PurchasePrice = decimal.Parse(txtPurchase.Text.Replace(",", ",")),
            SalePrice = decimal.Parse(txtSale.Text.Replace(",", ",")),
            //Quantity = (int)numStock.Value,
            SupplierId = (int?)cboSupplier.SelectedValue ?? 0

        };
        

        await _productService.CreateAsync(p);
        await LoadDataAsync();
    }

    private async void btnUpdate_Click(object sender, EventArgs e)
    {
        if (dgvProducts.CurrentRow?.DataBoundItem is not Product p) return;
        if (!ValidateInput()) return;

        p.ProductName = txtName.Text.Trim();
        p.Brand = cboBrand.Text;
        p.Variant = cboVariant.Text;
        p.Origin = cboOrigin.Text;
        //p.PurchasePrice = decimal.Parse(txtPurchase.Text.Replace(",", ","));
        p.SalePrice = decimal.Parse(txtSale.Text.Replace(",", ","));
        //p.Quantity = (int)numStock.Value;
        p.SupplierId = (int?)cboSupplier.SelectedValue ?? 0;

        p.Supplier = null;

        await _productService.UpdateAsync(p);
        await LoadDataAsync();
    }

    private async void btnDelete_Click(object sender, EventArgs e)
    {
        if (dgvProducts.CurrentRow?.DataBoundItem is not Product p) return;

        if (MessageBox.Show("Xóa sản phẩm này?", "Xác nhận",
            MessageBoxButtons.YesNo) != DialogResult.Yes)
            return;

        await _productService.DeleteAsync(p.ProductId);
        await LoadDataAsync();
    }

    private void dgvProducts_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvProducts.CurrentRow?.DataBoundItem is not Product p) return;

        txtCode.Text = p.ProductCode;
        txtName.Text = p.ProductName;
        cboBrand.Text = p.Brand;
        cboVariant.Text = p.Variant;
        cboOrigin.Text = p.Origin;
        //txtPurchase.Text = p.PurchasePrice.ToString("N0");
        txtSale.Text = p.SalePrice.ToString("N0");
        

        if (p.SupplierId > 0)
            cboSupplier.SelectedValue = p.SupplierId;
        else
            cboSupplier.SelectedIndex = -1;

        //       MessageBox.Show(
        //    p.Supplier == null ? "Supplier NULL" : p.Supplier.SupplierName
        //);

    }
}
