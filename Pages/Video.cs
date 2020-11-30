using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{
    class Video : MenuContent
    {
        SelectableElement soon;
        public Video(string title, MenuTree owner) : base(title, owner)
        {
            soon = new SelectableElement(false, "Video Settings Coming Soon!", 10, 2);

            elements.Insert(0, soon);
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
                        Display.setCurrentMenu(owner.getChildMenuList()[elements.IndexOf(selectedElement)]);
                    break;

                case ConsoleKey.Escape:
                    Display.setCurrentMenu(owner.getParentMenu());
                    break;

                case ConsoleKey.Backspace:
                    if (selectedElement.TakesText)
                        (selectedElement).delFromValue();
                    break;

            }
        }

    }
}
