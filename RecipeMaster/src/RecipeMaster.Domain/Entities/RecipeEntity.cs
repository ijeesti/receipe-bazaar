
namespace RecipeMaster.Domain.Entities;

public class RecipeEntity : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Ingredients { get; set; } = string.Empty;
    public string Instructions { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }

    public int UserId { get; set; }
    public UserEntity? User { get; set; }

    public int CategoryId { get; set; }
    public CategoryEntity? Category { get; set; }
    public ICollection<CommentEntity> Comments { get; set; } = [];
}
