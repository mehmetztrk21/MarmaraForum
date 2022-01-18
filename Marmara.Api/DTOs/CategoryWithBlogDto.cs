using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marmara.Api.DTOs
{
    public class CategoryWithBlogDto:CategoryDto
    {
        public List<BlogDto> Blogs { get; set; }
    }
}
