﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CartProduct
    {
        public int cartId { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
    }
}
