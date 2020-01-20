using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Threading;
using System.IO; 

namespace Lemonade_Stand
{
    class Game
    {
        //Declared Public Variables
        public Player player;
        public Store store;
        public Day day;


        public List<Day> days;

        public string saveUsername; 

        public bool userInputValid = false, hasBankLoan = false, lemonadeCreationSelected = false; 
        
        public double potentialLoanAmount, paidBank = 0, dailyPayment, interestRate = .01, timeInvolved, moneyGains, saveMoney;

        public int currentDay = 1, purchaseCount, userSelectedDayAmount;

        public string filePath = @"C:\Users\userc\Desktop\Dev Code Camp\Week - 3\Projects\LemonadeStandGame\Lemonade Stand\userContent.txt";
        public List<String> dataText = new List<string>();
        public List<String> Usernames = new List<string>();
        public List<double> Cash = new List<double>(); 


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

            userSelectedDayAmount = userInterface.SelectDays();

            day.weather.randomWeatherEvent();

            playerMenu();

        }
        public void playerMenu()
        {
            int userInputForMenu;
            bool isUserInputValid = false;
            bool isRoundOver = false;
            while (!isRoundOver)
            {
                userInterface.playerMenu(lemonadeCreationSelected, currentDay);

                isUserInputValid = int.TryParse(Console.ReadLine(), out userInputForMenu);

                switch (userInputForMenu)
                {
                    case 1:
                        day.weather.randomWeatherEvent();
                        StoreVisit();
                        break;
                    case 2:
                        bankLoanInterface();
                        break;
                    case 3:
                        weatherReport();
                        break;
                    case 4:
                        LemonadeCreation();
                        break;
                    case 5:
                        if (lemonadeCreationSelected == true)
                        {
                            simulateDay();
                            userInterface.SalesSummary(player, currentDay, day, purchaseCount, moneyGains, paidBank, hasBankLoan, dailyPayment, userSelectedDayAmount);
                            isRoundOver = true;
                            day.customers.Clear();
                            purchaseCount = 0;
                            moneyGains = 0;
                            currentDay++;
                            lemonadeCreationSelected = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You need to create your lemonade first!");
                            Console.ReadLine();
                            
                        }
                        break;
                    case 7:
                        saveGame();
                        break;
                    default:
                        
                        break;
                }
            }
        }

        public void StoreVisit()
        {
            int userwWantsLemons;
            int userWantsSugarCubes;
            int userWantsIceCubes;
            int userWantsCups; 

            bool isLemonsCorrect = false;
            bool isSugarCorrect = false;
            bool isIceCubesCorrect = false;
            bool isCupsCorrect = false; 

            Console.Clear();
            int userInput = 0;
            userInterface.StoreMenu(player);
            // DO NOT REMOVE
            Console.Write("Choose the product you want to purchase by #): ");
            int.TryParse(Console.ReadLine(), out userInput);
            switch (userInput)
            {
                case 1:
                    do
                    {
                        Console.Write("Amount of Lemons: ");
                        isLemonsCorrect = int.TryParse(Console.ReadLine(), out userwWantsLemons);
                    } while (isLemonsCorrect == false);
                    for (int i = 0; i < userwWantsLemons; i++)
                    {
                        player.inventory.lemons.Add( new Lemon());
                        player.wallet.Money -= store.pricePerLemon;

                        if (player.wallet.Money < 1.5)
                        {
                            bankLoanInterface();
                        }
                    }
                    StoreVisit();
                    break;
                case 2:
                    do
                    {
                        Console.Write("Amount of Sugar-Cubes: ");
                        isSugarCorrect = int.TryParse(Console.ReadLine(), out userWantsSugarCubes);
                    } while (isSugarCorrect == false);
                    for (int i = 0; i < userWantsSugarCubes; i++)
                    {
                        player.inventory.sugarCubes.Add(new SugarCube());
                        player.wallet.Money -= store.pricePerSugarCube;

                        if (player.wallet.Money < 1.5)
                        {
                            bankLoanInterface();
                        }
                    }
                    StoreVisit();
                    break;
                case 3:
                    do
                    {
                        Console.Write("Amount of Ice-Cubes: ");
                        isIceCubesCorrect = int.TryParse(Console.ReadLine(), out userWantsIceCubes);
                    } while (isIceCubesCorrect == false);
                    for (int i = 0; i < userWantsIceCubes; i++)
                    {
                        player.inventory.iceCubes.Add(new IceCube());
                        player.wallet.Money -= store.pricePerIceCube;

                        if (player.wallet.Money < 1.5)
                        {
                            bankLoanInterface();
                        }
                        
                    }
                    StoreVisit();
                    break;
                case 4:
                    do
                    {
                        Console.Write("Amount of Cups: ");
                        isCupsCorrect = int.TryParse(Console.ReadLine(), out userWantsCups);
                    } while (isCupsCorrect == false);
                    for (int i = 0; i < userWantsCups; i++)
                    {
                        player.inventory.cups.Add(new Cup());
                        player.wallet.Money -= store.pricePerCup;
                        if (player.wallet.Money < 1.5)
                        {
                            bankLoanInterface();
                        }
                    }
                    StoreVisit();
                    break;
                case 5:
                    Console.WriteLine("Come Again!");
                    playerMenu(); 
                    break;
                default:
                    Console.Clear();
                    StoreVisit();
                    break;
            }
        }

        public void weatherReport()
        {
            userInterface.ReportWeather(day.weather, currentDay);
        }

        public void simulateDay()
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
            //multiplier of 4 creates higher difference and determines difficulty
            player.pitcher.pitcherTasteScore = 100 - 4*(userInterface.AddFourNumbers(lemonFlavorDeviance, iceCubeFlavorDeviance, sugarCubeFlavorDeviance, priceDeviance));
            lemonadeCreationSelected = true; 
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
                Console.WriteLine("You don't have enough lemons!\n");
                Console.WriteLine("\nPress any key...");
                Console.ReadKey();
                 
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
                Console.WriteLine("You don't have enough sugar cubes!\n");
                Console.WriteLine("\nPress any key...");
                Console.ReadKey();
                
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
                Console.WriteLine("You don't have enough ice cubes!\n");
                Console.WriteLine("\nPress any key...");
                Console.ReadKey();
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
            lemonadeCreationSelected = true; 
            return userInput;
        }

        public void bankLoanInterface()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("*******************************************");
                Console.WriteLine("*        GET-A-LOAN    WALLET: {0}       ", player.wallet.Money);
                Console.WriteLine("*******************************************");
                Console.WriteLine("*                                         *");
                Console.WriteLine("*     YOU CAN APPLY FOR A LOAN BELOW      *");
                Console.WriteLine("*                                         *");
                Console.WriteLine("*******************************************");
                Console.Write("The Loan Amount: $");
                userInputValid = double.TryParse(Console.ReadLine(), out potentialLoanAmount);
            } while (userInputValid == false);
            if (potentialLoanAmount <= 10000)
            {
                timeInvolved = 6;
                dailyPayment = (potentialLoanAmount / 2) * interestRate * timeInvolved;
                Console.WriteLine();
                Console.WriteLine("*******************************************");
                Console.WriteLine("*    YOU HAVE BEEN APPROVED FOR: ${0}     ", potentialLoanAmount);
                Console.WriteLine("*******************************************");
                Console.WriteLine("*                                         *");
                Console.WriteLine("*     THE INTEREST RATE IS 1 PERCENT      *");
                Console.WriteLine("*     YOUR DAILY PAYMENT = ${0}           ", dailyPayment);
                Console.WriteLine("*     FOR SIX DAYS.                       *");
                Console.WriteLine("*******************************************");
                hasBankLoan = true;
                player.wallet.Money += potentialLoanAmount;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("*******************************************");
                Console.WriteLine("*             LOAN DECLINED               *");
                Console.WriteLine("*      ANYTHING OVER $10,000 FAILS.       *");
                Console.WriteLine("*******************************************");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
        public void titleMenu()
        {
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(52, 20);
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
            Console.WriteLine("'Y88P'   8   dP    Yb  8  18  888P' \n");
            Console.ReadKey(); 
        }

        public void saveGame()
        {
            Console.WriteLine("What is your name: ");
            saveUsername = Console.ReadLine();
            saveMoney = player.wallet.Money; 


            dataText = File.ReadAllLines(filePath).ToList();

            dataText.Add(saveUsername);
            dataText.Add(saveMoney.ToString());
           
            File.WriteAllLines(filePath, dataText);

            openGame();
        }

        public void openGame()
        {
            foreach (string line in dataText)
            {
                Console.WriteLine(line);
            }
            Console.ReadLine();
        }
    }
}
