using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace StockBot
{
    class TradingBot
    {
        //fetching movers might have to be moved somewhere else.
        public string url = "https://finance.yahoo.com/gainers";
        public static List<dynamic> movers;
        public bool active;

        //add aggressive, normal, and safe options
        public TradingBot()
        {
            this.active = false;
        }
        
        //add something like if(active) then work
        public void FetchMovers()
        {
            string jsonString;
            using (var wc = new System.Net.WebClient())
            {
                jsonString = wc.DownloadString(url);
            }

            jsonString = jsonString.Split(new string[] { "\"results\":{\"rows\":" }, StringSplitOptions.None)[1];
            jsonString = jsonString.Split(new string[] { "]" }, StringSplitOptions.None)[0] + "]";
            List<dynamic> results = JsonConvert.DeserializeObject<List<dynamic>>(jsonString);
            movers = new List<dynamic>();
            movers.AddRange(results.Take(25));

            //Console.WriteLine("Top 25 movers from Yahoo Finance are: ");
            //for(int i = 0; i < movers.Count; i++)
            //{
            //    Console.WriteLine(string.Format("{0} - \t{1} \t{2} \t{3} \t{4}% \t{5} \t{6} \t{7} \t{8} \t{9} \t{10}",
            //        i+1, movers[i].symbol, movers[i].shortName, movers[i].regularMarketPrice.raw, movers[i].regularMarketChange.raw,
            //        movers[i].regularMarketChangePercent.raw, movers[i].regularMarketVolume.raw, movers[i].averageDailyVolume3Month.raw, movers[i].marketCap.raw, movers[i].fiftyTwoWeekLow.raw,
            //        movers[i].fiftyTwoWeekHigh.raw, movers[i].regularMarketOpen.raw));
            //}
        }

        public void aggressiveBuy()
        {
            //this.movers.Count;
        }

        public void buyStock(dynamic stock)
        {
            Portfolio.
        }
    }
}
