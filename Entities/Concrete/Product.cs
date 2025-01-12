using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product : BaseEntity
    {

        public int categoryId { get; set; }
        [JsonIgnore]
        public List<Order>? orders { get; set; } = new List<Order>();
        
        [JsonIgnore]
        public List<Cart> carts { get; set; } = new List<Cart>();
        public string name { get; set; }
        public string description { get; set; }
        public int stockQuantity { get; set; }
        public float price { get; set; }
        public int sellerId { get; set; }
        public float reviewPoint { get; set; }
    }
}
