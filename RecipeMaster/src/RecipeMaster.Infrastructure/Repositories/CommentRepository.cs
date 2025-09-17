using Microsoft.EntityFrameworkCore;
using RecipeMaster.Domain.Entities;
using RecipeMaster.Domain.Interfaces;
using RecipeMaster.Infrastructure.Data;

namespace RecipeMaster.Infrastructure.Repositories;

public class CommentRepository(RecipeDbContext dbContext) : Repository<CommentEntity>(dbContext), ICommentRepository
{
    public async Task<IEnumerable<CommentEntity>> GetByRecipeIdAsync(int recipeId) =>
        await _dbContext.Comments
        .Include(r => r.User)
        .Where(t => t.RecipeId == recipeId)
        .ToListAsync();

    public IQueryable<CommentEntity> GetAsQueryable() => _dbContext.Comments;
}