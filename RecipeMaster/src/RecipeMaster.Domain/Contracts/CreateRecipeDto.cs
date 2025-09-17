namespace RecipeMaster.Domain.Contracts;

public class CreateRecipeDto
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string Ingredients { get; set; } = string.Empty;

    public string Instructions { get; set; } = string.Empty;

    public string? ImageUrl { get; set; }

    public int UserId { get; set; }

    public int CategoryId { get; set; }
}
