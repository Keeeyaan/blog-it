namespace api.Models.Domain
{
    public class BlogPost
    {
        public Guid Id { get; set; }
        public required string Title { get; set; } = null!;
        public required string Slug { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string? CoverImage { get; set; }
        public bool IsVisible { get; set; } = true;
        public DateTime PublishedAt { get; set; } = DateTime.Now;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}