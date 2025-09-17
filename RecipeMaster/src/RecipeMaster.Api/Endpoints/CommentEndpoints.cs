using RecipeMaster.Domain.Contracts;
using RecipeMaster.Domain.Interfaces;

namespace RecipeMaster.Api.Endpoints;

public static class CommentEndpoints
{
    public static WebApplication MapCommentEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/comments").WithTags("Comments");

        // GET: filter comments (by recipe, user, or date range)
        group.MapGet("/", async (
            int? recipeId,
            int? userId,
            DateTime? from,
            DateTime? to,
            ICommentService service) =>
        {
            var comments = await service.GetFilteredAsync(recipeId, userId, from, to);
            return Results.Ok(comments);
        })
        .WithName("GetFilteredComments")
        .WithOpenApi(operation =>
        {
            operation.Summary = "Get filtered comments";
            operation.Description = "Returns comments filtered by optional recipeId, userId, and/or date range.";
            operation.Parameters[0].Description = "Optional recipe ID to filter comments";
            operation.Parameters[1].Description = "Optional user ID to filter comments";
            operation.Parameters[2].Description = "Optional start date (from)";
            operation.Parameters[3].Description = "Optional end date (to)";
            operation.Responses.Clear();
            operation.Responses.Add("200", new Microsoft.OpenApi.Models.OpenApiResponse
            {
                Description = "List of filtered comments"
            });
            return operation;
        });

        // POST: add a comment
        group.MapPost("/", async (CommentCreateDto dto, ICommentService service) =>
        {
            var result = await service.AddAsync(dto);
            return Results.Created($"/api/comments/{result.Id}", dto);
        })
        .WithName("AddComment")
        .WithOpenApi(operation =>
        {
            operation.Summary = "Add a new comment";
            operation.Description = "Creates a comment for a recipe by a user. Both RecipeId and UserId are required in the payload.";
            operation.RequestBody.Description = "Comment data including RecipeId, UserId, and content";
            operation.Responses.Clear();
            operation.Responses.Add("201", new Microsoft.OpenApi.Models.OpenApiResponse
            {
                Description = "Created comment"
            });
            operation.Responses.Add("400", new Microsoft.OpenApi.Models.OpenApiResponse
            {
                Description = "Invalid input"
            });
            return operation;
        });

        return app;
    }
}