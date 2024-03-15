namespace DubaiPhoneClone.Application.Contracts
{
    public interface IRepository<T, TId>
    {
        IQueryable<T> GetAll();
        T GetById(TId id);

        T Create(T entity);
        T Update(T entity);
        T Delete(TId id);
        int Save();
    }
}
