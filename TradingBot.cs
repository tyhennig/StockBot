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
        public static Dictionary<string, Stock> currentTop5 = new Dictionary<string, Stock>();

       


        public static void autoBot()
        {
            foreach(User user in UserDB.userDB.Values.ToList())
            {
                decimal singlestockbudget = (user.getBuyingPower() * 0.5m) * 0.20m; //Calculate how much user is willing to spend on one stock


                if (user.EnabledBot == false)
                    return;
                
                if (user.botfolio.contents.Count == 0)  //To initialize if there are no contents yet
                {
                    for (int i = 0; i < 5; i++)         //for the top 5 stocks in the movers list, buy and add to the botfolio
                    {
                        Stock stock = new Stock(TradingBot.movers[i]);
                        int quantity = (int)(singlestockbudget / stock.regularMarketPrice);
                        if (quantity > 0)
                        {
                            user.buyStock(user.botfolio, stock, quantity);
                        }
                    }
                }
                else  //If the botfolio is not empty 
                {
                    foreach(string symbol in user.botfolio.contents.Keys) //check user's botfolio keys against the top 5 movers, if user key is no longer there: sell
                    {
                        if(!currentTop5.ContainsKey(symbol))
                        {
                            user.sellStock(user.botfolio, user.botfolio.contents[symbol][0], user.botfolio.contents[symbol][0].quantity);
                        } 
                    }
                    if(user.botfolio.contents.Count < 5)     //if user sold previously, check the top 5 keys against the user's keys, if there is a stock we don't own: buy
                    {
                        foreach (string symbol in currentTop5.Keys)
                        {
                            int quantity = (int)(singlestockbudget / currentTop5[symbol].regularMarketPrice);

                            if (!user.botfolio.contents.ContainsKey(symbol))
                            {
                                user.buyStock(user.botfolio, currentTop5[symbol], quantity);
                            }
                        }
                    }
                }

            }
        }


        



public static void FetchMovers()
        {
           
            jsonString = wc.DownloadString(url);
            

            jsonString = jsonString.Split(new string[] { "\"results\":{\"rows\":" }, StringSplitOptions.None)[1];
            jsonString = jsonString.Split(new string[] { "]" }, StringSplitOptions.None)[0] + "]";
            List<dynamic> results = JsonConvert.DeserializeObject<List<dynamic>>(jsonString);
            //Console.WriteLine("Finished JSON parsing");
            //results.AddRange(results.Take(25)); 
            results.RemoveRange(10, 15);
            //movers.Clear();
            //currentTop5.Clear();
            foreach (dynamic stock in results)
            {
                
                movers.Add(new Stock(stock, true));
 
            }

            if(movers.Count != results.Count)
                movers.RemoveRange(0, 10);

            currentTop5.Clear();
            for(int i = 0; i < 5; i++)
            {
                currentTop5.Add(movers[i].symbol, movers[i]);
            }
           
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
