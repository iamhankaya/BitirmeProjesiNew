using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class ReviewReadRepository : ReadRepository<Review>, IReviewReadRepository
    {
        public ReviewReadRepository(BitirmeETicaretDBContext context) : base(context) { }
    }
}
