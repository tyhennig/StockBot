using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace StockBot
{
    class PortfolioContent : MenuContent
    {

        private User lastUser = null;
        public PortfolioContent(string title, MenuTree owner) : base(title, owner)
        {
            

        }

        public void updateElements()
        {
            int i = 1;
            foreach (Portfolio portfolio in Display.currentUser.getPortfolios().Values.ToList())
                {
                SelectableElement portElement = new SelectableElement(false, portfolio.getDisplayName(), Console.WindowWidth / 2 - 5, (i * 2) + 5);
                elements.Add(portElement);
                i++;
                }

           

            lastUser = Display.currentUser;
        }

        //public override void display()
        //{
            
            
        //}

        public override void run()
        {
            if (Display.currentUser != lastUser)
                updateElements();
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
