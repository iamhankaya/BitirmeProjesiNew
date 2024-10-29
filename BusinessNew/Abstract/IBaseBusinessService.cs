using Core.Utilities.Results;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBaseBusinessService<T> where T : BaseEntity
    {
        IDataResult<T> GetAll();
        IDataResult<T> GetWhere();
        IDataResult<T> GetSingleAsync();
        IDataResult<T> GetByIdAsync(int id);
        IResult AddAsync(T entity);
        IResult AddRangeAsync(List<T> entities);
        IResult Delete (T entity);
        IResult Delete(int id);
        IResult DeleteRange (List<T> entities);
        IResult Update (T entity);
        IResult SaveAsync();

    }
}
