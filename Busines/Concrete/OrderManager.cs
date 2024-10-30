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
    public class OrderManager : IOrderService
    {
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;

        public OrderManager(IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository)
        {
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
        }

        public async Task<IResult> AddAsync(Order entity)
        {
            var result = await _orderWriteRepository.AddAsync(entity);
            await _orderWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.AddedSuccesfully);
            return new ErrorResult(Messages.Error);
        }

        public async Task<IResult> AddRangeAsync(List<Order> entities)
        {
            var result = await _orderWriteRepository.AddRangeAsync(entities);
            await _orderWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.AddedSuccesfully);
            return new ErrorResult(Messages.Error);
        }

        public async Task<IResult> Delete(Order entity)
        {
            var result =  _orderWriteRepository.Delete(entity);
            await _orderWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.DeletedSuccessfully);
            return new ErrorResult(Messages.Error);
        }

        public async Task<IResult> Delete(int id)
        {
            var result = await _orderWriteRepository.Delete(id);
            await _orderWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.DeletedSuccessfully);
            return new ErrorResult(Messages.Error);
        }

        public async Task<IResult> DeleteRange(List<Order> entities)
        {
            var result = _orderWriteRepository.DeleteRange(entities);
            await _orderWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.DeletedSuccessfully);
            return new ErrorResult(Messages.Error);
        }

        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderReadRepository.GetAll().ToList());
        }

        public async Task<IDataResult<Order>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<Order>(await _orderReadRepository.GetByIdAsync(id));
        }

        public async Task<IDataResult<Order>> GetSingleAsync(Expression<Func<Order, bool>> method)
        {
            return new SuccessDataResult<Order>(await _orderReadRepository.GetSingleAsync(method));
        }

        public IDataResult<List<Order>> GetWhere(Expression<Func<Order, bool>> method)
        {
            return new SuccessDataResult<List<Order>>(_orderReadRepository.GetWhere(method).ToList());
        }

        public async Task<IResult> Update(Order entity)
        {
            var result = _orderWriteRepository.Update(entity);
            await _orderWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.UpdatedSuccessfully);
            return new ErrorResult(Messages.Error);
        }
    }
}
