using Microsoft.EntityFrameworkCore;
using RecipeMaster.Domain.Contracts;
using RecipeMaster.Domain.Entities;
using RecipeMaster.Domain.Interfaces;
using RecipeMaster.Infrastructure.Data;

namespace RecipeMaster.Infrastructure.Repositories;

public class RecipeRepository(RecipeDbContext dbContext) : Repository<RecipeEntity>(dbContext), IRecipeRepository
{
    public async Task<IEnumerable<RecipeDto>> GetAllRecipesAsync() =>
        await _dbContext.Recipes
            .Include(r => r.Category)
            .Include(r => r.User)
            .Select(r => r.ToRecipeDto())
            .ToListAsync();

    public async Task<RecipeEntity?> GetRecipeByIdAsync(int id) =>
        await _dbContext.Recipes
            .Include(r => r.Category)
            .Include(r => r.User)
            .FirstOrDefaultAsync(r => r.Id == id);
}