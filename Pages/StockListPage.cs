using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot.Pages
{
    class StockListPage : MenuContent
    {
        private User lastUser = null;
        Portfolio p;
        public StockListPage(string title, MenuTree owner, Portfolio p) : base(title, owner)
        {
            this.p = p;
        }

        public void updateElements()
        {
            int i = 1;
            foreach(dynamic stock in p.getContents())
            {
                SelectableElement stockElement = new SelectableElement(false, (string)stock.symbol + "\t" + (string)stock.regularMarketPrice.raw, Console.WindowWidth / 2 - 5, (i * 2) + 5);
                elements.Add(stockElement);
                i++;
            }



            lastUser = Display.currentUser;
        }
        public override void run()
        {
            if (Display.currentUser != lastUser)
                updateElements();
            display();
            Console.ReadKey();
            Display.setCurrentMenu(owner.getParentMenu());
        }
    }
}
