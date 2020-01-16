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
                    Console.WriteLine("Selection was invalid, try again!");
                    Console.Clear();
                    SelectDays();
                    return userInput;
            }
        }

        public void StoreVisit()
        {
            //Going to the store
            StoreMenu();
            int userInput = Convert.ToInt32(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    for (int i = 0; i < 5; i++)
                    {
                        player.inventory.lemons.Add(new Lemon());
                    }
                    player.wallet.Money -= 2.50;
                    Console.WriteLine("Your lemon inventory is now at {0}", player.inventory.lemons.Count);
                    Console.WriteLine("Money Left: {0}", player.wallet.Money);
                    StoreVisit();
                    break;
                case 2:
                    for (int i = 0; i < 5; i++)
                    {
                        player.inventory.sugarCubes.Add(new SugarCube());
                    }
                    player.wallet.Money -= 1.50;
                    Console.WriteLine("Your sugar cube inventory is now at {0}", player.inventory.sugarCubes.Count);
                    Console.WriteLine("Money Left: {0}", player.wallet.Money);
                    StoreVisit();
                    break;
                case 3:
                    for (int i = 0; i < 5; i++)
                    {
                        player.inventory.iceCubes.Add(new IceCube());
                    }
                    player.wallet.Money -= 2.50;
                    Console.WriteLine("Your ice cube inventory is now at {0}", player.inventory.iceCubes.Count);
                    Console.WriteLine("Money Left: {0}", player.wallet.Money);
                    StoreVisit();
                    break;
                case 4:
                    for (int i = 0; i < 5; i++)
                    {
                        player.inventory.cups.Add(new Cup());
                    }
                    player.wallet.Money -= 5.00;
                    Console.WriteLine("Your cup inventory is now at {0}", player.inventory.cups.Count);
                    Console.WriteLine("Money Left: {0}", player.wallet.Money);
                    StoreVisit();
                    break;
                case 5:
                    Console.WriteLine("Thank you for visiting the store!");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Selection was invalid, try again!");
                    StoreVisit();
                    break;
            }
        }
        
        public void SimulateDay()
        {
            LemonadeCreation();
        }
        public void SalesSummary()
        {
            //end of round
        }
        public void StoreMenu()
        {
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
        }
        public void LemonadeCreation()
        {
            Console.WriteLine("How many lemons would you like in your lemonade?");
            int lemonPitcherAmount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many sugar cubes would you like in your lemonade?");
            int sugarCubePitcherAmount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many ice cubes would you like in your lemonade?");
            int iceCubePitcherAmount = Convert.ToInt32(Console.ReadLine());
            int lemonFlavorDeviance = Math.Abs(player.recipe.amountOfLemons - lemonPitcherAmount);
            int iceCubeFlavorDeviance = Math.Abs(player.recipe.amountOfIceCubes - iceCubePitcherAmount);
            int sugarCubeFlavorDeviance = Math.Abs(player.recipe.amountOfSugarCubes - sugarCubePitcherAmount);
            player.pitcher.pitcherTasteScore = 50 - AddThreeNumbers(lemonFlavorDeviance, iceCubeFlavorDeviance, sugarCubeFlavorDeviance);
            Console.WriteLine("Your creation yielded a {0} taste score!", player.pitcher.pitcherTasteScore);

        }
        public int AddThreeNumbers(int firstNumber, int secondNumber, int thirdNumber)
        {
            int number1, number2, number3;
            number1 = firstNumber;
            number2 = secondNumber;
            number3 = thirdNumber;
            int total = number1 + number2 + number3;
            return total;

        }
        //public void LemonadeCreationMenu(int index)
        //{
    //      for (int i = 0; i< 4; i++)
    //          {
    //            LemonadeCreationMenu(i);
    //          }
    //    List<string> item = new List<string>() { "lemons","sugarCubes","iceCubes"};
    //    Console.WriteLine("*************************");
    //    Console.WriteLine("* Lemonade Creation Menu *");
    //    Console.WriteLine("*************************");
    //    Console.WriteLine("*                       *");
    //    Console.WriteLine("*   How many {0}     *",player.inventory.(item[index]).Count;
    //    Console.WriteLine("*  would you like in    *");
    //    Console.WriteLine("*  in your lemonade?    *");
    //    Console.WriteLine("*                       *");
    //    Console.WriteLine("*************************");

    //}
}
}
