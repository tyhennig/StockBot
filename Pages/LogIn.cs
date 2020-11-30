using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{
    class LogIn : MenuContent
    {
        SelectableElement usernameInput;
        SelectableElement passwordInput;
        public LogIn(string title, MenuTree owner) : base(title, owner)
        {
            usernameInput = new SelectableElement(true, "Username: ", 10, 2);
            passwordInput = new SelectableElement(true, "Password: ", 10, 4);
            elements.Insert(0, usernameInput);
            elements.Insert(1, passwordInput);
            selectedElement = usernameInput;

            elements[2].xLocation = Console.WindowWidth / 2 - 5;
            elements[2].yLocation = Console.WindowHeight - 8;

            elements[3].xLocation = Console.WindowWidth / 2 - 5;
            elements[3].yLocation = Console.WindowHeight - 6;

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
                    Display.setCurrentMenu(owner.getChildMenuList()[elements.IndexOf((SelectableElement)selectedElement)]);
                    break;

                case ConsoleKey.Escape:
                    Display.setCurrentMenu(owner.getParentMenu());
                    break;

                default:
                    if(Char.IsLetterOrDigit(key.KeyChar))
                    {
                        usernameInput.setDisplayedText(usernameInput.getDisplayedText() + key.KeyChar);
                    }
                    break;
            }
            }
        }
}
