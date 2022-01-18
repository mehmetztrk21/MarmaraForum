using Marmara.Data.Repositories;
using Marmara.Entity.Entities;
using Marmara.Entity.Repositories;
using Marmara.Entity.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marmara.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private BlogRepository _blogRepository;
        private CategoryRepository _categoryRepository;
        private readonly MarmaraAppContext _context;

        public UnitOfWork(MarmaraAppContext appDbContext)
        {
            _context = appDbContext;
        }

        public IBlogRepository Blogs => _blogRepository=_blogRepository ?? new BlogRepository(_context);

        public ICategoryRepository Categories => _categoryRepository=_categoryRepository ?? new CategoryRepository(_context);
    }
}
