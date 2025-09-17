using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeMaster.Domain.Entities;

namespace RecipeMaster.Infrastructure.Data.Configuration;

public class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.ToTable("Categories", "recipe");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(c => c.Description)
               .HasMaxLength(250);

        builder.Property(c => c.IconUrl)
               .HasMaxLength(250);

        builder.HasMany(c => c.Recipes)
               .WithOne(r => r.Category)
               .HasForeignKey(r => r.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}