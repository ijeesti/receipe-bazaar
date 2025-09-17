namespace RecipeMaster.Domain.Contracts;

public abstract class CommentBaseDto
{
    public int RecipeId { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; } = string.Empty;
}

public class CommentCreateDto : CommentBaseDto
{
    // add additional data
}

public class CommentDto : CommentBaseDto
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; }
}

