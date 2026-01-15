using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhoneStoreManagement.Data;
using PhoneStoreManagement.Services.Implementations;
using PhoneStoreManagement.Services.Interfaces;
using PhoneStoreManagement.Winforms;
using PhoneStoreManagement.Data.Repository;
using System.Configuration;

namespace PhoneStoreManagement.Winforms;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var services = new ServiceCollection();

        // ===== DB (FIX QUAN TRỌNG) =====
        services.AddDbContext<PhoneDbContext>(options =>
        {
            options.UseSqlServer(
                ConfigurationManager.ConnectionStrings["PhoneDb"].ConnectionString
            );
        });

        // ===== SERVICES =====
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ISupplierService, SupplierService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IInvoiceService, InvoiceService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IReportService, ReportService>();
        services.AddScoped<IWarrantyService, WarrantyService>();

        // ===== REPOSITORY + UOW =====
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IInvoiceRepository, InvoiceRepository>();
        services.AddScoped<IWarrantyRepository, WarrantyRepository>();

        // ===== FORMS =====
        services.AddScoped<LoginForm>();
        services.AddScoped<MenuForm>();
        services.AddScoped<ProductForm>();
        services.AddScoped<SupplierForm>();
        services.AddScoped<EmployeeForm>();
        services.AddScoped<WarehouseForm>();
        services.AddScoped<OrderCreateForm>();
        services.AddScoped<StatisticForm>();
        services.AddScoped<WarrantyForm>();

        var sp = services.BuildServiceProvider();

        using var login = sp.GetRequiredService<LoginForm>();
        if (login.ShowDialog() != DialogResult.OK) return;

        Application.Run(new MenuForm(sp, login.LoggedUser!));
    }
} 