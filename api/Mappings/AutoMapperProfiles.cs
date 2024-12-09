using api.Models.Domain;
using api.Models.DTO;
using AutoMapper;

namespace api.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<BlogPost, BlogPostDTO>().ReverseMap();
            CreateMap<CreateBlogPostRequestDTO, BlogPost>().ReverseMap();
            CreateMap<UpdateBlogPostRequestDTO, BlogPost>().ForMember(dest => dest.CreatedAt, opt => opt.Ignore()).ForMember(dest => dest.PublishedAt, opt => opt.Ignore()).ReverseMap();
        }
    }
}