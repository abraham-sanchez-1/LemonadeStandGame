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
            amountOfSugarCubes = 5;
            amountOfIceCubes = 8;
            //in an ideal world, a free lemonade is the best lemonade and therefore recipe is set to zero
            pricePerCup = 0;
        }
    }
}
