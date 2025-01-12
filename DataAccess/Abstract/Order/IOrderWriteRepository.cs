using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IOrderWriteRepository : IWriteRepository<Order>
    {
        void CreateOrder(Order order);
    }
}
