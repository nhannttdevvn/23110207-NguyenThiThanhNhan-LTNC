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
        _supplierService = supplierService;
        InitializeComponent();
        ConfigureGrid();
    }

    // ================= FORM LOAD =================
    private async void ProductForm_Load(object sender, EventArgs e)
    {
        try
        {
            LoadCombos();
            await LoadSupplierAsync();
            await LoadDataAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khởi tạo form: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async Task LoadSupplierAsync()
    {
        try
        {
            cboSupplier.DataSource = await _supplierService.GetAllAsync();
            cboSupplier.DisplayMember = "SupplierName";
            cboSupplier.ValueMember = "SupplierId";
            cboSupplier.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi tải danh sách nhà cung cấp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // ================= DATA =================
    private async Task LoadDataAsync(string keyword = "")
    {
        try
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
            ClearInputs();
        }
        catch (OperationCanceledException) { /* Bỏ qua khi cancel task */ }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi hiển thị danh sách sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ConfigureGrid()
    {
        try
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
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi cấu hình bảng: {ex.Message}");
        }
    }

    // ================= COMBO =================
    private void LoadCombos()
    {
        try
        {
            cboBrand.Items.Clear();
            cboBrand.Items.AddRange(new object[] { "Apple", "Samsung", "Xiaomi", "Oppo" });

            cboVariant.Items.Clear();
            cboVariant.Items.AddRange(new object[]
            {
                "Xanh 128GB", "Xanh 256GB", "Titan 128GB", "Titan 256GB",
                "Hồng 128GB", "Hồng 256GB", "Vàng 128GB", "Vàng 256GB"
            });

            cboOrigin.Items.Clear();
            cboOrigin.Items.AddRange(new object[] { "Việt Nam", "Trung Quốc", "Nhật Bản", "Đức" });
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi tải danh mục: {ex.Message}");
        }
    }

    private void ClearInputs()
    {
        try
        {
            txtCode.Clear();
            txtName.Clear();
            cboBrand.SelectedIndex = -1;
            cboVariant.SelectedIndex = -1;
            cboOrigin.SelectedIndex = -1;
            txtSale.Clear();
            cboSupplier.SelectedIndex = -1;

            dgvProducts.ClearSelection();
            if (dgvProducts.CurrentCell != null) dgvProducts.CurrentCell = null;
        }
        catch { /* Bỏ qua lỗi giao diện nhỏ */ }
    }

    // ================= VALIDATE =================
    private async Task<bool> ValidateInput()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống!");
                return false;
            }

            if (cboBrand.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn hãng!");
                return false;
            }

            int currentId = 0;
            if (dgvProducts.CurrentRow?.DataBoundItem is Product p)
            {
                currentId = p.ProductId;
            }

            bool isDuplicate = await _productService.ExistsProductName(txtName.Text.Trim(), currentId);
            if (isDuplicate)
            {
                MessageBox.Show("Tên sản phẩm này đã tồn tại!");
                return false;
            }

            if (!decimal.TryParse(txtSale.Text.Replace(",", ""), out var sale) || sale <= 0)
            {
                MessageBox.Show("Giá bán không hợp lệ!");
                return false;
            }

            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi kiểm tra dữ liệu: {ex.Message}");
            return false;
        }
    }

    // ================= EVENTS =================
    private async void btnSearch_Click(object sender, EventArgs e)
    {
        await LoadDataAsync(txtSearch.Text.Trim());
    }

    private async void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (!await ValidateInput()) return;

            var p = new Product
            {
                ProductName = txtName.Text.Trim(),
                Brand = cboBrand.Text,
                Variant = cboVariant.Text,
                Origin = cboOrigin.Text,
                SalePrice = decimal.Parse(txtSale.Text.Replace(",", "")),
                SupplierId = (int?)cboSupplier.SelectedValue ?? 0
            };

            await _productService.CreateAsync(p);
            MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo");
            await LoadDataAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi thêm sản phẩm: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (dgvProducts.CurrentRow?.DataBoundItem is not Product p)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần cập nhật!");
                return;
            }
            if (!await ValidateInput()) return;

            p.ProductName = txtName.Text.Trim();
            p.Brand = cboBrand.Text;
            p.Variant = cboVariant.Text;
            p.Origin = cboOrigin.Text;
            p.SalePrice = decimal.Parse(txtSale.Text.Replace(",", ""));
            p.SupplierId = (int?)cboSupplier.SelectedValue ?? 0;
            p.Supplier = null;

            await _productService.UpdateAsync(p);
            MessageBox.Show("Cập nhật thành công!", "Thông báo");
            await LoadDataAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            if (dgvProducts.CurrentRow?.DataBoundItem is not Product p) return;

            if (MessageBox.Show("Xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            await _productService.DeleteAsync(p.ProductId);
            MessageBox.Show("Xóa thành công!", "Thông báo");
            await LoadDataAsync();
        }
        catch (Exception ex)
        {
            if (ex.InnerException?.Message.Contains("REFERENCE constraint") == true || ex.Message.Contains("REFERENCE constraint"))
            {
                MessageBox.Show("Không thể xóa sản phẩm này vì đã có dữ liệu hóa đơn/nhập kho liên quan!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
        ClearInputs();
    }

    private void dgvProducts_SelectionChanged(object sender, EventArgs e)
    {
        try
        {
            if (dgvProducts.CurrentRow == null || !dgvProducts.CurrentRow.Selected) return;
            if (dgvProducts.CurrentRow?.DataBoundItem is not Product p) return;

            txtCode.Text = p.ProductCode;
            txtName.Text = p.ProductName;
            cboBrand.Text = p.Brand;
            cboVariant.Text = p.Variant;
            cboOrigin.Text = p.Origin;
            txtSale.Text = p.SalePrice.ToString("N0");

            if (p.SupplierId > 0)
                cboSupplier.SelectedValue = p.SupplierId;
            else
                cboSupplier.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            // Tránh hiện thông báo lỗi liên tục khi người dùng click nhanh qua các dòng
            Console.WriteLine($"Selection Error: {ex.Message}");
        }
    }
}