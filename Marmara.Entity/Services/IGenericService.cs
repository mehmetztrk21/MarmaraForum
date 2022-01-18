using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marmara.Entity.Services
{
    public interface IGenericService<TEntity> where TEntity:class
    {
        Task<TEntity> Add(TEntity entity);
        void Remove(TEntity entity);
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        TEntity Update(TEntity entity);
    }
}
