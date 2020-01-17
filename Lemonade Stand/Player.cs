using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    public class Player
    {
        //Declaring Variables
        public string name;
        public Inventory inventory;
        public Wallet wallet;
        public Recipe recipe;
        public Pitcher pitcher;


        //Player Constructor
        public Player(string name)
        {
             this.name = name;
             inventory = new Inventory();
             wallet = new Wallet();
             recipe = new Recipe();
             pitcher = new Pitcher();
        }
        //member method

    }
         //Instantiating Classes
        
}

