using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NLayerJWT.Core.Models;

namespace NLayerJWT.Repository;

/// <summary>
/// Identity üyelik tabloları
/// </summary>
public class AppDbContext : IdentityDbContext<UserApp, IdentityRole, string>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

    /// <summary>
    /// tüm configuration dosyalarını uyguladık.
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        
        base.OnModelCreating(builder);
    }
}