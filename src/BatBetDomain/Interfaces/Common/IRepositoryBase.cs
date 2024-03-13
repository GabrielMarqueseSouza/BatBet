using System.Collections.Generic;
using System.Threading.Tasks;

namespace BatBetDomain.Interfaces.Common
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<IList<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> FindAsNoTracking(int id);
        Task Add(TEntity entity);
        Task RemoveById(int id);
        void Remove(TEntity entity);
        void RemoveInScale(IList<TEntity> entities);
        Task<int> CommitChanges();
    }
}
