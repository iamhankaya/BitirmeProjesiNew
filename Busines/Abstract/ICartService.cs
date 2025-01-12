using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Busines.Abstract
{
    public interface ICartService:IBaseBusinessService<Cart>
    {
        Task<IResult> AddProductToCart(int cartId,Product product);
        Task<IResult> DeleteProductFromCart(int cartId, Product product);
    }

}
