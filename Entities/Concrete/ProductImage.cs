using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ProductImage : BaseEntity
    {
        public int ProductId { get; set; }
        public string ImagePath { get; set; }
    }
}
