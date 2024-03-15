using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Context;
using Microsoft.EntityFrameworkCore;

namespace DubaiPhoneClone.Infrastructure.Repositories
{
    public class Repository<T, TId> : IRepository<T, TId> where T : class
    {
        private readonly ApplicationContext _appContext;
        DbSet<T> DbSetEntity;


        public Repository(ApplicationContext applicationContext)
        {
            this._appContext = applicationContext;
            DbSetEntity = _appContext.Set<T>();
        }

        public T Create(T entity)
        {

            DbSetEntity.Add(entity);
            _appContext.SaveChanges();

            return entity;


        }

        public T Delete(TId id)
        {
            var entity = DbSetEntity.Find(id);
            DbSetEntity.Remove(entity);
            _appContext.SaveChanges();

            return entity;


        }

        public IQueryable<T> GetAll()
        {
            return DbSetEntity;
        }

        public T GetById(TId id)
        {

            return DbSetEntity.Find(id);
        }

        public int Save()
        {
            return _appContext.SaveChanges();
        }

        public T Update(T entity)
        {

            DbSetEntity.Update(entity);
            _appContext.SaveChanges();

            return entity;

        }
    }
}
