using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.CreditCard
{
    public class CreditCardDTO
    {
        public int id { get; set; }
        public int creditCardNumber { get; set; }
        public float creditAmount { get; set; }

        public string creditCardType { get; set; }

        public int userId { get; set; }
        public string userName { get; set; }
    }
}
