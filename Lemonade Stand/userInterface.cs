using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    public static class userInterface
    {

        //SOLID PRINCIPLES IN EFFECT HERE - most if not all methods (SalesSummary method is probably a bit too large) in the userInterface 
        //static class follow the single responsibility principle
        //Easiest example of solid is our AddFourNumbers method, it does exactly what it states and nothing else.
        //Sales Summary is only method below in userInterface that could use some simplification via separate methods
        //Additionally, Liskov Substitution Principle can be found with the Item parent class and 4 inherited classes.
        //Child can replace parent class without issue and new ingredients can be added without issue.

        public static int currentDay = 1;

        public static void playerMenu(bool lemonadeCreationSelected, int currentDay)
        {
                Console.Clear();
                Console.WriteLine("*********************************************");
                Console.WriteLine("*   Welcome to YOUR LEMONADE STAND Menu!    *");
                Console.WriteLine("*********************************************");
                Console.WriteLine("*   (To simulate day, you will first need   *");
                Console.WriteLine("*       to create lemonade!)                *");
                Console.WriteLine("*                                           *");
                Console.WriteLine("*            Current Day: {0}              ", currentDay);
                Console.WriteLine("*                                           *");
                Console.WriteLine("*1) Go to the Store!                        *");
                Console.WriteLine("*                                           *");
                Console.WriteLine("*2) Get-a-Loan!                             *");
                Console.WriteLine("*                                           *");
                Console.WriteLine("*3) Check the Weather!                      *");
                Console.WriteLine("*                                           *");
                Console.WriteLine("*4) Create your Lemonade!                   *");
                Console.WriteLine("*                                           *");
                if (lemonadeCreationSelected == true)
                {
                Console.WriteLine("*5) Simulate day!                           *");
                }
                Console.WriteLine("*                                           *");
                Console.WriteLine("*********************************************");
                Console.Write("#) Choice: ");
        }
        public static void ReportWeather(Weather weather, int currentDay)
        {

            Console.Clear();
            Console.WriteLine("*******************************************");
            Console.WriteLine("*       Weather Report for the day        *");
            Console.WriteLine("*******************************************");
            Console.WriteLine("*         Day:               {0}         ", currentDay);
            Console.WriteLine("*         Weather Condition: {0}         ", weather.condition);
            Console.WriteLine("*         Temperature is:    {0}F degrees ", weather.temperature);
            Console.WriteLine("*                                         ");
            Console.WriteLine("*         Forcast for tomorrow: {0}       ", weather.predictedForecast);
            Console.WriteLine("*                                         ");
            Console.WriteLine("*******************************************");
            Console.WriteLine("\nPress any key...");
            Console.Read();

        }
        public static void StoreMenu(Player player)
        {
                Console.Clear();
                Console.WriteLine("*********************************************");
                Console.WriteLine("*           WELCOME TO YOUR STORE           *");
                Console.WriteLine("*********************************************");
                Console.WriteLine("*                                           *");
                Console.WriteLine("*1) LEMONS                  Your Lemons: {0}", player.inventory.lemons.Count);
                Console.WriteLine("*                                           *");
                Console.WriteLine("*2) SUGAR-CUBES              Your Sugar: {0}", player.inventory.sugarCubes.Count);
                Console.WriteLine("*                                           *");
                Console.WriteLine("*3) ICE-CUBES                 Your Ice: {0}", player.inventory.iceCubes.Count);
                Console.WriteLine("*                                           *");
                Console.WriteLine("*4) CUPS                     Your Cups: {0}", player.inventory.cups.Count);
                Console.WriteLine("*                                           *");
                Console.WriteLine("*5) EXIT STORE                Wallet: ${0}  ", player.wallet.Money);
                Console.WriteLine("*                                           *");
                Console.WriteLine("*********************************************");
        }
        public static void LemonadeCreationInstructions(Player player)
        {
            Console.Clear(); 
            Console.WriteLine("*******************************************");
            Console.WriteLine("*         Lemonade Creation Menu          *");
            Console.WriteLine("*******************************************");
            Console.WriteLine("* To create lemonade, indicate quantity   *");
            Console.WriteLine("* of each ingredient in prompt below. The *");
            Console.WriteLine("* better the lemonade, the more customers *");
            Console.WriteLine("* you will have purchase from you!        *");
            Console.WriteLine("* (Hint: Perfect amount of lemons is 3!   *");
            Console.WriteLine("*******************************************");
            Console.WriteLine("*         Your Lemons Inventory: {0}      ", player.inventory.lemons.Count);
            Console.WriteLine("*                                         *");
            Console.WriteLine("*         Your Sugar Inventory:  {0}     ", player.inventory.sugarCubes.Count);
            Console.WriteLine("*                                         *");
            Console.WriteLine("*         Your Ice Inventory:    {0}     ", player.inventory.iceCubes.Count);
            Console.WriteLine("*                                         *");
            Console.WriteLine("*         Your Cups Inventory:   {0}      ", player.inventory.cups.Count);
            Console.WriteLine("*******************************************");
        }

        public static double AddFourNumbers(double firstNumber, double secondNumber, double thirdNumber, double fourthNumber)
        {
            double total = firstNumber + secondNumber + thirdNumber + fourthNumber;
            return total;
        }
        public static void SalesSummary(Player player, int currentDay, Day day, int purchaseCount, double moneyGains, double paidBank, bool hasBankLoan, double dailyPayment, int userSelectedDayAmount)
        {
            Console.Clear();
            Console.WriteLine("*******************************************");
            Console.WriteLine("*   Day {0}             Sales Summary     ", currentDay);
            Console.WriteLine("*     Of {0}               Below          ", userSelectedDayAmount);
            Console.WriteLine("*******************************************");
            Console.WriteLine("* {0} customers visited the lemonade stand!", day.customers.Count);
            Console.WriteLine("*                                         *");
            Console.WriteLine("*   There were {0} lemonade purchases    ", purchaseCount);
            Console.WriteLine("*                                         *");
            Console.WriteLine("*         You made ${0} today!            ", moneyGains);
            Console.WriteLine("*                                         *");
            Console.WriteLine("* Customers gave your lemonade a score of *");
            Console.WriteLine("*                 {0}                     ", player.pitcher.pitcherTasteScore);
            Console.WriteLine("*******************************************");
            if (currentDay > userSelectedDayAmount && player.wallet.Money >= 30)
            {
                //Issue with entering this section
                Console.Clear();
                Console.WriteLine("Game has ended! You ended with ${0}", player.wallet.Money);
                Console.WriteLine("You have succesfully completed Lemonade Stand!");
                Console.WriteLine("Developed by:\nAbraham Sanchez & Marcus Johnson!");
                Console.WriteLine("Thank you for playing!");
                Console.ReadLine();
                Environment.Exit(0);
            }
            if (currentDay > userSelectedDayAmount && player.wallet.Money < 30)
            {
                Console.Clear();
                Console.WriteLine("Game has ended! You ended with ${0}", player.wallet.Money);
                Console.WriteLine("You lemonade business ventures were unsuccessful!");
                Console.WriteLine("Developed by:\nAbraham Sanchez & Marcus Johnson!");
                Console.WriteLine("Thank you for playing!");
                Console.ReadLine();
                Environment.Exit(0);
            }
            if (player.inventory.cups.Count == 0)
            {
                Console.WriteLine("Your day was short due to shortage of cups!");
            }
            Console.WriteLine("\nPress any key...");
            Console.ReadKey(true);
            if (hasBankLoan == true)
            {
                player.wallet.Money -= dailyPayment;
                Console.WriteLine("You have also paid the bank ${0} today.", dailyPayment);
                Console.ReadLine();
                paidBank++;
                if (paidBank == 6)
                {
                    Console.WriteLine("You have paid your loan in full.");
                    paidBank = 0;
                }
            }

        }
        public static int SelectDays()
        {
            Console.Clear();
            int userInput = 0;
            bool isUserInputValid = false;
            do
            {
                Console.Write("Type your number of days: ");
                isUserInputValid = int.TryParse(Console.ReadLine(), out userInput);

            } while (isUserInputValid == false);
            if (userInput <= 7)
            {
                Console.WriteLine("Selection invalid.");
                Console.ReadLine(); 
                SelectDays();
                return userInput; 
            }
            else 
            {
                return userInput; 
            }
        }
    }
}

