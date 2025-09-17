using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeMaster.Domain.Entities;

namespace RecipeMaster.Infrastructure.Data.Configuration;

public class CommentEntityConfiguration : IEntityTypeConfiguration<CommentEntity>
{
    public void Configure(EntityTypeBuilder<CommentEntity> builder)
    {
        builder.ToTable("Comments", "recipe");
        builder.HasKey(c => c.Id);
        builder .Property(u => u.CreatedOn).HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(c => c.Content).IsRequired().HasMaxLength(500);

        builder.HasOne(c => c.User)
               .WithMany(u => u.Comments)
               .HasForeignKey(c => c.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(c => c.Recipe)
               .WithMany(r => r.Comments)
               .HasForeignKey(c => c.RecipeId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
