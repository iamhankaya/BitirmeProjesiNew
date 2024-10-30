using Busines.Abstract;
using Busines.Constan;
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

        public async Task<IResult> AddAsync(Category entity)
        {
            var result = await _categoryWriteRepository.AddAsync(entity);
            await _categoryWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.AddedSuccesfully);
            return new ErrorResult(Messages.Error);
        }

        public async Task<IResult> AddRangeAsync(List<Category> entities)
        {
            var result = await _categoryWriteRepository.AddRangeAsync(entities);
            await _categoryWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.AddedSuccesfully);
            return new ErrorResult(Messages.Error);
        }

        public async Task<IResult> Delete(Category entity)
        {
            var result = _categoryWriteRepository.Delete(entity);
            await _categoryWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.DeletedSuccessfully);
            return new ErrorResult(Messages.Error);
        }

        public async Task<IResult> Delete(int id)
        {
            var result = await _categoryWriteRepository.Delete(id);
            await _categoryWriteRepository.SaveAsync();
            if(result)
                return new SuccessResult(Messages.DeletedSuccessfully);
            return new ErrorResult(Messages.Error);
        }

        public async Task<IResult> DeleteRange(List<Category> entities)
        {
            var result = _categoryWriteRepository.DeleteRange(entities);
            await _categoryWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.DeletedSuccessfully);
            return new ErrorResult(Messages.Error);
        }

        public IDataResult<List<Category>> GetAll()
        {
            var result = _categoryReadRepository.GetAll();
            return new SuccessDataResult<List<Category>>(result.ToList());
        }

        public async Task<IDataResult<Category>> GetByIdAsync(int id)
        {
            var result = await _categoryReadRepository.GetByIdAsync(id);
            return new SuccessDataResult<Category>(result);
        }

        public async Task<IDataResult<Category>> GetSingleAsync(Expression<Func<Category, bool>> method)
        {
            var result = await _categoryReadRepository.GetSingleAsync(method);
            return new SuccessDataResult<Category>(result);
        }

        public IDataResult<List<Category>> GetWhere(Expression<Func<Category, bool>> method)
        {
            var result = _categoryReadRepository.GetWhere(method);
            return new SuccessDataResult<List<Category>>(result.ToList());
        }

        public Task<IResult> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> Update(Category entity)
        {
            var result = _categoryWriteRepository.Update(entity);
            await _categoryWriteRepository.SaveAsync();
            if(result)
                return new SuccessResult(Messages.UpdatedSuccessfully);
            return new ErrorResult(Messages.Error);
        }
    }
}
