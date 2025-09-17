using RecipeMaster.Domain.Contracts;
using RecipeMaster.Domain.Entities;

namespace RecipeMaster.Domain.Interfaces;

public interface IRecipeRepository : IRepository<RecipeEntity>
{
    Task<IEnumerable<RecipeDto>> GetAllRecipesAsync();
    Task<RecipeEntity?> GetRecipeByIdAsync(int id);
}


public interface ICommentRepository : IRepository<CommentEntity>
{
    IQueryable<CommentEntity> GetAsQueryable();
    Task<IEnumerable<CommentEntity>> GetByRecipeIdAsync(int recipeId);
}