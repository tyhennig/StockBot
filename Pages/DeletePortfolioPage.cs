using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{
    class DeletePortfolioPage : MenuContent
    {
        SelectableElement portfolioName;
        SelectableElement delete;

        Action del;
        public DeletePortfolioPage(string title, MenuTree owner) : base(title, owner)
        {
            del = new Action(deletePortfolio);
            //portfolioName = new SelectableElement(true, "Portfolio Name: ", 10, 2);
            //delete = new SelectableElement(false, "Delete", 10, 4);

            //elements.Insert(0, portfolioName);
            //elements.Insert(1, delete);


            //selectedElement = elements[0];
        }

        public void deletePortfolio()
        {
            Display.error("Are you sure you want to delete " + selectedElement.getDisplayedText() + "? (y/n)");
            if (string.Equals(Console.ReadKey().KeyChar.ToString(), "y", StringComparison.OrdinalIgnoreCase))
            {
                Display.currentUser.getPortfolios().Remove(selectedElement.getDisplayedText());
                RequiresUpdate = true;
                owner.getParentMenu().getContent().RequiresUpdate = true;
                Display.setCurrentMenu(owner.getParentMenu());
            }
        }

        public override void updateElements()
        {
            elements.Clear();
            loadInitialElements();
            
            if (Display.currentUser == null)
                return;
            int i = 1;
            foreach (Portfolio portfolio in Display.currentUser.getPortfolios().Values.ToList())
            {
                SelectableElement portElement = new SelectableElement(false, portfolio.getDisplayName(), Console.WindowWidth / 2 - 5, (i * 2) + 5, del);
                elements.Insert(i - 1, portElement);
                i++;
            }
            selectedElement = elements[0];
            RequiresUpdate = false;

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
            if (Display.currentUser.getPortfolios().Count != elements.Count)
                RequiresUpdate = true;

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
