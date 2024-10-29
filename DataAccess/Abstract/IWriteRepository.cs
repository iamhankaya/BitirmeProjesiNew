using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> model);
        bool Delete(T model);
        bool DeleteRange(List<T> model);
        Task<bool> Delete(int id);
        bool Update(T model);
        Task<int> SaveAsync();

    }
}
