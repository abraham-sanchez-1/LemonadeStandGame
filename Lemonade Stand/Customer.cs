using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Customer
    {
        //Declaring Variables
        public string name;
        public int reputation = 100;
        public int tasteScore;

        Random tasteScoreRandom = new Random(); 

        //Customer Constructor
        public Customer(string name)
        {
            this.name = name;
            tasteScore = tasteScoreRandom.Next(20, 90);
        }


    }
}
