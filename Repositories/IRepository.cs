using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicStudyMediatR.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(int id);

        Task<T> Add(T item);

        Task<T> Edit(T item);

        Task<bool> Delete(int id);
    }
}