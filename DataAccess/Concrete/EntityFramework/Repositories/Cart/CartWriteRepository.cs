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
    public class CartWriteRepository : WriteRepository<Cart>, ICartWriteRepository
    {
        private readonly BitirmeETicaretDBContext _context;
        public CartWriteRepository(BitirmeETicaretDBContext context) : base(context)
        {
            _context = context;
        }
        public DbSet<Cart> Carts => _context.Set<Cart>();
        public DbSet<Product> Products => _context.Set<Product>();
        public DbSet<CartProduct> CartProducts => _context.Set<CartProduct>();

        public Cart AddProductToCartAsync(int cartId)
        {
            var cart = _context.Carts.Include(c => c.products)
                              .FirstOrDefault(c => c.id == cartId);
            if(cart != null)
            {
                foreach (var existingProduct in cart.products)
                {
                    _context.Entry(existingProduct).State = EntityState.Unchanged;
                }
                return cart;
            }
            return cart;
        }

        public Cart DeleteProductFromCartAsync(int cartId ,int productId)
        {
            var cart = _context.Carts.Include(c => c.products)
                              .FirstOrDefault(c => c.id == cartId);
            if(cart != null)
            {
                foreach(var product in cart.products)
                {
                    if(product.id == productId)
                    {
                        _context.Entry(product).State = EntityState.Deleted;
                    }
                }
                return cart;
            }
            return cart;
        }
    }
}
