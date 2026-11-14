using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCreater.Models
{
    internal class UserModel
    {
        public int id { get; set; }
        public string type { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
