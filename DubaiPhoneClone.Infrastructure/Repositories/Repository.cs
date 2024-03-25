using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Context;
using Microsoft.EntityFrameworkCore;

namespace DubaiPhoneClone.Infrastructure.Repositories
{
    public class Repository<T, TId> : IRepository<T, TId> where T : class
    {
        private readonly ApplicationContext _appContext;
        protected   DbSet<T> DbSetEntity;


        public Repository(ApplicationContext applicationContext)
        {
            this._appContext = applicationContext;
            DbSetEntity = _appContext.Set<T>();
        }

        public async Task<T> Create(T entity)
        {

           var ent=await DbSetEntity.AddAsync(entity);
           //await _appContext.SaveChangesAsync();

            return ent.Entity;


        }

        public async Task<T> Delete(TId id)
        {
            var entity = await DbSetEntity.FindAsync(id);
            var  y=DbSetEntity.Remove(entity);
            //await _appContext.SaveChangesAsync();

            return y.Entity;


        }

         public async Task<IQueryable<T>> GetAll()
        {
            return DbSetEntity;
        }

        public async Task<T> GetById(TId id)
        {

            return await DbSetEntity.FindAsync(id);
        }

        public async Task<int> Save()
        {
            return await _appContext.SaveChangesAsync();
        }

        public async Task<T> Update(T entity)
        {

            var x=DbSetEntity.Update(entity);
            //await _appContext.SaveChangesAsync();

            return x.Entity;

        }
    }
}
