using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        private readonly BitirmeETicaretDBContext _context;
        public OrderWriteRepository(BitirmeETicaretDBContext context) : base(context) { 
            _context = context;
        }

        public DbSet<Order> Orders => _context.Set<Order>();
        public DbSet<Product> Products => _context.Set<Product>();

        public void CreateOrder(Order order)
        {
            foreach (var product in order.products)
            {
                _context.Products.Attach(product);
            }
        }
    }
}
