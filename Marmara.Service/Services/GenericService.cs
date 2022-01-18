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
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity:class
    {
        private readonly IGenericRepository<TEntity> _repository;

        public GenericService(IUnitOfWork unitOfWork,IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public async Task<TEntity> Add(TEntity entity)
        {
           var new_entity=await _repository.Add(entity);
            return new_entity;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            var update_entity =_repository.Update(entity);
            return update_entity;
        }
    }
}
