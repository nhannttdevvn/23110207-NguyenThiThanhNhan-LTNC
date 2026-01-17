using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PhoneStoreManagement.Data;
using PhoneStoreManagement.Entity.Entities;
using PhoneStoreManagement.Services.Interfaces;

namespace PhoneStoreManagement.Services.Implementations;

public class ProductService : IProductService
{
    private readonly PhoneDbContext _db;

    public ProductService(PhoneDbContext db)
    {
        _db = db;
    }

    private async Task<string> GenerateCodeAsync(CancellationToken ct) // hàm sinh mã chuẩn
    {
        var lastCode = await _db.Products
            .OrderByDescending(x => x.ProductId) // sắp xếp giảm dần theo ProductId để lấy mã mới nhất
            .Select(x => x.ProductCode) // chỉ lấy cột ProductCode
            .FirstOrDefaultAsync(ct); // lấy mã đầu tiên trong danh sách đã sắp xếp

        if (string.IsNullOrEmpty(lastCode))
            return "P000001";  // nếu chưa có thì trả về mã đầu tiên

        var number = int.Parse(lastCode.Substring(1));
        return $"P{(number + 1):D6}";
    }

    public async Task<int> CreateAsync(Product p, CancellationToken ct = default) // hàm tạo sản phẩm mới
    {
        p.ProductCode = await GenerateCodeAsync(ct); // gán mã tự động sinh cho sản phẩm mới

        _db.Products.Add(p); 
        await _db.SaveChangesAsync(ct);
        return p.ProductId;
    }

    public Task<Product?> GetAsync(int id, CancellationToken ct = default) // hàm lấy sp theo ID
        => _db.Products.FindAsync(new object[] { id }, ct).AsTask(); // trả về sp hoặc null 

    public Task<Product?> GetByCodeAsync(string code, CancellationToken ct = default) 
        => _db.Products.FirstOrDefaultAsync(x => x.ProductCode == code, ct);

    public async Task<List<Product>> SearchAsync(string keyword, CancellationToken ct = default)
    {
        // Đảm bảo từ khóa không bị null để tránh lỗi khi so sánh
        keyword ??= "";

        return await _db.Products
            .Include(x => x.Supplier)      // Kết hợp (JOIN) với bảng Nhà cung cấp để lấy thông tin liên quan
            .AsNoTracking()               // Tối ưu hiệu năng: Chỉ đọc dữ liệu, không theo dõi thay đổi
            .Where(x => x.ProductName.Contains(keyword)) // Lọc sản phẩm theo tên
            .ToListAsync(ct);             // Thực thi truy vấn bất đồng bộ và trả về danh sách kết quả
    }

    public async Task UpdateAsync(Product p, CancellationToken ct = default)
    {
        var tracked = _db.ChangeTracker 
            .Entries<Product>() 
            .FirstOrDefault(e => e.Entity.ProductId == p.ProductId);

        if (tracked != null)
            tracked.State = EntityState.Detached;

        _db.Products.Attach(p);
        _db.Entry(p).State = EntityState.Modified;


        await _db.SaveChangesAsync(ct);
    }


    public async Task DeleteAsync(int id, CancellationToken ct = default)
    {
        var p = await _db.Products.FindAsync(new object[] { id }, ct); // tìm sản phẩm theo ID
        if (p == null) return; // nếu không tìm thấy thì thoát

        _db.Products.Remove(p); // xóa sản phẩm khỏi DbSet
        await _db.SaveChangesAsync(ct);
    }

    //hàm kiểm tra tên sp đã tồn tại
    public async Task<bool> ExistsProductName(string productName, int excludeId = 0, CancellationToken ct = default) 
    {
        return await _db.Products.AnyAsync(x =>
            x.ProductName.ToLower() == productName.ToLower().Trim() // so sánh tên sản phẩm không phân biệt hoa thường
            && x.ProductId != excludeId, ct);
    }
}
