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
    public class OrderManager : IOrderService
    {
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;

        public OrderManager(IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository)
        {
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
        }

        public Task<IResult> AddAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> AddRangeAsync(List<Order> entities)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteRange(List<Order> entities)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Order>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Order>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Order>> GetSingleAsync(Expression<Func<Order, bool>> method)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Order>> GetWhere(Expression<Func<Order, bool>> method)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
