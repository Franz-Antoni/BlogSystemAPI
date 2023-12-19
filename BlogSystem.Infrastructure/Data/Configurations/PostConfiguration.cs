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
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("posts");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Content)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("content");

            builder.Property(e => e.CreateAt)
                .HasColumnType("smalldatetime")
                .HasColumnName("create_at");

            builder.Property(e => e.ImageId).HasColumnName("image_id");

            builder.Property(e => e.Status).HasColumnName("status");

            builder.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title");

            builder.Property(e => e.UserLoginId).HasColumnName("user_login_id");

            builder.HasOne(d => d.Image)
                .WithMany(p => p.Posts)
                .HasForeignKey(d => d.ImageId)
                .HasConstraintName("fk_image_post_id");

            builder.HasOne(d => d.UserLogin)
                .WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserLoginId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_login_post_id");
        }
    }
}
