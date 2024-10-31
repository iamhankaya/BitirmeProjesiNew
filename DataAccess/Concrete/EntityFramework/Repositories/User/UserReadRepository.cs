using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        private readonly BitirmeETicaretDBContext _context;
        public UserReadRepository(BitirmeETicaretDBContext context) : base(context) 
        {
            _context = context;
        }

        public List<OperationClaim> GetOperationClaims(User user)
        { 
                   var result = from operationClaim in _context.OperationClaims
                                join userOperationClaim in _context.UserOperationClaims
                                    on operationClaim.id equals userOperationClaim.operationClaimId
                                where userOperationClaim.userId == user.id
                                select new OperationClaim { id = operationClaim.id, Name = operationClaim.Name };
                   return result.ToList();   
        }
    }
}
