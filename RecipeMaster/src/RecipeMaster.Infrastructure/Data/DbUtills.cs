using RecipeMaster.Domain.Contracts;
using RecipeMaster.Domain.Entities;
using RecipeMaster.Domain.Enums;

namespace RecipeMaster.Infrastructure.Data;

public static class DbUtills
{
    internal static UserEntity CreateUser(int id, string name, string email, DateTime createdOn) =>
        new()
        {
            Id = id,
            Name = name,
            Email = email,
            CreatedOn = createdOn
        };

    internal static CategoryEntity CreateCategory(int id, CategoryType type, DateTime createdOn, string desciption) =>
        new()
        {
            Id = id,
            Name = type.ToString(),
            CreatedOn = createdOn,
            Description = desciption
        };

    internal static RecipeEntity CreateRecipe(int id, string title, string ingredients, string instructions, string description,
        string imageUrl, int userId, int categoryId, DateTime createdOn) =>
        new()
        {
            Id = id,
            Title = title,
            Description = description,
            Ingredients = ingredients,
            Instructions = instructions,
            ImageUrl = imageUrl,
            UserId = userId,
            CategoryId = categoryId,
            CreatedOn = createdOn
        };

    internal static CommentEntity CreateComment(int commentId, int recipeId, int userId, string content, DateTime createdOn) =>
        new()
        {
            Id = commentId,
            RecipeId = recipeId,
            UserId = userId,
            Content = content,
            CreatedOn = createdOn
        };

    public static RecipeDto ToRecipeDto(this RecipeEntity r) => new()
    {
        Id = r.Id,
        Title = r.Title,
        Ingredients = r.Ingredients,
        Description = r.Description,
        Instructions = r.Instructions,
        ImageUrl = r.ImageUrl,
        CategoryName = r.Category!.Name,
        CategoryId = r.CategoryId,
        UserName = r.User!.Name,
        UserId = r.User!.Id,
        CreatedOn = r.CreatedOn
    };
}
