using RecipeMaster.Domain.Contracts;
using RecipeMaster.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RecipeMaster.Api.Endpoints;

public static class RecipeEndpoints
{
    public static WebApplication MapRecipeEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/recipes").WithTags("Recipes");

        // GET: all recipes
        group.MapGet("/", async (IRecipeService service) =>
        {
            var recipes = await service.GetAllRecipesAsync();
            return Results.Ok(recipes);
        })
        .WithName("GetAllRecipes")
        .WithOpenApi(operation =>
        {
            operation.Summary = "Retrieve all recipes";
            operation.Description = "Returns a list of all recipes in the system.";
            operation.Responses.Clear();
            operation.Responses.Add("200", new Microsoft.OpenApi.Models.OpenApiResponse
            {
                Description = "List of recipes"
            });
            return operation;
        });

        // GET: recipe by ID
        group.MapGet("/{id:int}", async (int id, IRecipeService service) =>
        {
            var recipe = await service.GetRecipeByIdAsync(id);
            return recipe is null ? Results.NotFound() : Results.Ok(recipe);
        })
        .WithName("GetRecipeById")
        .WithOpenApi(operation =>
        {
            operation.Summary = "Get a recipe by ID";
            operation.Description = "Returns a single recipe for the specified ID.";
            operation.Responses.Clear();
            operation.Responses.Add("200", new Microsoft.OpenApi.Models.OpenApiResponse
            {
                Description = "Recipe found"
            });
            operation.Responses.Add("404", new Microsoft.OpenApi.Models.OpenApiResponse
            {
                Description = "Recipe not found"
            });
            return operation;
        });

        // POST: create recipe
        group.MapPost("/", async (CreateRecipeDto dto, IRecipeService service) =>
        {
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, true))
                return Results.BadRequest(validationResults);

            var newId = await service.CreateRecipeAsync(dto);
            return Results.Created($"/api/recipes/{newId}", dto);
        })
        .WithName("CreateRecipe")
        .WithOpenApi(operation =>
        {
            operation.Summary = "Create a new recipe";
            operation.Description = "Adds a new recipe to the system.";
            operation.RequestBody.Description = "Recipe data including title, description, ingredients, etc.";
            operation.Responses.Clear();
            operation.Responses.Add("201", new Microsoft.OpenApi.Models.OpenApiResponse
            {
                Description = "Recipe successfully created"
            });
            operation.Responses.Add("400", new Microsoft.OpenApi.Models.OpenApiResponse
            {
                Description = "Invalid input"
            });
            return operation;
        });

        // PUT: update recipe
        group.MapPut("/{id:int}", async (int id, RecipeDto dto, IRecipeService service) =>
        {
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, true))
                return Results.BadRequest(validationResults);

            if (id != dto.Id)
                return Results.BadRequest("ID mismatch");

            var updated = await service.UpdateRecipeAsync(dto);
            return updated is null ? Results.NotFound() : Results.Ok(updated);
        })
        .WithName("UpdateRecipe")
        .WithOpenApi(operation =>
        {
            operation.Summary = "Update an existing recipe";
            operation.Description = "Updates a recipe with new data. The ID in the URL must match the DTO ID.";
            operation.RequestBody.Description = "Updated recipe data including ID";
            operation.Responses.Clear();
            operation.Responses.Add("200", new Microsoft.OpenApi.Models.OpenApiResponse
            {
                Description = "Recipe successfully updated"
            });
            operation.Responses.Add("400", new Microsoft.OpenApi.Models.OpenApiResponse
            {
                Description = "Validation failed or ID mismatch"
            });
            operation.Responses.Add("404", new Microsoft.OpenApi.Models.OpenApiResponse
            {
                Description = "Recipe not found"
            });
            return operation;
        });

        // GET: comments for a recipe
        group.MapGet("/{recipeId:int}/comments", async (int recipeId, IRecipeService service) =>
        {
            var comments = await service.GetCommentsByRecipeIdAsync(recipeId);
            return Results.Ok(comments);
        })
        .WithName("GetCommentsByRecipe")
        .WithOpenApi(operation =>
        {
            operation.Summary = "Get comments for a recipe";
            operation.Description = "Returns all comments associated with the specified recipe ID.";
            operation.Responses.Clear();
            operation.Responses.Add("200", new Microsoft.OpenApi.Models.OpenApiResponse
            {
                Description = "List of comments"
            });
            operation.Responses.Add("404", new Microsoft.OpenApi.Models.OpenApiResponse
            {
                Description = "no comments"
            });
            return operation;
        });

        return app;
    }
}
