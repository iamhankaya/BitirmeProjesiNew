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
    public class CartManager : ICartService
    {
        private readonly ICartReadRepository _cartReadRepository;
        private readonly ICartWriteRepository _cartWriteRepository;

        public CartManager(ICartReadRepository cartReadRepository, ICartWriteRepository cartWriteRepository)
        {
            _cartReadRepository = cartReadRepository;
            _cartWriteRepository = cartWriteRepository;
        }

        public Task<IResult> AddAsync(Cart entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> AddRangeAsync(List<Cart> entities)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Cart entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteRange(List<Cart> entities)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Cart>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Cart>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Cart>> GetSingleAsync(Expression<Func<Cart, bool>> method)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Cart>> GetWhere(Expression<Func<Cart, bool>> method)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> Update(Cart entity)
        {
            throw new NotImplementedException();
        }
    }
}
