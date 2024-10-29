using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class CartReadRepository: ReadRepository<Cart>,ICartReadRepository
    {
        public CartReadRepository(BitirmeETicaretDBContext context):base(context) { }
    }
}
