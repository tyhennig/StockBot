﻿using Microsoft.Data.Edm.Library.Values;
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
        //TradingBot bot;
        Stock selectedStock;

        public Movers(string title, MenuTree owner) : base(title, owner)
        {
            //bot = new TradingBot();
            running = true;
            
        }

        public void addToPortfolio()
        {
            string s = "How many would you like to purchase:  ";
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - s.Length / 2, Console.WindowHeight / 2);
            Console.Write(s);


            if (int.TryParse(Console.ReadLine().ToString(), out int result))
            {
                Console.Clear();
                s = "Which Portfolio would you like to add to?";
                Console.SetCursorPosition(Console.WindowWidth / 2 - s.Length / 2, 5);
                Console.WriteLine(s);
                int i = 1;
                foreach (Portfolio folio in Display.currentUser.getPortfolios().Values)
                {
                    s = folio.getDisplayName();
                    Console.SetCursorPosition(Console.WindowWidth / 2 - s.Length / 2, (i * 2) + 5);
                    Console.Write(i + ". " + s);

                    i++;
                }

                int selectedFolioIndex = int.Parse(Console.ReadKey().KeyChar.ToString()) - 1;
                Console.Clear();
                s = "Confirm purchase of " + result + " " + selectedStock.shortName + ", for a total of $" + (decimal)(selectedStock.regularMarketPrice * result) + "   Current Buying Power: " + Display.currentUser.getBuyingPower() + " (y/n)";
                Console.SetCursorPosition((Console.WindowWidth / 2) - (s.Length / 2), Console.WindowHeight / 2);
                Console.WriteLine(s);
                if (Console.ReadKey().KeyChar == 'y')
                    Display.currentUser.buyStock(Display.currentUser.getPortfolios().Values.ToList()[selectedFolioIndex], selectedStock, result);
            }
            else
            {
                Display.error("Input Number");
            }



        }

        public void updateElements()
        {
            int i = 1;
            
            foreach (Stock stock in TradingBot.movers)
            {
                SelectableElement portElement = new SelectableElement(false, string.Format("{0, -7} {1, -35} {2, 10:C} {3, 10}% {4, 10:C} {5, 10:C}", 
                    stock.symbol, stock.shortName, stock.regularMarketPrice, stock.regularMarketChangePercent, stock.fiftyTwoWeekLow, stock.fiftyTwoWeekHigh),
                    Console.WindowWidth / 4, (i * 2) + 5);
                elements.Add(portElement);
                i++;
            }
             


            lastUser = Display.currentUser;
        }
        

        public override void run()
        {
            
           
            if (Display.currentUser != lastUser || Display.currentUser == null)
            {
                //TradingBot.FetchMovers();
                Console.Clear();
                updateElements();
                selectedElement = elements[0];
            }

       

            //worker.Start();
            display();
            Console.SetCursorPosition(Console.WindowWidth / 4, 5);
            Console.WriteLine(string.Format("{0, -7} {1, -35} {2, 10} {3, 10}% {4, 10} {5, 10}", "Symbol", "Name", "Price", "Growth", "52 wk Low", "52 wk High"));
            
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
