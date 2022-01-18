using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggerAppBE.Models.Base;

namespace TaggerAppBE.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity: BaseEntity
    {
        // Get all
        Task<List<TEntity>> GetAll();
        IQueryable<TEntity> GetAllAsQueryable();

        //Create
        void Create(TEntity entity);
        Task CreateAsync(TEntity entity);

        void CreateRange(IEnumerable<TEntity> entities);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);

        //update
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        //delete
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);

        //find
        TEntity FindById(object id);
        Task<TEntity> FindByIdAsync(object id);

        //save
        bool Save();
        Task<bool> SaveAsync();
    }
}
