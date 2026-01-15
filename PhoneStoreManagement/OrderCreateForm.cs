// ===== OrderCreateForm.cs (FULL – đã thêm try-catch) =====
using Microsoft.EntityFrameworkCore;
using PhoneStoreManagement.Data;
using PhoneStoreManagement.Entity.Entities;
using PhoneStoreManagement.Services.Interfaces;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace PhoneStoreManagement.Winforms
{
    public partial class OrderCreateForm : Form
    {
        private readonly IInvoiceService _invoiceSvc;
        private readonly PhoneDbContext _db;

        private readonly BindingList<InvoiceItem> _cart = new();

        public OrderCreateForm(IInvoiceService invoiceSvc, PhoneDbContext db)
        {
            _invoiceSvc = invoiceSvc;
            _db = db;

            InitializeComponent();
            ConfigGrid();
            LoadData();

            txtPhone.Leave += txtPhone_Leave;
            cboProduct.SelectedIndexChanged += cboProduct_SelectedIndexChanged;
        }

        // ================= LOAD =================
        private void LoadData()
        {
            try
            {
                txtCustomerName.Clear();
                txtPhone.Clear();
                txtAddress.Clear();

                // ✅ LOAD NHÂN VIÊN
                cboEmployee.DataSource = _db.AppUsers
                    .AsNoTracking()
                    .Where(x => x.AppRoleId == 2)
                    .OrderBy(x => x.EmployeeCode)
                    .ToList();
                cboEmployee.DisplayMember = "EmployeeCode";
                cboEmployee.ValueMember = "AppUserId";
                cboEmployee.SelectedIndex = -1;

                LoadProducts();

                numQty.Value = 1;

                lblOrderNo.Text = $"HD{DateTime.Now:yyyyMMddHHmmss}";
                lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                lblTotal.Text = "0";

                _cart.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu ban đầu: " + ex.Message);
            }
        }

        private void LoadProducts()
        {
            try
            {
                var products = _db.Products
                    .AsNoTracking()
                    .Where(p => p.Quantity > 0)
                    .OrderBy(p => p.ProductName)
                    .ToList();

                cboProduct.DataSource = products;
                cboProduct.DisplayMember = "ProductName";
                cboProduct.ValueMember = "ProductId";
                cboProduct.SelectedIndex = -1;

                btnAdd.Enabled = products.Any();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục sản phẩm: " + ex.Message);
            }
        }

        // ================= PHONE CHECK =================
        private void txtPhone_Leave(object sender, EventArgs e)
        {
            try
            {
                var phone = txtPhone.Text.Trim();
                if (string.IsNullOrEmpty(phone)) return;

                var customer = _db.Customers
                    .AsNoTracking()
                    .FirstOrDefault(x => x.Phone == phone);

                if (customer != null)
                {
                    txtCustomerName.Text = customer.FullName;
                    txtAddress.Text = customer.Address;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tra cứu thông tin khách hàng: " + ex.Message);
            }
        }

        // ================= PRODUCT CHANGE =================
        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboProduct.SelectedItem is not Product product) return;

                numQty.Maximum = product.Quantity;
                if (numQty.Value > product.Quantity)
                    numQty.Value = product.Quantity;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xử lý chọn sản phẩm: " + ex.Message);
            }
        }

        // ================= GRID =================
        private void ConfigGrid()
        {
            dgvItems.AutoGenerateColumns = false;
            dgvItems.Columns.Clear();

            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Sản phẩm",
                DataPropertyName = "ProductName",
                Width = 180
            });

            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "SL",
                DataPropertyName = "Quantity",
                Width = 60
            });

            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Đơn giá",
                DataPropertyName = "UnitPrice",
                Width = 90
            });

            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Thành tiền",
                DataPropertyName = "LineTotal",
                Width = 100
            });

            dgvItems.DataSource = _cart;
        }

        // ================= ADD =================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboProduct.SelectedItem is not Product product)
                {
                    MessageBox.Show("Chưa chọn sản phẩm");
                    return;
                }

                int qty = (int)numQty.Value;

                if (qty <= 0 || qty > product.Quantity)
                {
                    MessageBox.Show("Số lượng không hợp lệ hoặc vượt tồn kho");
                    return;
                }

                var existed = _cart.FirstOrDefault(x => x.ProductId == product.ProductId);

                if (existed != null)
                {
                    if (existed.Quantity + qty > product.Quantity)
                    {
                        MessageBox.Show("Tổng số lượng trong giỏ hàng vượt tồn kho");
                        return;
                    }

                    existed.Quantity += qty;
                    existed.LineTotal = existed.Quantity * existed.UnitPrice;
                }
                else
                {
                    _cart.Add(new InvoiceItem
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        Quantity = qty,
                        UnitPrice = product.SalePrice,
                        LineTotal = qty * product.SalePrice
                    });
                }

                ReloadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm vào giỏ hàng: " + ex.Message);
            }
        }

        // ================= REMOVE =================
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvItems.CurrentRow?.DataBoundItem is not InvoiceItem item) return;

                _cart.Remove(item);
                ReloadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message);
            }
        }

        // ================= CREATE ORDER =================
        private async void btnCreateOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text)
                || string.IsNullOrWhiteSpace(txtPhone.Text)
                || string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Nhập đầy đủ thông tin khách hàng");
                return;
            }

            if (cboEmployee.SelectedItem == null)
            {
                MessageBox.Show("Chọn nhân viên");
                return;
            }

            if (_cart.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm");
                return;
            }

            try
            {
                btnCreateOrder.Enabled = false;
                await _invoiceSvc.CreateOrderAsync(
                    txtCustomerName.Text.Trim(),
                    txtPhone.Text.Trim(),
                    txtAddress.Text.Trim(),
                    (int)cboEmployee.SelectedValue,
                    _cart.Select(x => (x.ProductId, x.Quantity)).ToList()
                );

                MessageBox.Show("Tạo đơn hàng thành công");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message, "Lỗi tạo đơn");
            }
            finally
            {
                btnCreateOrder.Enabled = true;
            }
        }

        // ================= UI =================
        private void ReloadGrid()
        {
            try
            {
                dgvItems.Refresh();
                lblTotal.Text = _cart.Sum(x => x.LineTotal).ToString("N0");
            }
            catch
            {
                // UI update silent fail
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}