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
        private Store store; 

        private List<Day> days;
        
        private int currentDay = 1;

        //constructor
        public Game()
        {
            player = new Player("Bobby");
            store = new Store();
            days = new List<Day>();
            currentDay = 0;
        }

        //Begin New Game
        public void NewGame()
        {
            Console.WriteLine("WELCOME TO LEMONADE STAND! (PROTOTYPE)");
            Console.WriteLine("This is a developer build and does not represent final product..");
            int userSelectedDayAmount = SelectDays();
            while (currentDay < userSelectedDayAmount || player.wallet.Money < 1.00)
            {
                StoreVisit();
                SimulateDay();
                SalesSummary();
                currentDay++; 
            }
        }

        public int SelectDays()
        {
            Console.WriteLine("How many days would you like to play?\n(7)\n(14)\n(30)");
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
                    Console.WriteLine("Cannot Negate User Input!");
                    Console.Clear();
                    SelectDays();
                    return userInput;
            }
        }

        public void StoreVisit()
        {
            //Going to the store
            Console.WriteLine("*************************");
            Console.WriteLine("* WELCOME TO YOUR STORE *");
            Console.WriteLine("*************************");
            Console.WriteLine("*                       *");
            Console.WriteLine("*1.) 5 LEMONS $2.50     *");
            Console.WriteLine("*                       *");
            Console.WriteLine("*2.) 5 SUGAR CUBES $1.50*");
            Console.WriteLine("*                       *");
            Console.WriteLine("*3.) 5 ICE CUBES 2.50   *");
            Console.WriteLine("*                       *");
            Console.WriteLine("*4.) 5 CUPS 5.00        *");
            Console.WriteLine("*                       *");
            Console.WriteLine("*5.) EXIT STORE         *");
            Console.WriteLine("*                       *");
            Console.WriteLine("*************************");
            int userInput = Convert.ToInt32(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    for (int i = 0; i < 5; i++)
                    {
                        player.inventory.lemons.Add(new Lemon());
                    }
                    player.wallet.Money -= 2.50;
                    StoreVisit();
                    break;
                case 2:
                    for (int i = 0; i < 5; i++)
                    {
                        player.inventory.sugarCubes.Add(new SugarCube());
                    }
                    player.wallet.Money -= 1.50;
                    StoreVisit();
                    break;
                case 3:
                    for (int i = 0; i < 5; i++)
                    {
                        player.inventory.iceCubes.Add(new IceCube());
                    }
                    player.wallet.Money -= 2.50;
                    StoreVisit();
                    break;
                case 4:
                    for (int i = 0; i < 5; i++)
                    {
                        player.inventory.cups.Add(new Cup());
                    }
                    player.wallet.Money -= 5.00;
                    StoreVisit();
                    break;
                case 5:
                    Console.WriteLine("Thank you for visiting the store!");
                    Console.ReadLine();
                    Console.Clear();
                    break;
            }
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
