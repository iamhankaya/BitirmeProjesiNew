using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        private readonly BitirmeETicaretDBContext _context;
        public OrderReadRepository(BitirmeETicaretDBContext context) : base(context)
        {
            _context = context;
        }

        public DbSet<Order> Orders => _context.Set<Order>();
        public DbSet<Product> Products => _context.Set<Product>();

        public async Task<Order> GetOrderWithProductsAsync(int orderId)
        {
            var order = await _context.Orders
                .Include(c => c.products)  // Cart ile ilişkili CartProduct kayıtlarını al
                                           // CartProduct üzerinden Product nesnelerini al
                .FirstOrDefaultAsync(c => c.id == orderId);

            return order;
        }
    }
}
