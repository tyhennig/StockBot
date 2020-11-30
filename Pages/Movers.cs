using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace StockBot
{
    class Movers : MenuContent
    {
        bool running;
        string url = "https://finance.yahoo.com/gainers";
        TradingBot bot;

        public Movers(string title, MenuTree owner) : base(title, owner)
        {
            bot = new TradingBot();
            running = true;
        }
        public override void display()
        {
            Console.WriteLine("Top 25 movers from Yahoo Finance are: ");
            
            for (int i = 0; i < TradingBot.movers.Count; i++)
            {
                Console.WriteLine(string.Format("{0} - \t{1} \t{2} \t{3} \t{4}% \t{5} \t{6} \t{7} \t{8} \t{9} \t{10}",
                    i + 1, TradingBot.movers[i].symbol, TradingBot.movers[i].shortName, TradingBot.movers[i].regularMarketPrice.raw, TradingBot.movers[i].regularMarketChange.raw,
                    TradingBot.movers[i].regularMarketChangePercent.raw, TradingBot.movers[i].regularMarketVolume.raw, TradingBot.movers[i].averageDailyVolume3Month.raw, TradingBot.movers[i].marketCap.raw, TradingBot.movers[i].fiftyTwoWeekLow.raw,
                    TradingBot.movers[i].fiftyTwoWeekHigh.raw, TradingBot.movers[i].regularMarketOpen.raw));
            }
        }

        public override void run()
        {
            running = true;
            var worker = new Thread(() =>
            {
                while (running)
                {
                    
                    bot.FetchMovers();
                    Console.Clear();
                    if (running)
                        display();
                    Thread.Sleep(1000);
                }
            });

            worker.Start();

            if(Console.ReadKey().Key == ConsoleKey.Escape)
            {
                running = false;
                Console.Clear();
                Display.setCurrentMenu(owner.getParentMenu());
            }
            
            
        }
    }
}
