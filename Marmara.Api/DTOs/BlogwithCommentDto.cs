using Marmara.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marmara.Api.DTOs
{
    public class BlogwithCommentDto:BlogDto
    {
        public List<Comment> Comments { get; set; }
    }
}
