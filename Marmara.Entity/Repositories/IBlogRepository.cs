using Marmara.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marmara.Entity.Repositories
{
    public interface IBlogRepository:IGenericRepository<Blog>
    {
        Task<Blog> GetBlogwithComments(int id);

        void AddLikes(int id);
        void RemoveLikes(int id);
    }
}
