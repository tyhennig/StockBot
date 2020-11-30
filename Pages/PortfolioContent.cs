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
                    Display.setCurrentMenu(owner.getChildMenuList()[elements.IndexOf((SelectableElement)selectedElement)]);
                    break;

                case ConsoleKey.Escape:
                    Display.setCurrentMenu(owner.getParentMenu());
                    break;

            }
        }
    }
}
