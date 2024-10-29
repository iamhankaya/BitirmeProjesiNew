using Busines.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Busines.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly ICategoryWriteRepository _categoryWriteRepository;

        public CategoryManager(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository)
        {
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
        }

        public Task<IResult> AddAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> AddRangeAsync(List<Category> entities)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteRange(List<Category> entities)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Category>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Category>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Category>> GetSingleAsync(Expression<Func<Category, bool>> method)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Category>> GetWhere(Expression<Func<Category, bool>> method)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
