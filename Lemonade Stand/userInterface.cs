using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    public static class userInterface
    {
        public static int currentDay = 1;
        public static void ReportWeather(Weather weather, int currentDay)
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("*       Weather Report for the day        *");
            Console.WriteLine("*******************************************");
            Console.WriteLine("*         Day:               {0}          *", currentDay);
            Console.WriteLine("*         Weather condition: {0}       *", weather.condition);
            Console.WriteLine("          Temperature is:    {0}F degrees *", weather.temperature);
            Console.WriteLine("*******************************************");
            Console.WriteLine("Press any key to continue");
            Console.Read();

        }
        public static void StoreMenu(Player player)
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
        public static void LemonadeCreationInstructions(Player player)
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
        public static int AddFourNumbers(int firstNumber, int secondNumber, int thirdNumber, int fourthNumber)
        {
            int number1, number2, number3, number4;
            number1 = firstNumber;
            number2 = secondNumber;
            number3 = thirdNumber;
            number4 = fourthNumber;
            int total = number1 + number2 + number3 + number4;
            return total;
        }
        public static void SalesSummary(Player player, int currentDay, Day day,int purchaseCount, double moneyGains)
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
            Console.WriteLine("Click to continue");
            Console.ReadLine();
        }

    }
}
