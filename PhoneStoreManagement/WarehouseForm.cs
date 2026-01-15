using ClosedXML.Excel;
using PhoneStoreManagement.Data;
using PhoneStoreManagement.Entity.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PhoneStoreManagement.Winforms;

public partial class WarehouseForm : Form
{
    private readonly PhoneDbContext _db;

    public WarehouseForm(PhoneDbContext db)
    {
        _db = db;
        InitializeComponent();
        ConfigGrid();
        LoadData();
    }

    // ================= GRID =================
    private void ConfigGrid()
    {
        dgvWarehouse.AutoGenerateColumns = false;
        dgvWarehouse.Columns.Clear();

        dgvWarehouse.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "ProductCode",
            HeaderText = "Mã SP",
            Width = 100
        });

        dgvWarehouse.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "ProductName",
            HeaderText = "Tên sản phẩm",
            Width = 250
        });

        dgvWarehouse.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Quantity",
            HeaderText = "Tồn kho",
            Width = 100
        });

        dgvWarehouse.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "CreatedDate",
            HeaderText = "Ngày nhập",
            Width = 140,
            DefaultCellStyle = new DataGridViewCellStyle
            {
                Format = "dd/MM/yyyy"
            }
        });

        dgvWarehouse.ReadOnly = true;
        dgvWarehouse.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvWarehouse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    // ================= LOAD =================
    private void LoadData()
    {
        dgvWarehouse.DataSource = null;
        dgvWarehouse.DataSource = _db.Products
            .OrderBy(p => p.ProductName)
            .ToList();
    }

    // ================= IMPORT (NHẬP KHO) =================
    private void btnImport_Click(object sender, EventArgs e)
    {
        using var f = new ImportWarehouseForm(_db);

        if (f.ShowDialog() != DialogResult.OK) return;

        if (f.SelectedProduct == null)
        {
            MessageBox.Show("Không có sản phẩm được chọn");
            return;
        }

        // 🔥 LOAD LẠI PRODUCT ĐƯỢC TRACK
        var product = _db.Products
            .FirstOrDefault(x => x.ProductId == f.SelectedProduct.ProductId);

        if (product == null)
        {
            MessageBox.Show("Sản phẩm không tồn tại");
            return;
        }

        product.Quantity += f.ImportQuantity;
        product.CreatedDate = DateTime.Now;

        _db.SaveChanges();
        LoadData();

        MessageBox.Show(
            $"Nhập kho thành công:\n{product.ProductName} (+{f.ImportQuantity})",
            "Thành công",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        );
    }

    // ================= EXPORT EXCEL =================
    private void btnExportExcel_Click(object sender, EventArgs e)
    {
        using SaveFileDialog sfd = new()
        {
            Filter = "Excel (*.xlsx)|*.xlsx",
            FileName = "Warehouse.xlsx"
        };

        if (sfd.ShowDialog() != DialogResult.OK) return;

        using var wb = new XLWorkbook();
        var ws = wb.Worksheets.Add("Kho hàng");

        ws.Cell(1, 1).Value = "Mã SP";
        ws.Cell(1, 2).Value = "Tên sản phẩm";
        ws.Cell(1, 3).Value = "Tồn kho";
        ws.Cell(1, 4).Value = "Ngày nhập";

        int row = 2;
        foreach (var p in _db.Products.OrderBy(x => x.ProductName))
        {
            ws.Cell(row, 1).Value = p.ProductCode;
            ws.Cell(row, 2).Value = p.ProductName;
            ws.Cell(row, 3).Value = p.Quantity;
            ws.Cell(row, 4).Value = p.CreatedDate;
            row++;
        }

        ws.Columns().AdjustToContents();
        wb.SaveAs(sfd.FileName);

        MessageBox.Show("Xuất Excel thành công");
    }
}
