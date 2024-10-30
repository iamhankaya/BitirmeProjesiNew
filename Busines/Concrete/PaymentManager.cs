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
    public class PaymentManager : IPaymentService
    {
        private readonly IPaymentReadRepository _paymentReadRepository;
        private readonly IPaymentWriteRepository _paymentWriteRepository;

        public PaymentManager(IPaymentReadRepository paymentReadRepository, IPaymentWriteRepository paymentWriteRepository)
        {
            _paymentReadRepository = paymentReadRepository;
            _paymentWriteRepository = paymentWriteRepository;
        }

        public async Task<IResult> AddAsync(Payment entity)
        {
            var result = await _paymentWriteRepository.AddAsync(entity);
            await _paymentWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.AddedSuccesfully);
            return new ErrorResult(Messages.Error); 
        }

        public async Task<IResult> AddRangeAsync(List<Payment> entities)
        {
            var result = await _paymentWriteRepository.AddRangeAsync(entities);
            await _paymentWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.AddedSuccesfully);
            return new ErrorResult(Messages.Error);
        }

        public async Task<IResult> Delete(Payment entity)
        {
            var result =  _paymentWriteRepository.Delete(entity);
            await _paymentWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.DeletedSuccessfully);
            return new ErrorResult(Messages.Error);
        }

        public async Task<IResult> Delete(int id)
        {
            var result = await _paymentWriteRepository.Delete(id);
            await _paymentWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.DeletedSuccessfully);
            return new ErrorResult(Messages.Error);
        }

        public async Task<IResult> DeleteRange(List<Payment> entities)
        {
            var result = _paymentWriteRepository.DeleteRange(entities);
            await _paymentWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.DeletedSuccessfully);
            return new ErrorResult(Messages.Error);
        }

        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentReadRepository.GetAll().ToList());
        }

        public async Task<IDataResult<Payment>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<Payment>(await _paymentReadRepository.GetByIdAsync(id));
        }

        public async Task<IDataResult<Payment>> GetSingleAsync(Expression<Func<Payment, bool>> method)
        {
            return new SuccessDataResult<Payment>(await _paymentReadRepository.GetSingleAsync(method));
        }

        public IDataResult<List<Payment>> GetWhere(Expression<Func<Payment, bool>> method)
        {
            return new SuccessDataResult<List<Payment>>(_paymentReadRepository.GetWhere(method).ToList());
        }

        public Task<IResult> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> Update(Payment entity)
        {
            var result = _paymentWriteRepository.Update(entity);
            await _paymentWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.UpdatedSuccessfully);
            return new ErrorResult(Messages.Error);
        }
    }
}
