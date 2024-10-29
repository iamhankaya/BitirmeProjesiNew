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
    public class ReviewManager : IReviewService
    {
        private readonly IReviewReadRepository _reviewReadRepository;
        private readonly IReviewWriteRepository _reviewWriteRepository;

        public ReviewManager(IReviewReadRepository reviewReadRepository, IReviewWriteRepository reviewWriteRepository)
        {
            _reviewReadRepository = reviewReadRepository;
            _reviewWriteRepository = reviewWriteRepository;
        }

        public Task<IResult> AddAsync(Review entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> AddRangeAsync(List<Review> entities)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Review entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteRange(List<Review> entities)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Review>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Review>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Review>> GetSingleAsync(Expression<Func<Review, bool>> method)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Review>> GetWhere(Expression<Func<Review, bool>> method)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(Review entity)
        {
            throw new NotImplementedException();
        }
    }
}
