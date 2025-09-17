using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeMaster.Domain.Entities;

namespace RecipeMaster.Infrastructure.Data.Configuration;

public class RecipeEntityConfiguration : IEntityTypeConfiguration<RecipeEntity>
{
    public void Configure(EntityTypeBuilder<RecipeEntity> builder)
    {
        builder.ToTable("Recipes", "recipe");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.CreatedOn)
               .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(r => r.Title)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(r => r.Description)
               .HasMaxLength(500);

        builder.Property(r => r.Ingredients)
               .IsRequired();

        builder.Property(r => r.Instructions)
               .IsRequired();

        builder.Property(r => r.ImageUrl)
               .HasMaxLength(250);

        builder.HasOne(r => r.User)
               .WithMany(u => u.Recipes)
               .HasForeignKey(r => r.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.Category)
               .WithMany(c => c.Recipes)
               .HasForeignKey(r => r.CategoryId)
               .OnDelete(DeleteBehavior.Restrict); 
    }
}
