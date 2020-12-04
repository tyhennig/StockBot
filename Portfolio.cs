using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using HtmlAgilityPack;
using System.Threading.Tasks;

namespace StockBot
{
    public class Portfolio
    {
        //private List<dynamic> movers;
        //we might need an id for each portfolio. Index may be handy for when you navigate
        private string displayName;
        //private string owner;
        public Dictionary<string, List<Stock>> contents;
        //public Dictionary<string, decimal> currentStockPrices;
        //private TradingBot bot; //Each portfolio might have its own bot
        public string url = "https://finance.yahoo.com/quote/";


        public Portfolio(string dn)
        {
            displayName = dn;
            contents = new Dictionary<string, List<Stock>>();
            //currentStockPrices = new Dictionary<string, decimal>();
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


        //
        public decimal removeStock(string symbol, decimal price, int quantity)
        {
            int qtyNeedToBeSold = quantity;
            int amountInLast = 0;
            decimal total = 0m;
            while (qtyNeedToBeSold != 0)
            {
                amountInLast = contents[symbol][contents[symbol].Count - 1].quantity;
                contents[symbol][contents[symbol].Count - 1].quantity =
                contents[symbol][contents[symbol].Count - 1].quantity - qtyNeedToBeSold;



                if(contents[symbol][contents[symbol].Count - 1].quantity > 0)
                {
                    total += qtyNeedToBeSold * price;
                    break;
                }

                total += amountInLast * price;
                
                qtyNeedToBeSold -= amountInLast;

                if(contents[symbol][contents[symbol].Count - 1].quantity <= 0)
                {
                    contents[symbol].RemoveAt(contents[symbol].Count - 1);
                }
                
            }
            return total;
        }

        //public void removeStock(dynamic stock)
        //{
        //    contents.Remove(stock);
        //}

        public bool isEmpty()
        {
            
            return true;
        }



        public void displayPortfolio()
        {
            foreach (dynamic stock in contents.Values) //iterates list, writes stock ToString() to console
            {
                Console.WriteLine(stock);
            }
        }

        public void displayPorfolioContent()
        {
            foreach(var stock in contents)
            {
                Console.WriteLine(stock.Key + "  " + stock.Value.Count());
            }
        }

        

        public decimal updateStockPricesAsync(Stock stock)
        {
            var httpClient = new HttpClient();
            string html;
            using (var wc = new System.Net.WebClient())
            {
                html = wc.DownloadString(url + stock.symbol);
            }

            //var html = await httpClient.GetStringAsync(url + stock.symbol);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var updatedPrice = htmlDocument.DocumentNode.Descendants("span")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("Trsdu(0.3s) Fw(b) Fz(36px) Mb(-4px) D(ib)")).ToList();

            decimal p = Convert.ToDecimal(updatedPrice[0].InnerText);

            return p;
            
        }







        public void DisplayStocksDetail()
        {
            Console.WriteLine("Top 25 movers from Yahoo Finance are: ");
            for(int i = 0; i < TradingBot.movers.Count; i++)
            {
                Console.WriteLine(string.Format("{0} - \t{1} \t{2} \t{3} \t{4}% \t{5} \t{6} \t{7} \t{8}",
                    i + 1, TradingBot.movers[i].symbol, TradingBot.movers[i].shortName, TradingBot.movers[i].regularMarketPrice, TradingBot.movers[i].regularMarketChange,
                    TradingBot.movers[i].regularMarketChangePercent, TradingBot.movers[i].fiftyTwoWeekLow,
                    TradingBot.movers[i].fiftyTwoWeekHigh, TradingBot.movers[i].regularMarketOpen));
            }
        }
    }
}
