using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Product
{
    public class ProductDTO
    {
        public int id { get; set; }
        public int categoryId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int stockQuantity { get; set; }
        public float price { get; set; }
        public int sellerId { get; set; }
        public string sellerName { get; set; }
        public float reviewPoint { get; set; }
    }
}
