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
        
        public string url = "https://finance.yahoo.com/gainers";
        public static List<dynamic> movers;

        public TradingBot()
        {
            
        }

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

        public void buyStock()
        {
            //this.movers
        }




        //public void StockPool

        //public async void scrapeHTML(string url)
        //{
        //    //needs Microsoft.Hadoop.WebClient
        //    var httpClient = new HttpClient();
        //    //needs Microsoft.Bcl.Async
        //    var html = await httpClient.GetStringAsync(url);

        //    //needs HtmlAgilityPack
        //    var htmlDocument = new HtmlDocument();
        //    htmlDocument.LoadHtml(html);

        //    var topDogsHtml = htmlDocument.DocumentNode.Descendants("table")
        //        .Where(node => node.GetAttributeValue("class", "")
        //        .Equals("W(100%)")).ToList();

        //    var topDogsList = topDogsHtml[0].Descendants("tr")
        //        .Where(node => node.GetAttributeValue("class", "")
        //        .Contains("simpTblRow")).ToList();

        //    //var x = topDogsHtml[0].InnerText;
            

        //    foreach (var topDog in topDogsList)
        //    {
        //        //Console.WriteLine(topDog.Descendants("a")
        //        //    .Where(node => node.GetAttributeValue("class", "")
        //        //    .Contains("Fw(600)")));
        //        Console.WriteLine(topDog.InnerText);
        //    }

        //    //use json file to extract data

        //    Console.WriteLine();
            
        //}

    }
}
