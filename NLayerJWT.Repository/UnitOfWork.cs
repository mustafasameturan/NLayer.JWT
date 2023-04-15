using Microsoft.EntityFrameworkCore;
using NLayerJWT.Core.UnitOfWork;

namespace NLayerJWT.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Commit()
    {
        _context.SaveChanges();
    }
}