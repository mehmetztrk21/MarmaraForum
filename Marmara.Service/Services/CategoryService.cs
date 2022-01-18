using Marmara.Data.Repositories;
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
    public class CategoryService:GenericService<Category>,ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork,IGenericRepository<Category> repository):base(unitOfWork,repository)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Category> GetByIdWithProducts(int id)
        {
            return await _unitOfWork.Categories.GetByIdWithProducts(id);
        }
    }
}
