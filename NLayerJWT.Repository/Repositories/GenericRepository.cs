using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NLayerJWT.Core.Repositories;

namespace NLayerJWT.Repository.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{

    private readonly DbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity != null)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        return entity;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.Where(predicate);
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Remove(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public TEntity Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        return entity;
    }
}