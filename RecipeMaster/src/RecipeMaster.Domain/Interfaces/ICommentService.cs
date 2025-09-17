using RecipeMaster.Domain.Contracts;

namespace RecipeMaster.Domain.Interfaces;

public interface ICommentService
{
    Task<IEnumerable<CommentDto?>> GetByRecipeAsync(int recipeId);
    Task<CommentDto?> GetByIdAsync(int id);

    Task<IEnumerable<CommentDto>> GetFilteredAsync(int? recipeId, int? userId, DateTime? from, DateTime? to);

    Task<CommentDto> AddAsync(CommentCreateDto dto);
}