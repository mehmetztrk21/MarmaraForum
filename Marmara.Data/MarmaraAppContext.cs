using Marmara.Data.Seeds;
using Marmara.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marmara.Data
{
    public class MarmaraAppContext:DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }


        public MarmaraAppContext(DbContextOptions<MarmaraAppContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogSeeds());
            modelBuilder.ApplyConfiguration(new CategorySeeds());

        }
    }
}
