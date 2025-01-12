using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Review
{
    public class ReviewDTO
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public int userId { get; set; }
        public string userName { get; set; }
        public int rating { get; set; }
        public string comment { get; set; }
    }
}
