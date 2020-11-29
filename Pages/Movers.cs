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
        Portfolio currentDisplay;
        public Movers(string title, MenuTree owner) : base(title, owner)
        {
            bot = new TradingBot();
            currentDisplay = new Portfolio("default");
            running = true;

        }
        public override void display()
        {
            throw new NotImplementedException();
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
                    if(running)
                        currentDisplay.Display();
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
