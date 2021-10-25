using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UserMedication.Repositories
{
    public interface IGenericRepository<T> where T:class
    {
        Task<T> Get(int id);

        Task<IEnumerable<T>> GetAll();

        Task<bool> Add(T entity);

        Task<bool> DeactivateUser(int Id);

        Task<bool> Update(T entity);

       

    }
}
