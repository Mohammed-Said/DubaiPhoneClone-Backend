namespace DubaiPhoneClone.Application.Contracts
{
    public interface IRepository<T, TId>
    {
        IQueryable<T> GetAll();
        T GetById(TId id);

        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        int Save();
    }
}
