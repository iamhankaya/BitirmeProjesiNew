using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Busines.Abstract
{
    public interface IOrderService : IBaseBusinessService<Order>
    {
        Task<IResult> CreateOrder(Order order);
    }

}
