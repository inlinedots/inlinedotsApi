using System;
using System.Collections.Generic;

namespace InlinedotsMyBlogApi.Models.Entities
{
    public partial class Blog
    {
        public int Id { get; set; }
        public int? EntityId { get; set; }
        public string HeadLine { get; set; }
        public string BodyText { get; set; }

        public Entity Entity { get; set; }
    }
}
