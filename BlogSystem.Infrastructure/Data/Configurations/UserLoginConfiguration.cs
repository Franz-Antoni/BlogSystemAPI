using BlogSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Infrastructure.Data.Configurations
{
    public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.ToTable("user_login");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.EmailAddress)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email_address");

            builder.Property(e => e.LoginName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("login_name");

            builder.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password_hash");

            builder.Property(e => e.Status).HasColumnName("status");

            builder.Property(e => e.UserId).HasColumnName("user_id");

            builder.HasOne(d => d.User)
                .WithMany(p => p.UserLogins)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_account_user_login_id");
        }
    }
}
