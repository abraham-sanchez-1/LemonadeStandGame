using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Threading;

namespace Lemonade_Stand
{
    class Game
    {
        //Declared Public Variables
        public Player player;
        public Store store;
        public Day day;


        public List<Day> days;

        public bool userInputValid = false, hasBankLoan = false; 
        
        public double potentialLoanAmount, paidBank = 0, dailyPayment, interestRate = .05, timeInvolved, moneyGains;

        public int currentDay = 1, purchaseCount; 

        //Public Game Constructor Creating New Game
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
            titleMenu();

            int userSelectedDayAmount = userInterface.SelectDays();
            while (currentDay < userSelectedDayAmount || player.wallet.Money < 1.00)
            {
                day.weather.randomWeatherEvent();
                StoreVisit();
                SimulateDay();
                //*UserInterface.SalesSummary(player, currentDay, day, purchaseCount, moneyGains, paidBank, hasBankLoan, dailyPayment);*/
                currentDay++;
                purchaseCount = 0;
                moneyGains = 0;
                day.customers.Clear();
                if (currentDay > userSelectedDayAmount)
                {
                    //Issue with entering this section
                    Console.Clear();
                    Console.WriteLine("You have succesfully completed Lemonade Stand!");
                    Console.WriteLine("Developed by: Abraham Sanchez and Marcus Johnson!");
                    Console.WriteLine("Thank you for playing!");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                else if (player.wallet.Money < 1.00)
                {
                    bankLoanInterface();
                }
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
            else if (player.wallet.Money <= 1.50)
            {
                bankLoanInterface();
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
            //if statement checking wallet Money
            if (player.wallet.Money < 1.5 )
            {
                bankLoanInterface();
            }
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
                    for (int i = 0; i < 10; i++)
                    {
                        player.inventory.cups.Add(new Cup());
                    }
                    player.wallet.Money -= 5.00;
                    Console.Clear();
                    StoreVisit();
                    break;
                case 5:
                    Console.Clear();
                    break;
                    //This is a developer tool only, meant for testing
                case 6:
                    Console.WriteLine("Successfully added 10 Dollars to your balance.");
                    player.wallet.Money += 10.00;
                    Console.Clear();
                    StoreVisit();
                    break;
                default:
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
            if (player.wallet.Money <= 1.00)
            {
                bankLoanInterface();
            }
            else if (day.weather.condition == "sunny" && day.weather.temperature >= 90)
            {
                for (int i = 0; i < 80; i++)
                {
                    day.customers.Add(new Customer("Customers" + i));
                }
            }
            else if (day.weather.condition == "sunny" && day.weather.temperature <90)
            {
                for (int i = 0; i < 70; i++)
                {
                    day.customers.Add(new Customer("Customers" + i));
                }
            }
            else if (day.weather.condition == "overcast" && day.weather.temperature >= 70)
            {
                for (int i = 0; i < 60; i++)
                {
                    day.customers.Add(new Customer("Customers" + i));
                }
            }
            else if (day.weather.condition == "overcast" && day.weather.temperature < 70)
            {
                for (int i = 0; i < 40; i++)
                {
                    day.customers.Add(new Customer("Customers" + i));
                }
            }
            else if (day.weather.condition == "rain" && day.weather.temperature >= 50)
            {
                for (int i = 0; i < 30; i++)
                {
                    day.customers.Add(new Customer("Customers" + i));
                }
            }
            else if (day.weather.condition == "rain" && day.weather.temperature < 50)
            {
                for (int i = 0; i < 20; i++)
                {
                    day.customers.Add(new Customer("Customers" + i));
                }
            }
            else if (day.weather.condition == "hail" && day.weather.temperature >= 30)
            {
                for (int i = 0; i < 15; i++)
                {
                    day.customers.Add(new Customer("Customers" + i));
                }
            }
            else if (day.weather.condition == "hail" && day.weather.temperature < 30)
            {
                for (int i = 0; i < 10; i++)
                {
                    day.customers.Add(new Customer("Customers" + i));
                }
            }
            else if (day.weather.condition == "snow" && day.weather.temperature >= 10)
            {
                for (int i = 0; i < 7; i++)
                {
                    day.customers.Add(new Customer("Customers" + i));
                }
            }
            else if (day.weather.condition == "snow" && day.weather.temperature < 10)
            {
                for (int i = 0; i < 3; i++)
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
                    Console.WriteLine("You have run out cups to serve your lemonade!\n");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                }
            }
        }

        public void LemonadeCreation()
        {
            userInterface.LemonadeCreationInstructions(player);
            double lemonPitcherAmount = LemonAmount();
            double sugarCubePitcherAmount = SugarAmount();
            double iceCubePitcherAmount = IceAmount();
            double setCupPrice = SetPriceOfCup();
            double priceDeviance = Math.Abs(player.recipe.pricePerCup - player.pitcher.setCupPrice);
            double lemonFlavorDeviance = Math.Abs(player.recipe.amountOfLemons - lemonPitcherAmount);
            double iceCubeFlavorDeviance = Math.Abs(player.recipe.amountOfIceCubes - iceCubePitcherAmount);
            double sugarCubeFlavorDeviance = Math.Abs(player.recipe.amountOfSugarCubes - sugarCubePitcherAmount);
            player.pitcher.pitcherTasteScore = 50 - userInterface.AddFourNumbers(lemonFlavorDeviance, iceCubeFlavorDeviance, sugarCubeFlavorDeviance, priceDeviance);
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
        public double SetPriceOfCup()
        {
            double userInput;
            bool isUserInputValid = false;
            do
            {
                Console.Write("Set price of individual cups: ");
                isUserInputValid = double.TryParse(Console.ReadLine(), out userInput);

            } while (isUserInputValid == false);
            player.pitcher.setCupPrice = userInput;
            return userInput;
        }




        public void bankLoanInterface()
        {
            do
            {
                Console.Clear();
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
            if (potentialLoanAmount <= 10000)
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
                player.wallet.Money += potentialLoanAmount;
                Console.ReadLine();
                StoreVisit();
            }
            else
            {
                Console.WriteLine("*******************************************");
                Console.WriteLine("* LOAN DECLINED YOU HAVE FAILED THE GAME. *");
                Console.WriteLine("*******************************************");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
        public void titleMenu()
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "Barbarian - Pierlo.wav";
            player.Play();
            Console.Title = "YOUR LEMONADE STAND V1";
            Console.WriteLine("db    db   .d88b.  db    db d8888b.     ");
            Console.WriteLine("`8b  d8'  .8P  Y8. 88    88 88  `8D     ");
            Console.WriteLine(" `8bd8'   88    88 88    88 88oobY'     ");
            Console.WriteLine("   88     88    88 88    88 88`8b       ");
            Console.WriteLine("   88     `8b  d8' 88b  d88 88 `88.     ");
            Console.WriteLine("   YP      `Y88P'  ~Y8888P' 88   YD     ");
            Console.WriteLine("                                        ");
            Console.WriteLine("8    8888 8b   d8 .d88b. 8b  8    db    888b. 8888");
            Console.WriteLine("8    8www 8YbmdP8 8P  Y8 8Ybm8   dPYb   8   8 8www ");
            Console.WriteLine("8    8    8     8 8b  d8 8   8  dPwwYb  8   8 8 ");
            Console.WriteLine("8888 8888 8     8 `Y88P' 8   8 dP    Yb 888P' 8888");
            Console.WriteLine("                                         ");
            Console.WriteLine(".d88b. 88888    db     8b  8  888b. ");
            Console.WriteLine("YPwww.   8     dPYb    8Ybm8  8   8 ");
            Console.WriteLine("   d8    8    dP wYb   8  8   8   8");
            Console.WriteLine("'Y88P'   8   dP    Yb  8  18  888P \n");
            Console.ReadLine();
            
        }
    }
}
