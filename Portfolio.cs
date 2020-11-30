using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{
    public class Portfolio
    {
        //private List<dynamic> movers;
        //private ISubject _bot;
        //we might need an id for each portfolio. Index may be handy for when you navigate
        private string displayName;
        //private string owner;
        public List<dynamic> contents;
        //private TradingBot bot; //Each portfolio might have its own bot
        //ISubject bot;

        public Portfolio(string dn)
        {
            displayName = dn;
            contents = new List<dynamic>();
            
        }

        public void Update(dynamic m)
        {
            Display();
        }

        public string getDisplayName()
        {
            return displayName;
        }

        public List<dynamic> getContents()
        {
            return contents;
        }

        public void addStock(dynamic stock)
        {
            contents.Add(stock);
        }

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

        public void Display()
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
