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
    public class PaymentManager : IPaymentService
    {
        private readonly IPaymentReadRepository _paymentReadRepository;
        private readonly IPaymentWriteRepository _paymentWriteRepository;

        public PaymentManager(IPaymentReadRepository paymentReadRepository, IPaymentWriteRepository paymentWriteRepository)
        {
            _paymentReadRepository = paymentReadRepository;
            _paymentWriteRepository = paymentWriteRepository;
        }

        public Task<IResult> AddAsync(Payment entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> AddRangeAsync(List<Payment> entities)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Payment entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteRange(List<Payment> entities)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Payment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Payment>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Payment>> GetSingleAsync(Expression<Func<Payment, bool>> method)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Payment>> GetWhere(Expression<Func<Payment, bool>> method)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(Payment entity)
        {
            throw new NotImplementedException();
        }
    }
}
