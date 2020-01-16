using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Inventory
    {
        //member variables
        public List<Lemon> lemons;
        public List<IceCube> iceCubes;
        public List<Cup> cups;
        public List<SugarCube> sugarCubes;

        //constructor
        public Inventory()
        {
            lemons = new List<Lemon>() {new Lemon(), new Lemon(), new Lemon()};
            iceCubes = new List<IceCube>() { new IceCube(), new IceCube(), new IceCube() };
            sugarCubes = new List<SugarCube>() { new SugarCube(), new SugarCube(), new SugarCube() };
            cups = new List<Cup>() { new Cup(), new Cup(), new Cup(), new Cup(), new Cup() };

        }

        //member methods


    }
}
