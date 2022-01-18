using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marmara.Entity.Entities
{
    public class Blog
    {
        public Blog()
        {
            Comments = new List<Comment>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Context { get; set; }
        public string PersonId { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
        public List<Comment> Comments { get; set; }
        public int likes { get; set; }

    }
}
