using Marmara.Api.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marmara.Api.DTOs
{
    public class CommentDto
    {
        public User User { get; set; }
        public int Id { get; set; }
        public string Context { get; set; }
        public string PersonId { get; set; }
        public DateTime Date { get; set; }
        public int BlogId { get; set; }
    }
}
