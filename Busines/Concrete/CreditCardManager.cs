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
    public class CreditCardManager : ICreditCardService
    {
        private readonly ICreditCardReadRepository _creditCardReadRepository;
        private readonly ICreditCardWriteRepository _creditCardWriteRepository;

        public CreditCardManager(ICreditCardReadRepository creditCardReadRepository, ICreditCardWriteRepository creditCardWriteRepository)
        {
            _creditCardReadRepository = creditCardReadRepository;
            _creditCardWriteRepository = creditCardWriteRepository;
        }

        public async Task<IResult> AddAsync(CreditCard entity)
        {
            var result = await _creditCardWriteRepository.AddAsync(entity);
            await _creditCardWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.AddedSuccesfully);
            return new ErrorResult(Messages.Error);
        }

        public async Task<IResult> AddRangeAsync(List<CreditCard> entities)
        {
            var result = await _creditCardWriteRepository.AddRangeAsync(entities);
            await _creditCardWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.AddedSuccesfully);
            return new ErrorResult(Messages.Error);
        }

        public async Task<IResult> Delete(CreditCard entity)
        {
            var result =  _creditCardWriteRepository.Delete(entity);
            await _creditCardWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.DeletedSuccessfully);
            return new ErrorResult(Messages.Error);
        }

        public async Task<IResult> Delete(int id)
        {
            var result = await _creditCardWriteRepository.Delete(id);
            await _creditCardWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.DeletedSuccessfully);
            return new ErrorResult(Messages.Error);
        }

        public async Task<IResult> DeleteRange(List<CreditCard> entities)
        {
            var result = _creditCardWriteRepository.DeleteRange(entities);
            await _creditCardWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.DeletedSuccessfully);
            return new ErrorResult(Messages.Error);
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            var result = _creditCardReadRepository.GetAll();
            return new SuccessDataResult<List<CreditCard>>(result.ToList());
        }

        public async Task<IDataResult<CreditCard>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<CreditCard>(await _creditCardReadRepository.GetByIdAsync(id));
        }

        public async Task<IDataResult<CreditCard>> GetSingleAsync(Expression<Func<CreditCard, bool>> method)
        {
            return new SuccessDataResult<CreditCard>(await _creditCardReadRepository.GetSingleAsync(method));
        }

        public IDataResult<List<CreditCard>> GetWhere(Expression<Func<CreditCard, bool>> method)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardReadRepository.GetWhere(method).ToList());
        }

        

        public async Task<IResult> Update(CreditCard entity)
        {
            var result = _creditCardWriteRepository.Update(entity);
            await _creditCardWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.UpdatedSuccessfully);
            return new ErrorResult(Messages.Error);
        }
    }
}
