using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.DTOs.Product;

namespace Entities.DTOs
{
    public class CartDTO
    {
        public int userId { get; set; }

        public List<ProductDTO> products { get; set; } = new List<ProductDTO>();

        public float totalAmount { get; set; }
    }
}
