using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        Task<T> Get(long? id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T model);
        Task Update(T model);
        Task Delete(T model);
        Task<bool> IsExists(long? id);
    }
}
