using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace InlinedotsMyBlogApi.Services.Models.Blog.Mappings
{
    public class BlogMappingProfile : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<InlinedotsMyBlogApi.Models.Entities.Blog, BlogPlainModel>();
            CreateMap<InlinedotsMyBlogApi.Models.Entities.Blog, BlogViewModel>();

            CreateMap<BlogViewModel, InlinedotsMyBlogApi.Models.Entities.Blog>()
                .AfterMap((src, dest) =>
                {
                    if (dest.Entity == null)
                    {
                        dest.Entity = new InlinedotsMyBlogApi.Models.Entities.Entity { Created = DateTime.Now, Updated = DateTime.Now, };
                    }
                    else
                    {
                        dest.Entity.Updated = DateTime.Now;
                    }
                });

            CreateMap<BlogPlainModel, InlinedotsMyBlogApi.Models.Entities.Blog>()
                .AfterMap((src, dest) =>
                {
                    if (dest.Entity == null)
                    {
                        dest.Entity = new InlinedotsMyBlogApi.Models.Entities.Entity { Created = DateTime.Now, Updated = DateTime.Now, };
                    }
                    else
                    {
                        dest.Entity.Updated = DateTime.Now;
                    }
                });
        }
        
    }
}
