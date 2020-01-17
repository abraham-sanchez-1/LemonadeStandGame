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
    }
}
