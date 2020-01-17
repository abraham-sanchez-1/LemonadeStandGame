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
        public Player player;
        public Bank bankLoan = new Bank();
        private Store store;
        private Day day;
        
        public int purchaseCount;
        public double moneyGains;

        public List<Day> days;

        public int currentDay = 1;

        public bool hasBankLoan = false;
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
            Console.WriteLine("This is a developer build and does not represent the final product..");
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
                purchaseCount = 0;
                moneyGains = 0;
            }
            if (currentDay > userSelectedDayAmount)
            {
                Console.Clear();
                Console.WriteLine("You have succesfully completed Lemonade Stand!");
                Console.WriteLine("Developed by: Abraham Sanchez and Marcus Johnson!");
                Console.WriteLine("Thank you for playing!");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else if (player.wallet.Money < 1.00)
            {
                //bankLoan.bankLoanInterface();
            }
        }

        public int SelectDays()
        {
            Console.WriteLine("How many days would you like to play?\n(7)\n(14)\n(30)");
            Console.Write("Please tell me: ");
            int userInput = 0;
            int.TryParse(Console.ReadLine(), out userInput);
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
            Console.Clear();
            int userInput = 0;
            //Going to the store
            StoreMenu();
            int.TryParse(Console.ReadLine(), out userInput);
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
                case 6:
                    Console.WriteLine("Successfully added 10 Dollars to your balance.");
                    player.wallet.Money += 10.00;
                    Console.Clear();
                    StoreVisit();
                    break;
                default:
                    Console.WriteLine("Selection was invalid, try again!");
                    Console.Clear();
                    StoreVisit();
                    break;
            }
        }

        public void SimulateDay()
        {
            LemonadeCreation();
            userInterface.ReportWeather(day.weather, currentDay);
            populateCustomers();
            SalesSummary();
        }

        public void populateCustomers()
        {
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

                if (day.customers[i].tasteScore < player.pitcher.pitcherTasteScore)
                {
                    purchaseCount++;
                    player.pitcher.cupsLeftInPitcher -= 1;
                    player.wallet.Money += player.pitcher.setCupPrice;
                    moneyGains += player.pitcher.setCupPrice;
                    player.inventory.cups.RemoveAt(0);
                    if (player.inventory.cups.Count == 0)
                    {
                        Console.WriteLine("You have run out cups to serve your lemonade!");
                        break;
                    }
                }
                //else
                //{
                //    Drink is trash statement
                //}
            }
        }

        public void SalesSummary()
        {
            //int paidBank = 0;
            Console.Clear();
            Console.WriteLine("*******************************************");
            Console.WriteLine("*        Day {0} End: Sales Summary        *", currentDay);
            Console.WriteLine("*******************************************");
            Console.WriteLine("* {0} customers visited the lemonade stand*", day.customers.Count);
            Console.WriteLine("*                                         *");
            Console.WriteLine("*   There were {0} lemonade purchases     *", purchaseCount);
            Console.WriteLine("*                                         *");
            Console.WriteLine("*         You made ${0} today!            *", moneyGains);
            Console.WriteLine("*                                         *");
            Console.WriteLine("* Customers gave your lemondae a score of *");
            Console.WriteLine("*                 {0}                     *", player.pitcher.pitcherTasteScore);
            Console.WriteLine("*******************************************");
            //if (hasBankLoan == true)
            //{
            //    player.wallet.Money -= bankLoan.dailyPayment;
            //    Console.WriteLine("You have also paid the bank ${0} today.", bankLoan.dailyPayment);
            //    Console.ReadLine();
            //    paidBank++;
            //    if (paidBank == 6)
            //    {
            //        Console.WriteLine("You have paid your loan in full.");
            //        paidBank = 0;
            //    }
            //}

            Console.WriteLine("Click to continue");
            Console.ReadLine();


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
            LemonadeCreationInstructions();
            int lemonPitcherAmount = LemonAmount();
            int sugarCubePitcherAmount = SugarAmount();
            int iceCubePitcherAmount = IceAmount();
            int setCupPrice = SetPriceOfCup();
            int priceDeviance = Math.Abs(player.recipe.pricePerCup - player.pitcher.setCupPrice);
            int lemonFlavorDeviance = Math.Abs(player.recipe.amountOfLemons - lemonPitcherAmount);
            int iceCubeFlavorDeviance = Math.Abs(player.recipe.amountOfIceCubes - iceCubePitcherAmount);
            int sugarCubeFlavorDeviance = Math.Abs(player.recipe.amountOfSugarCubes - sugarCubePitcherAmount);
            player.pitcher.pitcherTasteScore = 50 - AddFourNumbers(lemonFlavorDeviance, iceCubeFlavorDeviance, sugarCubeFlavorDeviance, priceDeviance);
        }
        public int LemonAmount()
        {
            int userInput;
            bool isUserInputValid = false;
            do
            {

                Console.Write("How many lemons would you like to add: ");
                isUserInputValid = int.TryParse(Console.ReadLine(), out userInput);

            } while (isUserInputValid == false);
            if (player.inventory.lemons.Count >= userInput)
            {
                player.inventory.lemons.RemoveRange(0, userInput);
                return userInput;
            }
            else
            {
                Console.WriteLine("You don't have enough lemons!");
                LemonAmount();
                return userInput;
            }

        }
        public int SugarAmount()
        {
            int userInput;
            bool isUserInputValid = false;
            do
            {

                Console.Write("How many sugar cubes would you like to add: ");
                isUserInputValid = int.TryParse(Console.ReadLine(), out userInput);

            } while (isUserInputValid == false);
            if (player.inventory.sugarCubes.Count >= userInput)
            {
                player.inventory.sugarCubes.RemoveRange(0, userInput);
                return userInput;
            }
            else
            {
                Console.WriteLine("You don't have enough sugar cubes!");
                SugarAmount();
                return userInput;
            }

        }
        public int IceAmount()
        {
            int userInput;
            bool isUserInputValid = false;
            do
            {

                Console.Write("How many ice cubes would you like to add: ");
                isUserInputValid = int.TryParse(Console.ReadLine(), out userInput);

            } while (isUserInputValid == false);
            if (player.inventory.iceCubes.Count >= userInput)
            {
                player.inventory.iceCubes.RemoveRange(0, userInput);
                return userInput;
            }
            else
            {
                Console.WriteLine("You don't have enough ice cubes!");
                IceAmount();
                return userInput;
            }

        }
        public int SetPriceOfCup()
        {
            int userInput;
            bool isUserInputValid = false;
            do
            {

                Console.Write("Set price of individual cups:\n(Please select a whole dollar amount)");
                isUserInputValid = int.TryParse(Console.ReadLine(), out userInput);

            } while (isUserInputValid == false);
            player.pitcher.setCupPrice = userInput;
            return userInput;
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

        public void LemonadeCreationInstructions()
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("*         Lemonade Creation Menu          *");
            Console.WriteLine("*******************************************");
            Console.WriteLine("* To create lemonade, indicate quantity   *");
            Console.WriteLine("* of each ingredient in prompt below.     *");
            Console.WriteLine("*******************************************");
            Console.WriteLine("*         Your Lemons: {0}                *", player.inventory.lemons.Count);
            Console.WriteLine("*                                         *");
            Console.WriteLine("*         Your Sugar: {0}                 *", player.inventory.sugarCubes.Count);
            Console.WriteLine("*                                         *");
            Console.WriteLine("*         Your Ice: {0}                   *", player.inventory.iceCubes.Count);
            Console.WriteLine("*                                         *");
            Console.WriteLine("*         Your Cups: {0}                  *", player.inventory.cups.Count);
            Console.WriteLine("*******************************************");
        }
    }

}
