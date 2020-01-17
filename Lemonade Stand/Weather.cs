using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    public class Weather
    {
        //member variable
        public string condition, predictedForecast;

        public int temperature;

        private List<string> weatherConditions;

        Random randomTemperature = new Random();
        Random randomWeatherCondition = new Random();

        //constructor
        public Weather()
        {
            condition = "null";
            temperature = 1;
            weatherConditions = new List<string>() { "sunny", "overcast","rain","hail", "snow" };
            predictedForecast = "placeholder";
        }
        
        public void randomWeatherEvent()
        {
            int Count = randomWeatherCondition.Next(0, 5);
            switch (Count)
            {
                case 0:
                    condition = weatherConditions[0];
                    temperature = randomTemperature.Next(80, 100); 
                    break;
                case 1:
                    condition = weatherConditions[1];
                    temperature = randomTemperature.Next(60, 80);
                    break;
                case 2:
                    condition = weatherConditions[2];
                    temperature = randomTemperature.Next(40, 60);
                    break;
                case 3:
                    condition = weatherConditions[3];
                    temperature = randomTemperature.Next(20, 40);
                    break;
                case 4:
                    condition = weatherConditions[4];
                    temperature = randomTemperature.Next(0, 20);
                    break;
                case 5:
                    randomWeatherEvent();
                    break;
                default:
                    randomWeatherEvent();
                    break;
            }
        }
        
    }
}
