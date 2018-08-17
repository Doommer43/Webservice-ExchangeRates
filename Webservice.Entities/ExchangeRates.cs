using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webservice.Entities
{
    /// <summary>
    /// Class that contains exchange rates from OpenExchangeRates.org JSON web response
    /// </summary>
    public class ExchangeRates
    {
        private string disclaimer;
        private string license;
        private string timestamp;
        private string @base;
        private Dictionary<string,decimal> rates = new Dictionary<string, decimal>();

        /// <summary>
        /// ExchangeRates constructer
        /// </summary>
        /// <param name="disclaimer"></param>
        /// <param name="license"></param>
        /// <param name="timestamp"></param>
        /// <param name="base"></param>
        /// <param name="rates"></param>
        //public ExchangeRates(string disclaimer, string license, string timestamp, string @base, Dictionary<string, decimal> rates)
        //{
        //    this.disclaimer = disclaimer;
        //    this.license = license;
        //    this.timestamp = timestamp;
        //    Base = @base;
        //    this.rates = rates;
        //}
        #region Fields
        /// <summary>
        /// Contains all the retrieved valuta and their exchange rate
        /// </summary>
        public Dictionary<string,decimal> Rates
        {
            get { return rates; }
            set { rates = value; }
        }
        /// <summary>
        /// Contains the base valuta for the exchange rates
        /// </summary>
        public string Base
        {
            get { return @base; }
            set { if (value == "USD") @base = value;
                    else throw new ArgumentException(String.Format("Base valuta is {0}, not 'USD'", value));
                }
        }
        /// <summary>
        /// Contains the timestamp for when the retrieved data was last updated
        /// </summary>
        public string Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }

        /// <summary>
        /// Links to OpenExchangeRates.org license
        /// </summary>
        public string License
        {
            get { return license; }
            set { license = value; }
        }

        /// <summary>
        /// Links to OpenExchangeRates.org disclaimer policy
        /// </summary>
        public string Disclaimer
        {
            get { return disclaimer; }
            set { disclaimer = value; }
        }
        #endregion
    }
}
