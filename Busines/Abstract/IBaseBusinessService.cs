using Core.Utilities.Results;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBaseBusinessService<T> where T : BaseEntity
    {
        IDataResult<List<T>> GetAll();
        IDataResult<List<T>> GetWhere(Expression<Func<T, bool>> method);
        Task<IDataResult<T>> GetSingleAsync(Expression<Func<T, bool>> method);
        Task<IDataResult<T>> GetByIdAsync(int id);
        Task<IResult> AddAsync(T entity);
        Task<IResult> AddRangeAsync(List<T> entities);
        Task<IResult> Delete (T entity);
        Task<IResult> Delete(int id);
        Task<IResult> DeleteRange (List<T> entities);
        Task<IResult> Update (T entity);
      

    }
}
