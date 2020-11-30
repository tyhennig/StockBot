using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using HtmlAgilityPack;

namespace StockBot
{
    public class Portfolio
    {
        //private List<dynamic> movers;
        //we might need an id for each portfolio. Index may be handy for when you navigate
        private string displayName;
        //private string owner;
        public List<dynamic> contents;
        //private TradingBot bot; //Each portfolio might have its own bot
        public string url = "https://finance.yahoo.com/quote/";


        public Portfolio(string dn)
        {
            displayName = dn;
            contents = new List<dynamic>();
            //bot.RegisterObserver(this);
        }

        public string getDisplayName()
        {
            return displayName;
        }

        //public void buyStock(dynamic stock)
        //{
        //    contents.Add(stock);
        //}

        public void removeStock(dynamic stock)
        {
            contents.Remove(stock);
        }

        public void displayPortfolio()
        {
            foreach (Stock stock in contents) //iterates list, writes stock ToString() to console
            {
                Console.WriteLine(stock);
            }
        }

        public void displayPorfolioContent()
        {
            foreach(dynamic stock in contents)
            {
                Console.WriteLine(stock.symbol);
            }
        }

        public async void updateStocksAsync()
        {
            var httpClient = new HttpClient();
            
            foreach (dynamic stock in contents)
            {
                string symbol = stock.symbol;
                var html = await httpClient.GetStringAsync(url + symbol);

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                var updatedPrice = htmlDocument.DocumentNode.Descendants("div")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("Trsdu(0.3s) Fw(b) Fz(36px) Mb(-4px) D(ib)")).ToList();

                //stock.



                //var symbol = stock.symbol;
                //string jsonString;
                //using (var wc = new System.Net.WebClient())
                //{
                //    jsonString = wc.DownloadString(url+symbol);
                //}

                //jsonString = jsonString.Split(new string[] { "\"results\":{\"rows\":" }, StringSplitOptions.None)[1];
                //jsonString = jsonString.Split(new string[] { "]" }, StringSplitOptions.None)[0] + "]";
                //List<dynamic> results = JsonConvert.DeserializeObject<List<dynamic>>(jsonString);
                //results[0].



                //movers.AddRange(results.Take(25));
                ////MoversChanged();

                //Console.WriteLine("Top 25 movers from Yahoo Finance are: ");
                //for (int i = 0; i < movers.Count; i++)
                //{
                //    Console.WriteLine(string.Format("{0} - \t{1} \t{2} \t{3} \t{4}% \t{5} \t{6} \t{7} \t{8} \t{9} \t{10}",
                //        i + 1, movers[i].symbol, movers[i].shortName, movers[i].regularMarketPrice.raw, movers[i].regularMarketChange.raw,
                //        movers[i].regularMarketChangePercent.raw, movers[i].regularMarketVolume.raw, movers[i].averageDailyVolume3Month.raw, movers[i].marketCap.raw, movers[i].fiftyTwoWeekLow.raw,
                //        movers[i].fiftyTwoWeekHigh.raw, movers[i].regularMarketOpen.raw));
                //}
            }
        }


        


        

        public void DisplayStocksDetail()
        {
            Console.WriteLine("Top 25 movers from Yahoo Finance are: ");
            for(int i = 0; i < TradingBot.movers.Count; i++)
            {
                Console.WriteLine(string.Format("{0} - \t{1} \t{2} \t{3} \t{4}% \t{5} \t{6} \t{7} \t{8} \t{9} \t{10}",
                    i+1, TradingBot.movers[i].symbol, TradingBot.movers[i].shortName, TradingBot.movers[i].regularMarketPrice.raw, TradingBot.movers[i].regularMarketChange.raw,
                    TradingBot.movers[i].regularMarketChangePercent.raw, TradingBot.movers[i].regularMarketVolume.raw, TradingBot.movers[i].averageDailyVolume3Month.raw, TradingBot.movers[i].marketCap.raw, TradingBot.movers[i].fiftyTwoWeekLow.raw,
                    TradingBot.movers[i].fiftyTwoWeekHigh.raw, TradingBot.movers[i].regularMarketOpen.raw));
            }
        }
    }
}
