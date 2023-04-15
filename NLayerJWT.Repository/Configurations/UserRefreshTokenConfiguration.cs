using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerJWT.Core.Models;

namespace NLayerJWT.Repository.Configurations;

public class UserRefreshTokenConfiguration : IEntityTypeConfiguration<UserRefreshToken>
{
    public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
    {
        builder.HasKey(x => x.UserId);
        builder.Property(x => x.Code).HasMaxLength(200);
    }
}