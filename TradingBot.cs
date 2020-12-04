using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace StockBot
{
    public static class TradingBot
    {

        //fetching movers might have to be moved somewhere else.
        public static string url = "https://finance.yahoo.com/gainers";
        public static List<Stock> movers = new List<Stock>();
        public static List<Stock> shortMovers = new List<Stock>();

        



        //public void NotifyObservers()
        //{
        //    foreach(IObserver observer in observers)
        //    {
        //        observer.Update(movers);
        //    }
        //}

        //public void MoversChanged()
        //{
        //    NotifyObservers();
        //}

        //add aggressive, normal, and safe options
        
        
        //add something like if(active) then work
        public static void FetchMovers()
        {
            movers.Clear();
            string jsonString;
            using (var wc = new System.Net.WebClient())
            {
                jsonString = wc.DownloadString(url);
            }

            jsonString = jsonString.Split(new string[] { "\"results\":{\"rows\":" }, StringSplitOptions.None)[1];
            jsonString = jsonString.Split(new string[] { "]" }, StringSplitOptions.None)[0] + "]";
            List<dynamic> results = JsonConvert.DeserializeObject<List<dynamic>>(jsonString);
            //results.AddRange(results.Take(25)); 
            results.RemoveRange(9, 14);
            movers.Clear();
            //Console.WriteLine("Movers UPDATED!");
            foreach (dynamic stock in results)
            {
                movers.Add(new Stock(stock, true));
            }
            

            //MoversChanged();

            //Console.WriteLine("Top 25 movers from Yahoo Finance are: ");
            //for(int i = 0; i < movers.Count; i++)
            //{
            //    Console.WriteLine(string.Format("{0} - \t{1} \t{2} \t{3} \t{4}% \t{5} \t{6} \t{7} \t{8}",
            //        i+1, movers[i].symbol, movers[i].shortName, movers[i].regularMarketPrice, movers[i].regularMarketChange,
            //        movers[i].regularMarketChangePercent, movers[i].fiftyTwoWeekLow,
            //        movers[i].fiftyTwoWeekHigh, movers[i].regularMarketOpen));
            //}
        }

        //public async void updateStockPricesAsync()
        //{
        //    var httpClient = new HttpClient();

        //    //stock string is null?????
        //    foreach (var stock in currentStockPrices)
        //    {
        //        var html = await httpClient.GetStringAsync(url + stock.Key);

        //        var htmlDocument = new HtmlDocument();
        //        htmlDocument.LoadHtml(html);

        //        var updatedPrice = htmlDocument.DocumentNode.Descendants("span")
        //            .Where(node => node.GetAttributeValue("class", "")
        //            .Equals("Trsdu(0.3s) Fw(b) Fz(36px) Mb(-4px) D(ib)")).ToList();

        //        decimal p = Convert.ToDecimal(updatedPrice[0].InnerText);

        //        currentStockPrices[stock.Key] = p;
        //    }
        //}

        //public void botBuy(User user)
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        user.folio.buyStock(folio, TradingBot.movers[i], 5);
        //    }


        //    foreach (dynamic stock in folio.contents)
        //    {

        //        string symbol = stock.symbol;
        //        for (int i = 0; i < 5; i++)
        //        {
        //            if (TradingBot.movers[i].symbol.Equals(symbol))
        //            {
        //                Console.WriteLine("Match");
        //            }
        //        }

        //    }
        //    //for (int i = 0; i < 5; i++)
        //    //{
        //    //    buyStock(folio, TradingBot.movers[i], 2);
        //    //}

        //}

        public static async Task<decimal> updateStockPricesAsync(Stock stock)
        {
            var httpClient = new HttpClient();


            var html = await httpClient.GetStringAsync(url + stock.symbol);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var updatedPrice = htmlDocument.DocumentNode.Descendants("span")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("Trsdu(0.3s) Fw(b) Fz(36px) Mb(-4px) D(ib)")).ToList();

            decimal p = Convert.ToDecimal(updatedPrice[0].InnerText);

            return p;

        }


        public static void aggressiveBuy()
        {
            //if (this.movers.Count() > 0)
            {

            }
        }

        public static void buyStock(dynamic stock)
        {
            //Portfolio.
        }
    }
}
