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
        public double timeInvolved;
        public bool userInputValid = false;
        public double potentialLoanAmount;
        public double paidBank = 0;
        public double dailyPayment;
        public double interestRate = .05;
        public Store store;
        public Day day;
        
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
            Console.Title = "YOUR LEMONADE STAND V1";
            Console.WriteLine("Welcome to Your Lemonade Stand!");
            Console.Clear();
            int userSelectedDayAmount = SelectDays();
            while (currentDay < userSelectedDayAmount || player.wallet.Money < 1.00)
            {
                day.weather.randomWeatherEvent();
                StoreVisit();
                SimulateDay();
                userInterface.SalesSummary(player, currentDay, day, purchaseCount, moneyGains, paidBank, hasBankLoan, dailyPayment);
                currentDay++;
                purchaseCount = 0;
                moneyGains = 0;
                day.customers.Count();
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
            userInterface.StoreMenu(player);
            // DO NOT REMOVE
            Console.Write("Choose: ");
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
            userInterface.SalesSummary(player, currentDay, day, purchaseCount, moneyGains, paidBank, hasBankLoan, dailyPayment);
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
                if (player.inventory.cups.Count > 0 && day.customers[i].tasteScore < player.pitcher.pitcherTasteScore)
                {
                    purchaseCount++;
                    player.pitcher.cupsLeftInPitcher -= 1;
                    player.wallet.Money += player.pitcher.setCupPrice;
                    moneyGains += player.pitcher.setCupPrice;
                    player.inventory.cups.RemoveAt(0);
                    
                }
                else if (player.inventory.cups.Count == 0)
                {
                    Console.WriteLine("You have run out cups to serve your lemonade!");
                    Console.WriteLine("");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                }
            }
        }

        public void LemonadeCreation()
        {
            userInterface.LemonadeCreationInstructions(player);
            int lemonPitcherAmount = LemonAmount();
            int sugarCubePitcherAmount = SugarAmount();
            int iceCubePitcherAmount = IceAmount();
            int setCupPrice = SetPriceOfCup();
            int priceDeviance = Math.Abs(player.recipe.pricePerCup - player.pitcher.setCupPrice);
            int lemonFlavorDeviance = Math.Abs(player.recipe.amountOfLemons - lemonPitcherAmount);
            int iceCubeFlavorDeviance = Math.Abs(player.recipe.amountOfIceCubes - iceCubePitcherAmount);
            int sugarCubeFlavorDeviance = Math.Abs(player.recipe.amountOfSugarCubes - sugarCubePitcherAmount);
            player.pitcher.pitcherTasteScore = 50 - userInterface.AddFourNumbers(lemonFlavorDeviance, iceCubeFlavorDeviance, sugarCubeFlavorDeviance, setCupPrice);
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




        public void bankLoanInterface()
        {
            
            do
            {
                Console.WriteLine("*******************************************");
                Console.WriteLine("*         YOU ARE OUT OF MONEY.           *");
                Console.WriteLine("*******************************************");
                Console.WriteLine("*                                         *");
                Console.WriteLine("*    YOU CAN APPLY FOR A LOAN BELOW       *");
                Console.WriteLine("*                                         *");
                Console.WriteLine("*******************************************");
                Console.Write("The Amount: $");
                userInputValid = double.TryParse(Console.ReadLine(), out potentialLoanAmount);
            } while (userInputValid == false);
            if (potentialLoanAmount > 10000)
            {
                timeInvolved = 6;
                dailyPayment = potentialLoanAmount * interestRate * timeInvolved;
                Console.WriteLine();
                Console.WriteLine("*******************************************");
                Console.WriteLine("*    YOU HAVE BEEN APPROVED FOR: ${0}     *", potentialLoanAmount);
                Console.WriteLine("*******************************************");
                Console.WriteLine("*                                         *");
                Console.WriteLine("*     THE INTEREST RATE IS 5 PERCENT      *");
                Console.WriteLine("*     YOUR DAILY PAYMENT = ${0}           *", dailyPayment);
                Console.WriteLine("*     FOR SIX DAYS.                       *");
                Console.WriteLine("*******************************************");
                hasBankLoan = true;
                currentDay = currentDay + 30;
                player.wallet.Money += potentialLoanAmount;
                Console.ReadLine();
                StoreVisit();
            }
            else
            {
                Console.WriteLine("*******************************************");
                Console.WriteLine("  LOAN DECLINED YOU HAVE FAILED THE GAME. *");
                Console.WriteLine("*******************************************");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
    }
}
