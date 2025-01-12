using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.User
{
    public class UserDTO
    {
        public string name { get; set; }
        public string surname { get; set; }
        //public string adress { get; set; }
        public string email { get; set; }
        public bool status { get; set; }
    }
}
