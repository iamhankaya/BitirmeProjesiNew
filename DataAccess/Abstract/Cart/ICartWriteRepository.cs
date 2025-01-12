using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICartWriteRepository : IWriteRepository<Cart>
    {
        Cart AddProductToCartAsync(int cartId);
        Cart DeleteProductFromCartAsync(int cartId,int productId);
    }
}
