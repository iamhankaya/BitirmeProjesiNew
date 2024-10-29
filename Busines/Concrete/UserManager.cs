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
    public class UserManager : IUserService
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;

        public UserManager(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
        }

        public Task<IResult> AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> AddRangeAsync(List<User> entities)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteRange(List<User> entities)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<User>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<User>> GetSingleAsync(Expression<Func<User, bool>> method)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetWhere(Expression<Func<User, bool>> method)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
