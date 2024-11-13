using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Review : BaseEntity
    {

        public int productId { get; set; }
        public int userId { get; set; }
        public int rating { get; set; }
        public string comment { get; set; }

    }
}
