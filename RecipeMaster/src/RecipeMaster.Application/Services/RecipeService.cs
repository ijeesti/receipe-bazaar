using RecipeMaster.Application.Mappings;
using RecipeMaster.Domain.Contracts;
using RecipeMaster.Domain.Entities;
using RecipeMaster.Domain.Interfaces;

namespace RecipeMaster.Application.Services;

public class RecipeService(IRecipeRepository recipeRepository, ICommentRepository commentRepository) : IRecipeService
{
    public async Task<IEnumerable<RecipeDto>> GetAllRecipesAsync() => await recipeRepository.GetAllRecipesAsync();

    public async Task<RecipeDto?> GetRecipeByIdAsync(int id)
    {
        var entity = await recipeRepository.GetRecipeByIdAsync(id);
        return entity == null
            ? null
            : entity.ToRecipeDto();
    }
    public async Task<int> CreateRecipeAsync(CreateRecipeDto createRecipeDto)
    {
        try
        {
            var recipe = new RecipeEntity
            {
                Title = createRecipeDto.Title,
                Ingredients = createRecipeDto.Ingredients,
                Instructions = createRecipeDto.Instructions,
                ImageUrl = createRecipeDto.ImageUrl,
                CategoryId = createRecipeDto.CategoryId,
                UserId = createRecipeDto.UserId
            };

            await recipeRepository.AddAsync(recipe);
            await recipeRepository.SaveChangesAsync();
            return recipe.Id;
        }
        catch (Exception ex)
        {
            var x = ex.Message;
            throw;
        }

    }

    public async Task<RecipeDto?> UpdateRecipeAsync(RecipeDto recipeDto)
    {
        var existingEntity = await recipeRepository.GetRecipeByIdAsync(recipeDto.Id);

        if (existingEntity is null)
        {
            return null;
        }
        existingEntity.Ingredients = recipeDto.Ingredients;
        existingEntity.Instructions = recipeDto.Instructions;
        existingEntity.CategoryId = recipeDto.CategoryId;
        existingEntity.UserId = recipeDto.UserId;
        existingEntity.Title = recipeDto.Title;
        existingEntity.ImageUrl = recipeDto.ImageUrl;

        await recipeRepository.UpdateAsync(existingEntity);
        await recipeRepository.SaveChangesAsync();
        return existingEntity.ToRecipeDto();
    }

    public async Task<IEnumerable<CommentDto>> GetCommentsByRecipeIdAsync(int recipeId)
    {
        var comments = await commentRepository.GetByRecipeIdAsync(recipeId);

        return (comments == null || !comments.Any())
        ? []
        : comments.Select(c => new CommentDto
        {
            Id = c.Id,
            RecipeId = c.RecipeId,
            Content = c.Content,
            UserId = c.UserId,
            UserName = c.User?.Name ?? "Unknown",
            CreatedOn = c.CreatedOn
        }).AsEnumerable();
    }
}