using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busines.Abstract
{
    public interface IUserService : IBaseBusinessService<User>
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
    }

}
