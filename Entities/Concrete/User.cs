using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User : BaseEntity
    {

        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }
        public bool status { get; set; }

    }
}
