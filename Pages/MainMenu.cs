using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{
    public class MainMenu : MenuContent
    {
        //private Element selectedElement;
        public MainMenu(string title, MenuTree owner) : base(title, owner)
        {
            int i = 1;
            foreach (Element element in elements)
            {
                element.xLocation = Console.WindowWidth / 2 - 5;
                element.yLocation = (i * 2) + 5;
                i++;
            }
        }


        public override void run()
        {
            display();
            ConsoleKeyInfo key = Console.ReadKey();
            switch(key.Key)
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
                    Display.error("Are you sure you want to exit? (y/n)");
                    ConsoleKeyInfo k = Console.ReadKey();
                    if (string.Equals(k.KeyChar.ToString(), "y", StringComparison.OrdinalIgnoreCase))
                        Display.running = false;
                    break;

            }
        }
    }
}
