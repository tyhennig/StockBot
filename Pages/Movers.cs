using Microsoft.Data.Edm.Library.Values;
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
        dynamic selectedStock;

        public Movers(string title, MenuTree owner) : base(title, owner)
        {
            bot = new TradingBot();
            running = true;
            
        }

        public void addToPortfolio()
        {
            Console.Clear();
            Console.WriteLine("Which Portfolio would you like to add to?");
            int i = 1;
            foreach(Portfolio folio in Display.currentUser.getPortfolios().Values)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 5, (i * 2) + 5);
                Console.Write(i + ". " + folio.getDisplayName());

                i++;
            }

            int temp = (int)char.GetNumericValue(Console.ReadKey().KeyChar);
            

            Display.currentUser.getPortfolios().Values.ToList()[temp -1].addStock(selectedStock);

        }

        public void updateElements()
        {
            //int i = 1;
            for (int i = 0; i < TradingBot.movers.Count; i++)
            {
                SelectableElement portElement = new SelectableElement(false, (string.Format("{0} - {1} \t{2} \t{3} \t{4} \t",
                    i + 1,TradingBot.movers[i].shortname, TradingBot.movers[i].symbol, TradingBot.movers[i].regularMarketPrice.raw)), Console.WindowWidth / 2 - 5, (i * 2) + 5);
                elements.Add(portElement);
                //i++;
            }



            lastUser = Display.currentUser;
        }
        

        public override void run()
        {
            
            //running = true;
            //var worker = new Thread(() =>
            //{
            //    while (running)
            //    {
                    
                    
                    //if (running)
                        if (Display.currentUser != lastUser || Display.currentUser == null)
                        {
                            bot.FetchMovers();
                            Console.Clear();
                            updateElements();
                            selectedElement = elements[0];
                        }

       

            //worker.Start();
            display();
            //if(Console.ReadKey().Key == ConsoleKey.Escape)
            //{
            //    running = false;
            //    Console.Clear();
            //    Display.setCurrentMenu(owner.getParentMenu());
            //}
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (elements.IndexOf(selectedElement) == 0)
                        selectedElement = elements[elements.Count - 1];
                    else
                        selectedElement = elements[elements.IndexOf((SelectableElement)selectedElement) - 1];
                    break;

                case ConsoleKey.DownArrow:
                    if (elements.IndexOf((SelectableElement)selectedElement) == elements.Count - 1)
                        selectedElement = elements[0];
                    else
                        selectedElement = elements[elements.IndexOf((SelectableElement)selectedElement) + 1];
                    break;

                case ConsoleKey.Enter:
                    if (selectedElement.IsMenu)
                    {
                        Display.setCurrentMenu(owner.getChildMenuList().Where(menu => menu.getTitle().Equals(selectedElement.displayedText)).ToList()[0]);
                    }
                    else
                    {
                        selectedStock = TradingBot.movers[elements.IndexOf(selectedElement)];
                        addToPortfolio();
                    }
                    break;

                case ConsoleKey.Escape:
                    Display.setCurrentMenu(owner.getParentMenu());
                    break;

            }


        }
    }
}
