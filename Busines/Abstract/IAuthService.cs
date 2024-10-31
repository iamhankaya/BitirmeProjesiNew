using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Security.JWT;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<User>> Register(UserForRegisterDTO userForRegisterDto);
        Task<IDataResult<User>> Login(UserForLoginDTO userForLoginDto);
        Task<IResult> UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
