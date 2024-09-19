using System.Data;
using AmnPardazJabari.Domain.Enums;
using AmnPardazJabari.Domain.Users;
using AmnPardazJabari.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmnPardazJabari.Infrastructure.Users;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.OwnsOne
        (
            user => user.UserName, buildAction =>
            {
                buildAction.Property(propertyExpression => propertyExpression.Value)
                    .IsRequired()
                    .HasColumnType(SqlDbType.NVarChar.ToString())
                    .HasMaxLength(32)
                    .HasColumnName(nameof(User.UserName));
            }
        );
        builder.OwnsOne
        (
            user => user.Password, buildAction =>
            {
                buildAction.Property(propertyExpression => propertyExpression.Value)
                    .IsRequired()
                    .HasColumnType(SqlDbType.NVarChar.ToString())
                    .HasMaxLength(150)
                    .HasColumnName(nameof(User.Password));
            }
        );
    }
}