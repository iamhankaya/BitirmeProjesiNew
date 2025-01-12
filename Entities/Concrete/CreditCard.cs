using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CreditCard : BaseEntity
    {

        public int creditCardNumber { get; set; }
        public int creditCardPassword { get; set; }

        public int cvc { get; set; }
        public float creditAmount { get; set; }

        public string creditCardType { get; set; }

        public int userId { get; set; }

    }
}
