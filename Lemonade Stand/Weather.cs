using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Weather
    {
        //member variable
        public string condition;
        public int temperature;
        private List<string> weatherConditions;
        public string predictedForecast;

        //constructor
        public Weather()
        {
            condition = "sunny";
            temperature = 70;
            weatherConditions = new List<string>() { "sunny", "overcast","snow","rain", "hail" };
            predictedForecast = "placeholder";
        }
        //member methods
        //"placeholder to be replaced by random method"
    }
}
