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
    public class ReviewManager : IReviewService
    {
        private readonly IReviewReadRepository _reviewReadRepository;
        private readonly IReviewWriteRepository _reviewWriteRepository;

        public ReviewManager(IReviewReadRepository reviewReadRepository, IReviewWriteRepository reviewWriteRepository)
        {
            _reviewReadRepository = reviewReadRepository;
            _reviewWriteRepository = reviewWriteRepository;
        }

        public async Task<IResult> AddAsync(Review entity)
        {
            var result = await _reviewWriteRepository.AddAsync(entity);
            await _reviewWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.AddedSuccesfully);
            return new ErrorResult(Messages.Error);

        }

        public async Task<IResult> AddRangeAsync(List<Review> entities)
        {
            var result = await _reviewWriteRepository.AddRangeAsync(entities);
            await _reviewWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.AddedSuccesfully);
            return new ErrorResult(Messages.Error);
        }

        public async Task<IResult> Delete(Review entity)
        {
            var result =_reviewWriteRepository.Delete(entity);
            await _reviewWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.DeletedSuccessfully);
            return new ErrorResult(Messages.Error);
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var result = await _reviewWriteRepository.Delete(id);
            await _reviewWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.DeletedSuccessfully);
            return new ErrorResult(Messages.Error);
        }

        public async Task<IResult> DeleteRange(List<Review> entities)
        {
            var result = _reviewWriteRepository.DeleteRange(entities);
            await _reviewWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.DeletedSuccessfully);
            return new ErrorResult(Messages.Error);
        }

        public IDataResult<List<Review>> GetAll()
        {
            return new SuccessDataResult<List<Review>>(_reviewReadRepository.GetAll().ToList());
        }

        public async Task<IDataResult<Review>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<Review>(await _reviewReadRepository.GetByIdAsync(id));
        }

        public async Task<IDataResult<Review>> GetSingleAsync(Expression<Func<Review, bool>> method)
        {
            return new SuccessDataResult<Review>(await _reviewReadRepository.GetSingleAsync(method));
        }

        public IDataResult<List<Review>> GetWhere(Expression<Func<Review, bool>> method)
        {
            return new SuccessDataResult<List<Review>>(_reviewReadRepository.GetWhere(method).ToList());
        }
        public async Task<IResult> Update(Review entity)
        {
            var result =_reviewWriteRepository.Update(entity);
            await _reviewWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.UpdatedSuccessfully);
            return new ErrorResult(Messages.Error);
        }
    }
}
