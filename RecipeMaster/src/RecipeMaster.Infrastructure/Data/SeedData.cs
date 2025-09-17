using Microsoft.EntityFrameworkCore;
using RecipeMaster.Domain.Entities;
using RecipeMaster.Domain.Enums;

namespace RecipeMaster.Infrastructure.Data;

public static class SeedData
{
    public static void Seed(ModelBuilder builder)
    {
        var createdOn = new DateTime(2025, 9, 15, 0, 0, 0);

        // Users
        builder.Entity<UserEntity>().HasData(
            DbUtills.CreateUser(1, "Alice", "alice@example.com", createdOn),
            DbUtills.CreateUser(2, "Bob", "bob@example.com", createdOn),
            DbUtills.CreateUser(3, "Charlie", "charlie@example.com", createdOn),
            DbUtills.CreateUser(4, "Diana", "diana@example.com", createdOn),
            DbUtills.CreateUser(5, "Ethan", "ethan@example.com", createdOn)
        );

        // Categories
        builder.Entity<CategoryEntity>().HasData(
            DbUtills.CreateCategory(1, CategoryType.Breakfast, createdOn, "Veggie Breakfast"),
            DbUtills.CreateCategory(2, CategoryType.Lunch, createdOn, "Super Lunch"),
            DbUtills.CreateCategory(3, CategoryType.Dinner, createdOn, "Light Dinner"),
            DbUtills.CreateCategory(4, CategoryType.Dessert, createdOn, "Sweet Dessert"),
            DbUtills.CreateCategory(5, CategoryType.Party, createdOn, "Crazy Party"),
            DbUtills.CreateCategory(6, CategoryType.Special, createdOn, "Work Special")
        );

        // Recipes (10 recipes across all categories)
        builder.Entity<RecipeEntity>().HasData(
            DbUtills.CreateRecipe(1, "Pancakes", "Flour, Eggs, Milk, Sugar", "Mix and fry", "suitable vegan and vegs", "https://placehold.co/600x400", 1, 1, createdOn),
            DbUtills.CreateRecipe(2, "Spaghetti Bolognese", "Pasta, Beef, Tomato Sauce", "Cook pasta and sauce, combine", "not suitable vegan and vegs" ,"https://picsum.photos/id/1/200/300", 2, 3, createdOn),
            DbUtills.CreateRecipe(3, "Caesar Salad", "Lettuce, Croutons, Caesar Dressing", "Mix all ingredients", "Tasty salad", "https://picsum.photos/id/2/200/300", 3, 2, createdOn),
            DbUtills.CreateRecipe(4, "Chocolate Cake", "Flour, Cocoa, Sugar, Eggs", "Bake at 350F for 30min", "watch cartoon ", "https://picsum.photos/id/3/200/300", 4, 4, createdOn),
            DbUtills.CreateRecipe(5, "Grilled Chicken", "Chicken, Spices", "Grill until cooked", "need energy to cook", "https://picsum.photos/id/4/200/300", 5, 3, createdOn),
            DbUtills.CreateRecipe(6, "French Toast", "Bread, Eggs, Milk", "Fry slices in butter", "fresh butter is preffered ", "https://picsum.photos/id/5/200/300", 1, 1, createdOn),
            DbUtills.CreateRecipe(7, "Burger", "Bun, Beef Patty, Lettuce, Tomato", "Cook patty and assemble", "not healthy food ", "https://picsum.photos/id/6/200/300", 2, 5, createdOn),
            DbUtills.CreateRecipe(8, "Sushi", "Rice, Fish, Seaweed", "Roll ingredients together", "soooooper sushi taste", "https://picsum.photos/id/7/200/300", 3, 6, createdOn),
            DbUtills.CreateRecipe(9, "Tacos", "Tortilla, Meat, Veggies", "Assemble tacos", "eat after gym", "https://picsum.photos/id/8/200/300", 4, 5, createdOn),
            DbUtills.CreateRecipe(10, "Omelette", "Eggs, Cheese, Vegetables", "Cook in pan", "good morning guys ", "https://picsum.photos/id/9/200/300", 5, 1, createdOn)
        );

        // Comments: Each user comments on each recipe
        int commentId = 1;
        for (int recipeId = 1; recipeId < 6; recipeId++)
        {
            for (int userId = 1; userId < 4; userId++)
            {
                builder.Entity<CommentEntity>().HasData(
                    DbUtills.CreateComment(commentId++,recipeId, userId, $"User {userId} says: This is great for recipe {recipeId}!", createdOn)
                );
            }
        }
    }
}
