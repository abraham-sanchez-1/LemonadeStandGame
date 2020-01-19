using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{

    public class Recipe
    {
        //Declaring Public Integer Variables
        public int amountOfLemons, amountOfSugarCubes, amountOfIceCubes, pricePerCup; 

        //Public Recipe Constructor
        public Recipe()
        {
            amountOfLemons = 3;
            amountOfSugarCubes = 6;
            amountOfIceCubes = 12;
            pricePerCup = 2;
        }
    }
}
