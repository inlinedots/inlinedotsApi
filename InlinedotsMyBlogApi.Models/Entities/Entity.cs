using System;
using System.Collections.Generic;

namespace InlinedotsMyBlogApi.Models.Entities
{
    public partial class Entity
    {
        public Entity()
        {
            Blog = new HashSet<Blog>();
        }

        public int Id { get; set; }
        public DateTimeOffset? Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
        public byte? Deleted { get; set; }

        public ICollection<Blog> Blog { get; set; }
    }
}
