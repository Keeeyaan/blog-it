using System.ComponentModel.DataAnnotations;

namespace api.Models.DTO
{
    public class CreateBlogPostRequestDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Title has to be a minimum of 3 characters")]
        [MaxLength(60, ErrorMessage = "Title has to be a maximum of 3 characters")]
        public string Title { get; set; } = null!;
        [Required]
        [MinLength(3, ErrorMessage = "Content has to be a minimum of 3 characters")]
        [MaxLength(1600, ErrorMessage = "Content has to be a maximum of 1600 characters")]
        public string Content { get; set; } = null!;
        public string? CoverImage { get; set; }
    }
}