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
        public Inventory inventory;
        public Wallet wallet;
        public Recipe recipe;
        public Pitcher pitcher;


        //Player Constructor
        public Player()
        {
             inventory = new Inventory();
             wallet = new Wallet();
             recipe = new Recipe();
             pitcher = new Pitcher();
        }
        //member method
    }
         //Instantiating Classes
        
}

