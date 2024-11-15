using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class CartReadRepository: ReadRepository<Cart>,ICartReadRepository
    {
        private readonly BitirmeETicaretDBContext _context;
        public CartReadRepository(BitirmeETicaretDBContext context):base(context)
        {
            _context = context;
        }

        public DbSet<Cart> Carts => _context.Set<Cart>();
        public DbSet<Product> Products => _context.Set<Product>();

        public async Task<Cart> GetCartWithProductsAsync(int cartId)
        {
            var cart = await _context.Carts
                .Include(c => c.products)  // Cart ile ilişkili CartProduct kayıtlarını al
                  // CartProduct üzerinden Product nesnelerini al
                .FirstOrDefaultAsync(c => c.id == cartId);

            return cart;
        }
    }
}
