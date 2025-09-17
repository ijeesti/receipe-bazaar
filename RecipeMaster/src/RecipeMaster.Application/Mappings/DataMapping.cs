using RecipeMaster.Domain.Contracts;
using RecipeMaster.Domain.Entities;

namespace RecipeMaster.Application.Mappings;

public static class DataMapping
{
    public static CommentDto ToCommentDto(this CommentEntity comment) =>
    new()
    {
        Content = comment.Content,
        CreatedOn = comment.CreatedOn,
        Id = comment.Id,
        RecipeId = comment.RecipeId,
        UserId = comment.UserId

    };

    public static RecipeDto ToRecipeDto(this RecipeEntity r) =>
        new()
        {
            Id = r.Id,
            Title = r.Title,
            Ingredients = r.Ingredients,
            Instructions = r.Instructions,
            ImageUrl = r.ImageUrl,
            CategoryName = r.Category?.Name,
            CategoryId = r.CategoryId,
            UserName = r.User!.Name,
            UserId = r.User!.Id,
            CreatedOn = r.CreatedOn
        };
}