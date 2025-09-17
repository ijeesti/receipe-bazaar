namespace RecipeMaster.Domain.Contracts;

public class RecipeDto
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string Ingredients { get; set; } = string.Empty;

    public string Instructions { get; set; } = string.Empty;

    public string? ImageUrl { get; set; }

    public int UserId { get; set; }
    public string? UserName { get; set; } 

    public int CategoryId { get; set; }
    public string? CategoryName { get; set; } 

    public DateTime CreatedOn { get; set; }
}
