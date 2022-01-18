using Marmara.Entity.Entities;
using Marmara.Entity.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marmara.Data.Repositories
{
    public class BlogRepository:GenericRepository<Blog>,IBlogRepository
    {
        private MarmaraAppContext appDbContext { get => _context as MarmaraAppContext; }

        public BlogRepository(MarmaraAppContext context) : base(context)
        {           

        }

        public async Task<Blog> GetBlogwithComments(int id)
        {
            var list = await appDbContext.Blogs.Include(i => i.Comments).SingleOrDefaultAsync(i=>i.Id==id);
            //SELECT Blogs.*,Comments.* from Blogs INNER JOIN Comments on Blogs.Id=Comments.BlogId where Blogs.Id=id
            return list;
        }

        public void AddLikes(int id)
        {
            var blog =  appDbContext.Blogs.Where(i => i.Id == id).FirstOrDefault();
            blog.likes += 1;
            appDbContext.SaveChanges();
        }

        public void RemoveLikes(int id)
        {
            var blog = appDbContext.Blogs.Where(i => i.Id == id).FirstOrDefault();
            blog.likes -= 1;
            appDbContext.SaveChanges();
        }
    }
}
