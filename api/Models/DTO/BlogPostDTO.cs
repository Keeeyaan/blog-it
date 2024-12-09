
namespace api.Models.DTO
{
    public class BlogPostDTO
    {
        public Guid Id { get; set; }
        public required string Title { get; set; } = null!;
        public required string Slug { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string? CoverImage { get; set; }
        public bool IsVisible { get; set; }
        public DateTime PublishedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}