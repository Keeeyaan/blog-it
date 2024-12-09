using api.Models.Domain;
using api.Models.DTO;
using api.Repositories.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/blogposts")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IMapper mapper;
        public BlogPostController(IBlogPostRepository blogPostRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.blogPostRepository = blogPostRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogPost()
        {
            var blogPostsDomain = await blogPostRepository.GetAllAsync();

            var blogPostsDTO = mapper.Map<List<BlogPostDTO>>(blogPostsDomain);

            return Ok(blogPostsDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetBlogPostById([FromRoute] Guid id)
        {
            var blogPostDomain = await blogPostRepository.GetByIdAsync(id);

            if (blogPostDomain == null) return NotFound();

            var blogPostDTO = mapper.Map<BlogPostDTO>(blogPostDomain);

            return Ok(blogPostDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogPost(CreateBlogPostRequestDTO request)
        {
            var blogPostDomain = mapper.Map<BlogPost>(request);

            blogPostDomain.Slug = request.Title.ToLower().Replace(' ', '-');

            blogPostDomain = await blogPostRepository.CreateAsync(blogPostDomain);

            var blogPostDTO = mapper.Map<BlogPostDTO>(blogPostDomain);

            return Ok(blogPostDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateBlogPostById([FromRoute] Guid id, UpdateBlogPostRequestDTO request)
        {
            var blogPostDomain = mapper.Map<BlogPost>(request);

            blogPostDomain = await blogPostRepository.UpdateByIdAsync(id, blogPostDomain);

            if (blogPostDomain == null) return NotFound();

            var blogPostDTO = mapper.Map<BlogPostDTO>(blogPostDomain);

            return Ok(blogPostDTO);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteBlogPostById([FromRoute] Guid id)
        {
            var blogPostDomain = await blogPostRepository.DeleteByIdAsync(id);

            if (blogPostDomain == null) return NotFound();

            return NoContent();
        }
    }
}