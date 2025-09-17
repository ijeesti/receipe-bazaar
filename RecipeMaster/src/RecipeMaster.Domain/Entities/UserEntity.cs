namespace RecipeMaster.Domain.Entities;

public class UserEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public ICollection<RecipeEntity> Recipes { get; set; } = [];
    public ICollection<CommentEntity> Comments { get; set; } = [];
}