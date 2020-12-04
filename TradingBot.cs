using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public static string jsonString = "";
        public static WebClient wc = new WebClient();

        public static void initializeBot()
        {
            
            
        }


public static void FetchMovers()
        {
           
            jsonString = wc.DownloadString(url);
            

            jsonString = jsonString.Split(new string[] { "\"results\":{\"rows\":" }, StringSplitOptions.None)[1];
            jsonString = jsonString.Split(new string[] { "]" }, StringSplitOptions.None)[0] + "]";
            List<dynamic> results = JsonConvert.DeserializeObject<List<dynamic>>(jsonString);
            //Console.WriteLine("Finished JSON parsing");
            //results.AddRange(results.Take(25)); 
            results.RemoveRange(9, 14);
            //movers.Clear();
           
            foreach (dynamic stock in results)
            {
                
                movers.Insert(0, new Stock(stock, true));
                
            }
            if(movers.Count != results.Count)
                movers.RemoveRange(9, movers.Count - 10);
           
        }

        

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
