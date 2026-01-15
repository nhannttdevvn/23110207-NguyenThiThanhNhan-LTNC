using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace PhoneStoreManagement.Data.Repository;

public class RepositoryBase<T> : IRepository<T> where T : class
{
    protected readonly PhoneDbContext Db;
    protected readonly DbSet<T> Set;

    public RepositoryBase(PhoneDbContext db)
    {
        Db = db;
        Set = db.Set<T>();
    }

    public Task<T?> GetByIdAsync(int id, CancellationToken ct = default) => Set.FindAsync([id], ct).AsTask();

    public Task<List<T>> GetAllAsync(CancellationToken ct = default) => Set.AsNoTracking().ToListAsync(ct);

    public Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default)
        => Set.AsNoTracking().Where(predicate).ToListAsync(ct);

    public Task AddAsync(T entity, CancellationToken ct = default) => Set.AddAsync(entity, ct).AsTask();

    public void Update(T entity) => Set.Update(entity);

    public void Remove(T entity) => Set.Remove(entity);

    public IQueryable<T> Query() => Set.AsQueryable();
}
