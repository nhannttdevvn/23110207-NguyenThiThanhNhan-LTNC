using Microsoft.EntityFrameworkCore;
using PhoneStoreManagement.Data.Security;
using PhoneStoreManagement.Domain.Entities;
using PhoneStoreManagement.Entity.Entities;
using System.Configuration;

namespace PhoneStoreManagement.Data
{
    public class PhoneDbContext : DbContext
    {
        public PhoneDbContext() { }

        public PhoneDbContext(DbContextOptions<PhoneDbContext> options)
            : base(options) { }

        // ===== DbSet =====
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        public DbSet<Warranty> Warranties { get; set; }

        // Admin riêng – KHÔNG LIÊN QUAN AppUser
        public DbSet<AppAdminAccount> AppAdminAccounts { get; set; }

        // User hệ thống (nhân viên)
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }

        // ===== DB CONNECTION =====
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var cs = ConfigurationManager
                    .ConnectionStrings["PhoneDb"]
                    .ConnectionString;

                optionsBuilder.UseSqlServer(cs);
            }
        }

        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);

            // ================= INVOICE =================
            b.Entity<Invoice>(e =>
            {
                e.HasKey(x => x.InvoiceId);

                e.Property(x => x.TotalAmount)
                    .HasPrecision(18, 2);

                e.HasOne(x => x.Supplier)
                    .WithMany(s => s.Invoices)
                    .HasForeignKey(x => x.SupplierId)
                    .OnDelete(DeleteBehavior.Restrict); // 🚫 CASCADE

                e.HasOne(x => x.Customer)
                    .WithMany(c => c.Invoices)
                    .HasForeignKey(x => x.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict); // 🚫 CASCADE
            });

            // ================= INVOICE ITEM =================
            b.Entity<InvoiceItem>(e =>
            {
                e.HasKey(x => x.InvoiceItemId);

                e.Property(x => x.UnitPrice)
                    .HasPrecision(18, 2);

                e.Property(x => x.LineTotal)
                    .HasPrecision(18, 2);

                e.HasOne(x => x.Invoice)
                    .WithMany(i => i.InvoiceItems)
                    .HasForeignKey(x => x.InvoiceId)
                    .OnDelete(DeleteBehavior.Cascade); // ✅ OK

                e.HasOne(x => x.Product)
                    .WithMany(p => p.InvoiceItems)
                    .HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.Restrict); // 🚨 FIX CASCADE PATH
            });

            // ================= PRODUCT =================
            b.Entity<Product>(e =>
            {
                e.Property(x => x.ProductName).HasMaxLength(200);
                e.Property(x => x.Brand).HasMaxLength(100);
                e.Property(x => x.Variant).HasMaxLength(100);
                e.Property(x => x.Origin).HasMaxLength(50);

                e.Property(x => x.PurchasePrice).HasPrecision(18, 0);
                e.Property(x => x.SalePrice).HasPrecision(18, 0);
            });

            // mapping quan hệ Product và Supplier
            b.Entity<Product>(e =>
            {
                e.HasOne(x => x.Supplier)
                 .WithMany(s => s.Products)
                 .HasForeignKey(x => x.SupplierId)
                 .OnDelete(DeleteBehavior.Restrict);
            });


            // ================= APP ROLE =================
            b.Entity<AppRole>(e =>
            {
                e.ToTable("AppRoles");
                e.HasKey(x => x.AppRoleId);

                e.Property(x => x.RoleName)
                    .HasMaxLength(100)
                    .IsRequired();

                e.HasData(
                    new AppRole { AppRoleId = 1, RoleName = "Admin" },
                    new AppRole { AppRoleId = 2, RoleName = "Staff" }
                );
            });

            // ================= APP USER =================
            b.Entity<AppUser>(e =>
            {
                e.HasKey(x => x.AppUserId);

                e.HasOne(x => x.AppRole)
                    .WithMany()
                    .HasForeignKey(x => x.AppRoleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });

            // ================= ADMIN ACCOUNT (RIÊNG) =================
            b.Entity<AppAdminAccount>(e =>
            {
                e.ToTable("AppAdminAccounts");

                e.HasKey(x => x.AdminId);

                e.Property(x => x.Username)
                    .HasMaxLength(50)
                    .IsRequired();

                e.Property(x => x.PasswordHash)
                    .HasMaxLength(256)
                    .IsRequired();

                e.Property(x => x.IsActive)
                    .HasDefaultValue(true);
                // SEED DATA
                e.HasData(new AppAdminAccount
                {
                    AdminId = 1,
                    Username = "admin",
                    PasswordHash = PasswordHasher.Hash("123"),
                    IsActive = true,
                    CreatedDate = DateTime.Now
                });
            });

        }
    }
}
