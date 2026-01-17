using Microsoft.EntityFrameworkCore;
using PhoneStoreManagement.Data;
using PhoneStoreManagement.Entity.Entities;
using PhoneStoreManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneStoreManagement.Winforms
{
    public partial class OrderCreateForm : Form
    {
        private readonly IInvoiceService _invoiceSvc;
        private readonly PhoneDbContext _db;
        private readonly IReportService _reportService; // ✅ Thêm Service báo cáo để dùng cho Form chi tiết

        private readonly BindingList<InvoiceItem> _cart = new();

        public OrderCreateForm(IInvoiceService invoiceSvc, PhoneDbContext db, IReportService reportService)
        {
            _invoiceSvc = invoiceSvc;
            _db = db;
            _reportService = reportService; // ✅ Nhận service từ DI

            InitializeComponent();
            ConfigGrid();
            LoadData();

            txtPhone.Leave += txtPhone_Leave;
            cboProduct.SelectedIndexChanged += cboProduct_SelectedIndexChanged;
        }

        // ================= LOAD DỮ LIỆU BAN ĐẦU =================
        private void LoadData()
        {
            try
            {
                txtCustomerName.Clear();
                txtPhone.Clear();
                txtAddress.Clear();

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
                lblTotal.Text = "0 VNĐ";

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

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            try
            {
                string phone = txtPhone.Text.Trim();
                if (string.IsNullOrEmpty(phone)) return;

                if (!Regex.IsMatch(phone, @"^0\d{9}$"))
                {
                    return; // Không hiện Messagebox để tránh phiền người dùng khi đang nhập
                }

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
                MessageBox.Show("Lỗi tra cứu khách hàng: " + ex.Message);
            }
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboProduct.SelectedItem is not Product product) return;
                numQty.Maximum = product.Quantity;
                if (numQty.Value > product.Quantity) numQty.Value = product.Quantity;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ConfigGrid()
        {
            dgvItems.AutoGenerateColumns = false;
            dgvItems.Columns.Clear();
            dgvItems.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Sản phẩm", DataPropertyName = "ProductName", Width = 180 });
            dgvItems.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "SL", DataPropertyName = "Quantity", Width = 60 });
            dgvItems.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Đơn giá", DataPropertyName = "UnitPrice", Width = 110, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvItems.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Thành tiền", DataPropertyName = "LineTotal", Width = 130, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvItems.DataSource = _cart;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboProduct.SelectedItem is not Product product) return;
                int qty = (int)numQty.Value;
                var existed = _cart.FirstOrDefault(x => x.ProductId == product.ProductId);

                if (existed != null)
                {
                    if (existed.Quantity + qty > product.Quantity) { MessageBox.Show("Vượt tồn kho!"); return; }
                    existed.Quantity += qty;
                    existed.LineTotal = existed.Quantity * existed.UnitPrice;
                }
                else
                {
                    _cart.Add(new InvoiceItem { ProductId = product.ProductId, ProductName = product.ProductName, Quantity = qty, UnitPrice = product.SalePrice, LineTotal = qty * product.SalePrice });
                }
                ReloadGrid();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvItems.CurrentRow?.DataBoundItem is not InvoiceItem item) return;
            _cart.Remove(item);
            ReloadGrid();
        }

        // ================= XÁC NHẬN TẠO ĐƠN & XỬ LÝ HÓA ĐƠN =================
        private async void btnCreateOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Nhập đầy đủ thông tin khách hàng!");
                return;
            }

            if (cboEmployee.SelectedValue == null || _cart.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên và sản phẩm!");
                return;
            }

            try
            {
                btnCreateOrder.Enabled = false;

                // ✅ Giả định CreateOrderAsync trả về ID của hóa đơn mới tạo (int)
                int newInvoiceId = await _invoiceSvc.CreateOrderAsync(
                    txtCustomerName.Text.Trim(),
                    txtPhone.Text.Trim(),
                    txtAddress.Text.Trim(),
                    (int)cboEmployee.SelectedValue,
                    _cart.Select(x => (x.ProductId, x.Quantity)).ToList()
                );

                // ✅ Hiển thị thông báo với lựa chọn Xuất hóa đơn
                var result = MessageBox.Show("Tạo đơn hàng thành công! Bạn có muốn XUẤT HÓA ĐƠN không?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // ✅ Mở form chi tiết để người dùng nhấn nút Xuất Excel/In
                    using var frm = new InvoiceDetailForm(newInvoiceId, _reportService);
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
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

        private void ReloadGrid()
        {
            dgvItems.ResetBindings();
            lblTotal.Text = _cart.Sum(x => x.LineTotal).ToString("N0") + " VNĐ";
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
    }
}