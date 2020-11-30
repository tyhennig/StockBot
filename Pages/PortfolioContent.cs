using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{
    class PortfolioContent : MenuContent
    {
        public PortfolioContent(string title, MenuTree owner) : base(title, owner)
        {
            
            selectedElement = elements[1];

        }

        public override void display()
        {
            
            foreach (Portfolio portfolio in Display.currentUser.getPortfolios().Values.ToList())
            {
                Console.WriteLine(portfolio.getDisplayName());
            }
        }

        public override void run()
        {
            display();
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (elements.IndexOf((SelectableElement)selectedElement) == 0)
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
                        selectedElement.runMethod();
                    }
                    break;

                case ConsoleKey.Escape:
                    Display.setCurrentMenu(owner.getParentMenu());
                    break;

            }
        }
    }
}
