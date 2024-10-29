using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Payment : BaseEntity
    {

        public int orderId { get; set; }
        public int userId { get; set; }
        public int creditCardId { get; set; }
        public float amount { get; set; }
        public DateTime paymentDate { get; set; }

    }
}
