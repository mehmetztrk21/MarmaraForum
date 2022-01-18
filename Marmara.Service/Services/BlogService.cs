using Marmara.Entity.Entities;
using Marmara.Entity.Repositories;
using Marmara.Entity.Services;
using Marmara.Entity.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marmara.Service.Services
{
    public class BlogService: GenericService<Blog>,IBlogService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BlogService(IUnitOfWork unitOfWork,IGenericRepository<Blog> repository) : base(unitOfWork,repository)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Blog> GetBlogwithComments(int id)
        {
            
            return await _unitOfWork.Blogs.GetBlogwithComments(id);
        }
        public void AddLikes(int id)
        {
            _unitOfWork.Blogs.AddLikes(id);
        }
        public void RemoveLikes(int id)
        {
            _unitOfWork.Blogs.RemoveLikes(id);
        }
    }
}
