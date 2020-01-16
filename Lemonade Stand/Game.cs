using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Game
    {
        //member variable
        private Player player;
        private List<Day> days;
        private int currentDay;

        //constructor
        public Game()
        {
            player = new Player("Bobby");
            days = new List<Day>();
            currentDay = 1;
        }

        //member method

    }
}
