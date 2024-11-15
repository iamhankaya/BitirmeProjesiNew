using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Order : BaseEntity
    {

        public int userId { get; set; }
        [JsonIgnore]
        public List<Product> products { get; set; } = new List<Product>();
        public float totalAmount { get; set; }
        public DateTime orderDate { get; set; }
        public string address { get; set; }

    }
}
