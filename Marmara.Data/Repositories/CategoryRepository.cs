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
    public class CategoryRepository:GenericRepository<Category>,ICategoryRepository
    {
        private MarmaraAppContext appDbContext { get => _context as MarmaraAppContext; }
        public CategoryRepository(MarmaraAppContext context):base(context)
        {
        }

        public async Task<Category> GetByIdWithProducts(int id)
        {
            var list = await appDbContext.Categories.Include(i => i.Blogs).SingleOrDefaultAsync(i => i.Id == id);
            //SELECT Categories.*,Blogs.* FROM Categories inner join Blogs on Categories.Id=Blogs.CategoryId where Categories.Id=id;

            return list;
        }
    }
}
