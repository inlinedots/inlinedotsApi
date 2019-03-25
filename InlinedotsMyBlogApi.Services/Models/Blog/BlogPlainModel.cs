using InlinedotsMyBlogApi.Services.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace InlinedotsMyBlogApi.Services.Models.Blog
{
    public class BlogPlainModel
    {
        public int Id { get; set; }
        public int? EntityId { get; set; }
        public string HeadLine { get; set; }
        public string BodyText { get; set; }

        public EntityPlainModel Entity { get; set; }

    }
}
