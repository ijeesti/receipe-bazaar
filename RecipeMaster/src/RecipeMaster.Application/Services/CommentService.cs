using RecipeMaster.Application.Mappings;
using RecipeMaster.Domain.Contracts;
using RecipeMaster.Domain.Entities;
using RecipeMaster.Domain.Interfaces;
using System.Linq.Expressions;

namespace RecipeMaster.Application.Services;

public class CommentService(IRepository<CommentEntity> repository) : ICommentService
{
    public async Task<CommentDto> AddAsync(CommentCreateDto dto)
    {
        var comment = new CommentEntity
        {
            Content = dto.Content,
            RecipeId = dto.RecipeId,
            CreatedOn = DateTime.Now,
            UserId = dto.UserId
        };

        await repository.AddAsync(comment);
        await repository.SaveChangesAsync();
        return comment.ToCommentDto();
    }

    public async Task<CommentDto?> GetByIdAsync(int id)
    {
        var result = await repository.GetByIdAsync(id);

        return result?.ToCommentDto();
    }

    public async Task<IEnumerable<CommentDto?>> GetByRecipeAsync(int recipeId)
    {
        var comments = await repository.GetByQueryAsync(r => r.RecipeId == recipeId);
        return comments?.Select(c => c.ToCommentDto()) ?? [];
    }

    public async Task<IEnumerable<CommentDto>> GetFilteredAsync(int? recipeId, int? userId, DateTime? from, DateTime? to)
    {
        Expression<Func<CommentEntity, bool>> predicate = c =>
        (!recipeId.HasValue || c.RecipeId == recipeId.Value) &&
        (!userId.HasValue || c.UserId == userId.Value) &&
        (!from.HasValue || c.CreatedOn >= from.Value) &&
        (!to.HasValue || c.CreatedOn <= to.Value);

        var comments = await repository.GetByQueryAsync(predicate);

        return comments.Select(c => c.ToCommentDto());
    }
}