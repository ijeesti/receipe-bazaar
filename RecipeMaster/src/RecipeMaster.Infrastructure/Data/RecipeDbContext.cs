using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RecipeMaster.Domain.Entities;
using RecipeMaster.Infrastructure.Data.Configuration;

namespace RecipeMaster.Infrastructure.Data;

public class RecipeDbContext : DbContext
{
    public RecipeDbContext(DbContextOptions<RecipeDbContext> options) : base(options) { }

    public DbSet<UserEntity> Users => Set<UserEntity>();
    public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
    public DbSet<RecipeEntity> Recipes => Set<RecipeEntity>();
    public DbSet<CommentEntity> Comments => Set<CommentEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
        modelBuilder.ApplyConfiguration(new RecipeEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CommentEntityConfiguration());
        SeedData.Seed(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var dbPath = Path.Combine(AppContext.BaseDirectory, "recipe-bazaar-database.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");

            // Recommended: log warnings for pending model changes
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Throw(RelationalEventId.PendingModelChangesWarning)
            );
        }

        base.OnConfiguring(optionsBuilder);
    }
}
