using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class CreditCardWriteRepository : WriteRepository<CreditCard>, ICreditCardWriteRepository
    {
        public CreditCardWriteRepository(BitirmeETicaretDBContext context) : base(context) { }
    }
}
