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

        public override void updateElements()
        {
            elements.Clear();
            loadInitialElements();
            selectedElement = elements[0];
            if (Display.currentUser == null)
                return;
            int i = 1;
            foreach (Portfolio portfolio in Display.currentUser.getPortfolios().Values.ToList())
                {
                SelectableElement portElement = new SelectableElement(false, portfolio.getDisplayName(), Console.WindowWidth / 2 - 5, (i * 2) + 5, del);
                elements.Insert(i - 1, portElement);
                i++;
                }

            //elements.Insert(0, new SelectableElement(false, "Bot-Folio", Console.WindowWidth / 2 - 5, ))
            RequiresUpdate = false;
 
        }

        public void displayPortfolio()
        {
            Portfolio selectedPort = Display.currentUser.getPortfolios()[selectedElement.getDisplayedText()];
            MenuTree tempStockTree = owner.createChildMenu(selectedPort.getDisplayName());
            StockListPage tempStockPage = new StockListPage(selectedPort.getDisplayName(), tempStockTree, selectedPort);
            //owner.setContent(tempStockPage);
            Display.setCurrentMenu(tempStockTree);
            owner.getChildMenuList().Remove(tempStockTree);
        }

        //public override void display()
        //{
            
            
        //}

        public override void run()
        {
            
            if (Display.currentUser != lastUser || RequiresUpdate)
            {
                updateElements();
            }


            lastUser = Display.currentUser;
  
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
