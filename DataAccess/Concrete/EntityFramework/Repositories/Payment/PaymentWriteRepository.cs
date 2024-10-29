using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class PaymentWriteRepository : WriteRepository<Payment>, IPaymentWriteRepository
    {
        public PaymentWriteRepository(BitirmeETicaretDBContext context) : base(context) { }
    }
}
