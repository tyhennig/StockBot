using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot.Pages
{
    class StockListPage : MenuContent
    {
        
        Portfolio p;
        Stock selectedStock;
        public StockListPage(string title, MenuTree owner, Portfolio p) : base(title, owner)
        {
            this.p = p;
        }

        public void sellSelectedStock()
        {
            selectedStock = p.contents.Values.ToList()[0][0];

            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 3 - 6, 15);
            Console.Write("How many do you wish to sell:  ");

            if (int.TryParse(Console.ReadLine().ToString(), out int result))
            {
                Console.Clear();
                Console.SetCursorPosition(Console.WindowWidth / 3 - 6, 15);
                Console.Write("Are you sure you wish to sell " + result + " shares of " + selectedStock.shortName + "? (y/n)");
                if (Console.ReadKey().KeyChar == 'y')
                {
                    Console.Clear();
                    Console.SetCursorPosition(Console.WindowWidth / 3 - 6, 15);
                    Display.currentUser.sellStock(p, selectedStock, result);
                    Console.ReadKey();
                }
            }

            }

        public void updateElements()
        {
            int i = 1;
            

            foreach(List<Stock> stocks in p.contents.Values)
            {
                decimal avgPrice = 0;
                int numOwned = 0;

                foreach(Stock st in stocks)
                {
                    numOwned += st.quantity;
                    avgPrice += st.regularMarketPrice * st.quantity;
                }

                avgPrice /= numOwned;
                Stock stock = stocks[0];
                
                SelectableElement portElement = new SelectableElement(false, string.Format("{0, -7} {1, -35} {2, 10} {3, 10}", stock.symbol, stock.shortName, avgPrice, numOwned), Console.WindowWidth / 3 - 6, (i * 2) + 5);
                
                elements.Add(portElement);
                i++;
            }
            selectedElement = elements[0];
            lastUser = Display.currentUser;
        }
        public override void run()
        {
            if (Display.currentUser != lastUser || RequiresUpdate)
                updateElements();

            display();
            Console.SetCursorPosition(Console.WindowWidth / 3 - 6, 5);
            Console.WriteLine(string.Format("{0, -7} {1, -35} {2, 13} {3, 10}", "Symbol", "Name", "Avg Price", "Shares"));

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
                    sellSelectedStock();
                    break;

                case ConsoleKey.Escape:
                    Display.setCurrentMenu(owner.getParentMenu());
                    break;

            }
        }
    }
}
