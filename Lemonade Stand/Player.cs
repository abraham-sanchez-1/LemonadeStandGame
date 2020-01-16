using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Player
    {
        //Declaring Variables
        public string Name;

        //Player Constructor
        public Player(string Name)
        {
            this.Name = Name;

         //Instantiating Classes
         Inventory inventory = new Inventory();
         Wallet wallet = new Wallet();
         Recipe recipe = new Recipe();
         Pitcher pitcher = new Pitcher();
    }
}
}
