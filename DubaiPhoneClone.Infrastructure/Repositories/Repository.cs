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

        public bool Create(T entity)
        {
            try
            {
                DbSetEntity.Add(entity);
                _appContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                DbSetEntity.Remove(entity);
                _appContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
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

        public bool Update(T entity)
        {
            try
            {
                DbSetEntity.Update(entity);
                _appContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
