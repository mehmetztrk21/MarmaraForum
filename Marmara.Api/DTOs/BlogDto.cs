using Marmara.Api.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marmara.Api.DTOs
{
    public class BlogDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Context { get; set; }
        public int likes { get; set; }
        public string PersonId { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
        public User User { get; set; }
    }
}
