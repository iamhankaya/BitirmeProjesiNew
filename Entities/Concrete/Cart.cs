﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Cart : BaseEntity
    {
        public int userId { get; set; }
        public List<Product> products { get; set; }
        public float totalAmount { get; set; }

    }
}
