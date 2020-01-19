using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    public class Customer
    {
        //Declaring Public Variables
        public string name;
        public int reputation = 100, tasteScore; 

        Random tasteScoreRandom = new Random(); 

        //Public Customer Constructor Sets Name, and Randomizes Taste Score
        public Customer(string name)
        {
            this.name = name;
            tasteScore = tasteScoreRandom.Next(20, 90);
        }


    }
}
