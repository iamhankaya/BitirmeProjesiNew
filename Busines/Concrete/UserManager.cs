using Busines.Abstract;
using Busines.Constan;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Busines.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;

        public UserManager(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
        }

        public async Task<IResult> AddAsync(User entity)
        {
            var result = await _userWriteRepository.AddAsync(entity);
            await _userWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.AddedSuccesfully);
            return new ErrorResult(Messages.Error);
        }

        public async Task<IResult> AddRangeAsync(List<User> entities)
        {
            var result = await _userWriteRepository.AddRangeAsync(entities);
            await _userWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.AddedSuccesfully);
            return new ErrorResult(Messages.Error);
        }

        public async Task<IResult> Delete(User entity)
        {
            var result =_userWriteRepository.Delete(entity);
            await _userWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.DeletedSuccessfully);
            return new ErrorResult(Messages.Error);
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var result = await _userWriteRepository.Delete(id);
            await _userWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.DeletedSuccessfully);
            return new ErrorResult(Messages.Error);
        }

        public async Task<IResult> DeleteRange(List<User> entities)
        {
            var result = _userWriteRepository.DeleteRange(entities);
            await _userWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.DeletedSuccessfully);
            return new ErrorResult(Messages.Error);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userReadRepository.GetAll().ToList());
        }

        public async Task<IDataResult<User>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<User>(await _userReadRepository.GetByIdAsync(id));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userReadRepository.GetOperationClaims(user);
            return new SuccessDataResult<List<OperationClaim>>(result);
        }

        public async Task<IDataResult<User>> GetSingleAsync(Expression<Func<User, bool>> method)
        {
            return new SuccessDataResult<User>(await _userReadRepository.GetSingleAsync(method));
        }

        public IDataResult<List<User>> GetWhere(Expression<Func<User, bool>> method)
        {
            return new SuccessDataResult<List<User>>(_userReadRepository.GetWhere(method).ToList());
        }

        public async Task<IResult> Update(User entity)
        {
            var result = _userWriteRepository.Update(entity);
            await _userWriteRepository.SaveAsync();
            if (result)
                return new SuccessResult(Messages.UpdatedSuccessfully);
            return new ErrorResult(Messages.Error);
        }
    }
}
