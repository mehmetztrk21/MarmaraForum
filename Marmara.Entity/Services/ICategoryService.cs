using Marmara.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marmara.Entity.Services
{
    public interface ICategoryService : IGenericService<Category>
    {
        Task<Category> GetByIdWithProducts(int id);

    }

}
