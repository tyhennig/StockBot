using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{

    //public delegate void Action();
    class CreatePortfolio : MenuContent
    {
        SelectableElement portfolioName;
        SelectableElement create;

        public CreatePortfolio(string title, MenuTree owner) : base(title, owner)
        {
            Action delegate1 = new Action(createPortfolio);

            portfolioName = new SelectableElement(true, "Portfolio Name: ", 10, 2);
            create = new SelectableElement(false, "Create", 10, 4 , delegate1);

            elements.Insert(0, portfolioName);
            elements.Insert(1, create);

            selectedElement = elements[0];
        }

        void createPortfolio()
        {
            if (Display.currentUser == null)
                Display.error("Not Logged In!");
            else if(Display.currentUser.getPortfolios().Count >= 13) // Limits portfolios to 13 in order to not go past the childMenus
            {
                Display.error("Portfolio Limit is Reached!");
            } 
            else
            {
              
                Display.currentUser.createPortfolio(portfolioName.getValue());
                owner.getParentMenu().getContent().RequiresUpdate = true;
                Display.setCurrentMenu(owner.getParentMenu());

            }

        }

        public override void display()
        {
            foreach (Element element in elements)
            {
                if (element == selectedElement)
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(element.xLocation, element.yLocation);
                Console.Write(element.displayedText);
                Console.ForegroundColor = ConsoleColor.White;
                if (((SelectableElement)element).TakesText)
                    Console.Write(((SelectableElement)element).getValue());
            }
        }

        public override void run()
        {
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
                    if (elements.IndexOf(selectedElement) == elements.Count - 1)
                        selectedElement = elements[0];
                    else
                        selectedElement = elements[elements.IndexOf(selectedElement) + 1];
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

                case ConsoleKey.Backspace:
                    if (selectedElement.TakesText)
                        (selectedElement).delFromValue();
                    break;

                default:
                    if (Char.IsLetterOrDigit(key.KeyChar))
                    {
                        if (selectedElement.TakesText)
                            (selectedElement).addToValue(key.KeyChar);
                        //usernameInput.setDisplayedText(usernameInput.getDisplayedText() + key.KeyChar);
                    }
                    break;
            }
        }






    }
}
