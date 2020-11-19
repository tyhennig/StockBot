using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using HtmlAgilityPack;

namespace StockBot
{
    class TradingBot
    {
        public TradingBot()
        {

        }

        public async void scrapeHTML(string url)
        {
            //needs Microsoft.Hadoop.WebClient
            var httpClient = new HttpClient();
            //needs Microsoft.Bcl.Async
            var html = await httpClient.GetStringAsync(url);

            //needs HtmlAgilityPack
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var topDogsHtml = htmlDocument.DocumentNode.Descendants("table")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("W(100%)")).ToList();

            //var topDogsList = topDogs[0].Descendants();

            Console.WriteLine();
            
        }

    }
}
