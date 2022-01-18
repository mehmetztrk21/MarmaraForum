using Marmara.Entity.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marmara.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly MarmaraAppContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public GenericRepository(MarmaraAppContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            _context.SaveChanges();
            //insert into Category(Name) values('Sosyal')
            return entity;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
            //Select * from TEntity;
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
            //Select * from TEntity where Id=id;
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
            //Delete from TEntity where Id=entity.Id
            _context.SaveChanges();
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            //update TEntity set name=entity.Name,CategoryId=entity.CatgoryId where Id=entity.Id
            return entity;
        }
    }
}
