using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CartProduct
    {
        public int cartsId { get; set; }
        public int productsId { get; set; }
        public int count { get; set; }
        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
