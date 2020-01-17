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
        private Day day;

        public List<Day> days;
        
        private int currentDay = 1;

        //constructor
        public Game()
        {
            player = new Player("Bobby");
            store = new Store();
            days = new List<Day>();
            day = new Day();
        }

        //Begin New Game
        public void NewGame()
        {
            Console.WriteLine("WELCOME TO LEMONADE STAND! (PROTOTYPE)");
            Console.WriteLine("This is a developer build and does not represent final product..");
            Console.ReadLine();
            Console.Clear();
            int userSelectedDayAmount = SelectDays();
            while (currentDay < userSelectedDayAmount || player.wallet.Money < 1.00)
            {
                day.weather.randomWeatherEvent();
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
                    Console.WriteLine("Money Left: {0}", player.wallet.Money);
                    Console.Clear();
                    StoreVisit();
                    break;
                case 2:
                    for (int i = 0; i < 5; i++)
                    {
                        player.inventory.sugarCubes.Add(new SugarCube());
                    }
                    player.wallet.Money -= 1.50;
                    Console.WriteLine("Money Left: {0}", player.wallet.Money); 
                    Console.Clear();
                    StoreVisit();
                    break;
                case 3:
                    for (int i = 0; i < 5; i++)
                    {
                        player.inventory.iceCubes.Add(new IceCube());
                    }
                    player.wallet.Money -= 2.50;
                    Console.WriteLine("Money Left: {0}", player.wallet.Money);
                    Console.Clear();
                    StoreVisit();
                    break;
                case 4:
                    for (int i = 0; i < 5; i++)
                    {
                        player.inventory.cups.Add(new Cup());
                    }
                    player.wallet.Money -= 5.00;
                    Console.WriteLine("Money Left: {0}", player.wallet.Money); 
                    Console.Clear();
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
            Console.WriteLine("Day: {0}", currentDay);
            Console.WriteLine("The Weather is: {0}", day.weather.condition);
            Console.WriteLine("The Temperature is: {0}", day.weather.temperature);
            if (day.weather.condition == "sunny" && day.weather.temperature >= 90)
            {
                for (int i = 0; i < 80; i++)
                {
                    day.customers.Add(new Customer("Customers" + i));
                }
            }
            if (day.weather.condition == "hail" && day.weather.temperature <= 32)
            {
                for (int i = 0; i < 15; i++)
                {
                    day.customers.Add(new Customer("Customers" + i));
                }
            }
            if (day.weather.condition == "overcast" && day.weather.temperature <= 70)
            {
                for (int i = 0; i < 55; i++)
                {
                    day.customers.Add(new Customer("Customers" + i));
                }
            }
            if (day.weather.condition == "snow" && day.weather.temperature <= 32)
            {
                for (int i = 0; i < 10; i++)
                {
                    day.customers.Add(new Customer("Customers" + i));
                }
            }
            if (day.weather.condition == "rain" && day.weather.temperature <= 65)
            {
                for (int i = 0; i < 25; i++)
                {
                    day.customers.Add(new Customer("Customers" + i));
                }
            }
            for (int i = 0; i < day.customers.Count; i++)
            {
                Console.WriteLine("{0} is approaching...", day.customers[i].name);
                if (day.customers[i].tasteScore < player.pitcher.pitcherTasteScore)
                {
                    Console.WriteLine("{0} purchased your Lemonade!", day.customers[i].name);
                    player.pitcher.cupsLeftInPitcher -= +1;
                    player.wallet.Money += player.pitcher.setCupPrice;
                    player.inventory.cups.Remove(new Cup());
                }
                else 
                {
                    Console.WriteLine("{0} said your drink was trash..", day.customers[i].name);
                }
            }

        }
        public void SalesSummary()
        {
            //end of round
        }
        public void StoreMenu()
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("*         WELCOME TO YOUR STORE           *");
            Console.WriteLine("*******************************************");
            Console.WriteLine("*                                         *");
            Console.WriteLine("*1.)+5 LEMONS $2.50       Your Lemons: {0}*", player.inventory.lemons.Count);
            Console.WriteLine("*                                         *");
            Console.WriteLine("*2.)+5 SUGAR-CUBES $1.50   Your Sugar: {0}*", player.inventory.sugarCubes.Count);
            Console.WriteLine("*                                         *");
            Console.WriteLine("*3.)+5 ICE CUBES 2.50        Your Ice: {0}*", player.inventory.iceCubes.Count);
            Console.WriteLine("*                                         *");
            Console.WriteLine("*4.)+5 CUPS 5.00            Your Cups: {0}*", player.inventory.cups.Count);
            Console.WriteLine("*                                         *");
            Console.WriteLine("*5.) EXIT STORE             Wallet: ${0}  *", player.wallet.Money);
            Console.WriteLine("*                                         *");
            Console.WriteLine("*******************************************");
        }
        public void LemonadeCreation()
        {
            Console.WriteLine("How many lemons would you like in your lemonade?");
            int lemonPitcherAmount = Convert.ToInt32(Console.ReadLine());   
            player.inventory.lemons.RemoveRange(0,lemonPitcherAmount-1);
            Console.WriteLine("How many sugar cubes would you like in your lemonade?");
            int sugarCubePitcherAmount = Convert.ToInt32(Console.ReadLine());
            player.inventory.sugarCubes.RemoveRange(0, sugarCubePitcherAmount-1);
            Console.WriteLine("How many ice cubes would you like in your lemonade?");
            int iceCubePitcherAmount = Convert.ToInt32(Console.ReadLine());
            player.inventory.iceCubes.RemoveRange(0, iceCubePitcherAmount-1);
            Console.WriteLine("Set price of individual cups");
            player.pitcher.setCupPrice = Convert.ToDouble(Console.ReadLine());
            int priceDeviance = Convert.ToInt32(Math.Abs(player.recipe.pricePerCup - player.pitcher.setCupPrice));
            int lemonFlavorDeviance = Math.Abs(player.recipe.amountOfLemons - lemonPitcherAmount);
            int iceCubeFlavorDeviance = Math.Abs(player.recipe.amountOfIceCubes - iceCubePitcherAmount);
            int sugarCubeFlavorDeviance = Math.Abs(player.recipe.amountOfSugarCubes - sugarCubePitcherAmount);
            player.pitcher.pitcherTasteScore = 50 - AddFourNumbers(lemonFlavorDeviance, iceCubeFlavorDeviance, sugarCubeFlavorDeviance,priceDeviance);
            Console.WriteLine("Your creation yielded a {0} taste score!", player.pitcher.pitcherTasteScore);
            
        }
        public int AddFourNumbers(int firstNumber, int secondNumber, int thirdNumber, int fourthNumber)
        {
            int number1, number2, number3, number4;
            number1 = firstNumber;
            number2 = secondNumber;
            number3 = thirdNumber;
            number4 = fourthNumber;
            int total = number1 + number2 + number3 + number4;
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
