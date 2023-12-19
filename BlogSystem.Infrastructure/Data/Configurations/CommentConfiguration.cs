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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("comments");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Content)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("content");

            builder.Property(e => e.CreateAt)
                .HasColumnType("smalldatetime")
                .HasColumnName("create_at");

            builder.Property(e => e.PostId).HasColumnName("post_id");

            builder.Property(e => e.ResponseId).HasColumnName("response_id");

            builder.Property(e => e.Status).HasColumnName("status");

            builder.Property(e => e.UserLoginId).HasColumnName("user_login_id");

            builder.HasOne(d => d.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_post_comment_id");

            builder.HasOne(d => d.Response)
                .WithMany(p => p.InverseResponse)
                .HasForeignKey(d => d.ResponseId)
                .HasConstraintName("fk_comment_id");

            builder.HasOne(d => d.UserLogin)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserLoginId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_login_comment_id");
        }
    }
}
