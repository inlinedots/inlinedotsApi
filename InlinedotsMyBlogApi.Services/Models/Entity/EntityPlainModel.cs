using System;
using System.Collections.Generic;
using System.Text;

namespace InlinedotsMyBlogApi.Services.Models.Entity
{
    public class EntityPlainModel
    {
        public int Id { get; set; }
        public DateTimeOffset? Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
        public byte? Deleted { get; set; }
    }
}
