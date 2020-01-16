using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Day
    {
        //member variable
        public Weather weather;
        public List<Customer> customers;

        //constructor

        public Day()
        {
            weather = new Weather();
            customers = new List<Customer>();
        }

        //member methods
    }
}
