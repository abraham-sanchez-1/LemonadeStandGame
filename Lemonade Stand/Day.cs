using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    public class Day
    {
        //Public Declaration of Variables 
        public Weather weather;
        public List<Customer> customers;

        //Public Constructor Creating New Weather and New Customer List
        public Day()
        {
            weather = new Weather();
            customers = new List<Customer>();
        }
    }
}
