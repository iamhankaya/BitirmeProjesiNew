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
    public class CreditCardManager : ICreditCardService
    {
        private readonly ICreditCardReadRepository _creditCardReadRepository;
        private readonly ICreditCardWriteRepository _creditCardWriteRepository;

        public CreditCardManager(ICreditCardReadRepository creditCardReadRepository, ICreditCardWriteRepository creditCardWriteRepository)
        {
            _creditCardReadRepository = creditCardReadRepository;
            _creditCardWriteRepository = creditCardWriteRepository;
        }

        public Task<IResult> AddAsync(CreditCard entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> AddRangeAsync(List<CreditCard> entities)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(CreditCard entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteRange(List<CreditCard> entities)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CreditCard>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CreditCard>> GetSingleAsync(Expression<Func<CreditCard, bool>> method)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CreditCard>> GetWhere(Expression<Func<CreditCard, bool>> method)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(CreditCard entity)
        {
            throw new NotImplementedException();
        }
    }
}
