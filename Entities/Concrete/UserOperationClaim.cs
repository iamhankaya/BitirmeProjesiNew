using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserOperationClaim : BaseEntity
    {
        public int userId { get; set; }
        public int operationClaimId { get; set; }
    }
}
