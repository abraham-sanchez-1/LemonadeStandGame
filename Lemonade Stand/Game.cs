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
        private int currentDay = 1;

        //constructor
        public Game()
        {
            player = new Player("Bobby");
            days = new List<Day>();
            currentDay = 1;
        }

        //member method
        public void NewGame()
        {
            int userSelectedDayAmount = SelectDays();
            while (currentDay < userSelectedDayAmount || player.wallet.Money < 1)
            {
                
                StoreVisit();
            }
        }
        public int SelectDays()
        {
            Console.WriteLine("Please select\n 7\n14\n30");
            int userInput = Convert.ToInt32(Console.ReadLine());
            switch (userInput)
            {
                case 7:
                    userInput = 7;
                    return userInput;
                case 14:
                    userInput = 14;
                    return userInput;
                case 30:
                    userInput = 30;
                    return userInput;
                default:
                    Console.WriteLine("User input incorrect");
                    SelectDays();
                    return userInput;

            }
                

            //Choose number of days

        }
        public void StoreVisit()
        {
            //GO to store
        }
        
        public void SimulateDay()
        {

        }
        public void SalesSummary()
        {
            //end of round
        }

        

    }
}
