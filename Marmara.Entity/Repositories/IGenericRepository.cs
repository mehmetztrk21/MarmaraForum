using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marmara.Entity.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {

        Task<TEntity> Add(TEntity entity);
        void Remove(TEntity entity);
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetAll();
        TEntity Update(TEntity entity);
    }
}
