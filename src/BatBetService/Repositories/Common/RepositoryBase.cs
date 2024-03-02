using BatBetService.Data;
using BatBetService.Interfaces.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatBetService.Repositories.Common
{
    public class RepositoryBase<TEntity>(BatBetDbContext context) : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly BatBetDbContext _context = context;
        protected readonly DbSet<TEntity> _entity = context.Set<TEntity>();

        public async Task<IList<TEntity>> GetAll()
        {
            return await _entity.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _entity.FindAsync(id);
        }

        public async Task<TEntity> FindAsNoTracking(int id)
        {
            TEntity entity = await _entity.FindAsync(id);

            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }

            return entity;
        }

        public async Task Add(TEntity entity)
        {
            await _entity.AddAsync(entity);
        }

        public async Task RemoveById(int id)
        {
            TEntity entity = await GetById(id);
            if (entity != null)
            {
                _entity.Remove(entity);
            }
        }

        public void Remove(TEntity entity)
        {
            _entity.Remove(entity);
        }

        public void RemoveInScale(IList<TEntity> entities)
        {
            foreach (var entity in entities)
                _entity.Remove(entity);
        }

        public async Task<int> CommitChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
