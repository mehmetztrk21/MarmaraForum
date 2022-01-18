using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marmara.Entity.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Context { get; set; }
        public string PersonId { get; set; }
        public DateTime Date { get; set; }
        public int BlogId { get; set; }
    }
}
