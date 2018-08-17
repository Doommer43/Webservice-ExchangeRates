using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webservice.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace Webservice.Servicelag
{
    /// <summary>
    /// Class to connect to OpenExchangeRates.org WEB API
    /// </summary>
    public class WebConnect
    {
        private ExchangeRates exchangeRates;
        private string openExchangeRates;

        /// <summary>
        /// WebConnect constructer has no parameters
        /// </summary>
        public WebConnect()
        {
            openExchangeRates = @"https://openexchangerates.org/api/latest.json?app_id=58559843c4ae4a6abb553f6d6a22df2f";
        }

        #region Fields
        /// <summary>
        /// Contains the API web address and API ID key
        /// </summary>
        public string OpenExchangeRates
        {
            get { return openExchangeRates; }
            set { openExchangeRates = value; }
        }        
        /// <summary>
        /// Contains the retrived JSON string in a c# class
        /// </summary>
        public ExchangeRates ExchangeRates
        {
            get { return exchangeRates; }
            set { exchangeRates = value; }
        }
        #endregion

        /// <summary>
        /// Returns exchange rates
        /// </summary>
        /// <returns>ExchangeRates object with all the needed data</returns>
        public ExchangeRates GetExchangeRates()
        {
            using (WebClient webClient = new WebClient())
            {
                string json = webClient.DownloadString(openExchangeRates);
                try
                {
                    ExchangeRates rates = JsonConvert.DeserializeObject<ExchangeRates>(json);
                    return rates;

                }
                catch (JsonSerializationException e)
                {
                    if(e.InnerException.GetType() == typeof(ArgumentException))
                        Console.WriteLine("{0}: {1}", e.InnerException.GetType(), e.InnerException.Message);
                    else
                    {
                        throw;
                    }
                }
                return null;
            }            

        }

    }
}
