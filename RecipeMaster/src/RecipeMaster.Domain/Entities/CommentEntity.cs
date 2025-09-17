namespace RecipeMaster.Domain.Entities;

public class CommentEntity : BaseEntity
{
    public int UserId { get; set; }
    public UserEntity? User { get; set; }

    public int RecipeId { get; set; }
    public RecipeEntity? Recipe { get; set; }

    public string Content { get; set; } = string.Empty;
}
