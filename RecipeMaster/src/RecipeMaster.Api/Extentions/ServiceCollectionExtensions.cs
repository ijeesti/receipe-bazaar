using Microsoft.EntityFrameworkCore;
using RecipeMaster.Application.Services;
using RecipeMaster.Domain.Interfaces;
using RecipeMaster.Infrastructure.Data;
using RecipeMaster.Infrastructure.Repositories;

namespace RecipeMaster.Api.Extentions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        // Generic repository
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        // Specific repositories
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IRecipeRepository, RecipeRepository>();

        // Services
        services.AddScoped<IRecipeService, RecipeService>();
        services.AddScoped<ICommentService, CommentService>();

        //Database SQLite
        var dbPath = Path.Combine(AppContext.BaseDirectory, "recipe-bazaar-database.db");
        Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);
        services.AddDbContext<RecipeDbContext>(options =>
        {
            options.UseSqlite($"Data Source={dbPath}");
            //  options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });


        return services;
    }
}
