using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace InlinedotsMyBlogApi.Services.Models.Entity.Mappings
{
    public class EntityMappingProfile : Profile
    {
        public EntityMappingProfile()
        {
            CreateMap<InlinedotsMyBlogApi.Models.Entities.Entity, EntityPlainModel>();
            CreateMap<EntityPlainModel, InlinedotsMyBlogApi.Models.Entities.Entity>();
        }
    }
}
