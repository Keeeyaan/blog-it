
using api.Data;
using api.Models.Domain;
using api.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.Implementation
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly ApplicationDBContext dbContext;
        public BlogPostRepository(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await dbContext.BlogPosts.ToListAsync();
        }
        public async Task<BlogPost?> GetByIdAsync(Guid id)
        {
            return await dbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<BlogPost> CreateAsync(BlogPost blogPost)
        {
            await dbContext.BlogPosts.AddAsync(blogPost);
            await dbContext.SaveChangesAsync();

            return blogPost;
        }
        public async Task<BlogPost?> UpdateByIdAsync(Guid id, BlogPost blogPost)
        {
            var existingBlogPost = await dbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == id);

            if (existingBlogPost == null) return null;

            existingBlogPost.Title = blogPost.Title;
            existingBlogPost.Slug = blogPost.Slug;
            existingBlogPost.Content = blogPost.Content;
            existingBlogPost.CoverImage = blogPost.CoverImage;
            existingBlogPost.IsVisible = blogPost.IsVisible;
            existingBlogPost.UpdatedAt = DateTime.Now;

            await dbContext.SaveChangesAsync();

            return existingBlogPost;
        }
        public async Task<BlogPost?> DeleteByIdAsync(Guid id)
        {
            var existingBlogPost = await dbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == id);

            if (existingBlogPost == null) return null;

            dbContext.BlogPosts.Remove(existingBlogPost);
            await dbContext.SaveChangesAsync();

            return existingBlogPost;
        }
    }
}