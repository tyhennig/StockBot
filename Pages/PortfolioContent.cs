using StockBot.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace StockBot
{
    //public delegate void DisplayPortfolio(Portfolio p);
    class PortfolioContent : MenuContent
    {

        
        public Action del;
        public PortfolioContent(string title, MenuTree owner) : base(title, owner)
        {
            //del = new DisplayPortfolio(displayPortfolio);
            del = new Action(displayPortfolio);
            selectedElement = elements[0];
        }

        public void updateElements()
        {
            
            int i = 1;
            foreach (Portfolio portfolio in Display.currentUser.getPortfolios().Values.ToList())
                {
                SelectableElement portElement = new SelectableElement(false, portfolio.getDisplayName(), Console.WindowWidth / 2 - 5, (i * 2) + 5, del);
                elements.Insert(i - 1, portElement);
                i++;
                }

           

            lastUser = Display.currentUser;
        }

        public void displayPortfolio()
        {
            Portfolio selectedPort = Display.currentUser.getPortfolios()[selectedElement.getDisplayedText()];
            MenuTree temp = owner.createChildMenu(selectedPort.getDisplayName());
            StockListPage tempStockPage = new StockListPage(selectedPort.getDisplayName(), temp, selectedPort);
            Display.setCurrentMenu(temp);
        }

        //public override void display()
        //{
            
            
        //}

        public override void run()
        {
            if (Display.currentUser != lastUser)
            {
                elements.Clear();
                loadInitialElements();
                selectedElement = elements[0];
                updateElements();
            }
                
            display();
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (elements.IndexOf(selectedElement) == 0)
                        selectedElement = elements[elements.Count - 1];
                    else
                        selectedElement = elements[elements.IndexOf(selectedElement) - 1];
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
