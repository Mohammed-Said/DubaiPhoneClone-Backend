using System.Collections.Generic;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.Contracts
{
    public interface IRepository<T, TId>
    {
         Task<IQueryable<T>> GetAll();
        Task<T> GetById(TId id);

        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(TId id);
        Task<int> Save();
    }
}
