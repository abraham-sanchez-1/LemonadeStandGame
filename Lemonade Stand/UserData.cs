using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class UserData
    {
        public UserData(string username, double cash)
        {
            Username = username;
            Cash = cash;
        }

        public string Username { get; set; }
        public double Cash { get; set; }
    }
}
