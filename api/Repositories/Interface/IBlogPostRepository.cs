using api.Models.Domain;

namespace api.Repositories.Interface
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPost>> GetAllAsync();
        Task<BlogPost?> GetByIdAsync(Guid id);
        Task<BlogPost> CreateAsync(BlogPost blogPost);
        Task<BlogPost?> UpdateByIdAsync(Guid id, BlogPost blogPost);
        Task<BlogPost?> DeleteByIdAsync(Guid id);
    }
}