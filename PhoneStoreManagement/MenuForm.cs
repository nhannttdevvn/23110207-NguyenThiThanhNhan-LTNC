using Microsoft.Extensions.DependencyInjection;
using PhoneStoreManagement.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace PhoneStoreManagement.Winforms;

public partial class MenuForm : Form
{
    private readonly IServiceProvider _sp;
    private readonly AdminAuthResult _user;

    public MenuForm(IServiceProvider sp,AdminAuthResult user)
    {
        _sp = sp;
        _user = user;
        InitializeComponent();
        Text = $"Menu - {_user.Username})";
    }

    private void Open<T>() where T : Form
    {
        var f = _sp.GetRequiredService<T>();
        f.ShowDialog();
    }

    private void btnProduct_Click(object s, EventArgs e) => Open<ProductForm>();
    private void btnSupplier_Click(object s, EventArgs e) => Open<SupplierForm>();
    private void btnEmployee_Click(object s, EventArgs e) => Open<EmployeeForm>();
    private void btnWarehouse_Click(object s, EventArgs e) => Open<WarehouseForm>();
    private void btnOrder_Click(object s, EventArgs e) => Open<OrderCreateForm>();
    private void btnStat_Click(object s, EventArgs e) => Open<StatisticForm>();
}
