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
            foreach(Element element in elements)
            {
                element.xLocation = Console.WindowWidth / 2 - 5;
                element.yLocation = (i * 2) + 5;
                i++;
            }
            selectedElement = elements[0];
        }

        public override void display()
        {
            foreach(Element element in elements)
            {
                if (element == selectedElement)
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(element.xLocation, element.yLocation);
                Console.Write(element.displayedText);
                Console.ForegroundColor = ConsoleColor.White;
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
                        selectedElement = elements[2];
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
                    Display.running = false;
                    break;

            }
        }
    }
}
