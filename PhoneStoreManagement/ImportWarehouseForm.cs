using Microsoft.EntityFrameworkCore;
using PhoneStoreManagement.Data;
using PhoneStoreManagement.Entity.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PhoneStoreManagement.Winforms;

public partial class ImportWarehouseForm : Form
{
    private readonly PhoneDbContext _db;

    public Product? SelectedProduct { get; private set; }
    public int ImportQuantity { get; private set; }

    public ImportWarehouseForm(PhoneDbContext db)
    {
        _db = db;
        InitializeComponent();
        LoadProducts();
    }

    private void LoadProducts()
    {
        var products = _db.Products
            .Where(p => p.Quantity >= 0)   // có trong kho
            .AsNoTracking()
            .ToList();

        if (products.Count == 0)
        {
            MessageBox.Show("Không có sản phẩm trong kho");
            return;
        }

        cboProduct.DataSource = products;
        cboProduct.DisplayMember = "ProductName";
        cboProduct.ValueMember = "ProductId";
        cboProduct.SelectedIndex = -1;
    }

    private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboProduct.SelectedItem is Product p)
        {
            txtProductCode.Text = p.ProductCode;
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (cboProduct.SelectedItem is not Product p)
        {
            MessageBox.Show("Vui lòng chọn sản phẩm");
            return;
        }

        if (numQuantity.Value <= 0)
        {
            MessageBox.Show("Số lượng phải lớn hơn 0");
            return;
        }

        SelectedProduct = p;
        ImportQuantity = (int)numQuantity.Value;

        DialogResult = DialogResult.OK;
        Close();
    }
}
