﻿using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserReadRepository : IReadRepository<User>
    {
        List<OperationClaim> GetOperationClaims(User user);
    }
}
