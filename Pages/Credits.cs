using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{

    class Credits : MenuContent
    {
        SelectableElement abrahamS;
        SelectableElement tylerH;
        SelectableElement rafaelA;
        public Credits(string title, MenuTree owner) : base(title, owner)
        {
            abrahamS = new SelectableElement(false, "Abraham Solis", 10, 2);
            tylerH = new SelectableElement(false, "Tyler Hennig", 10, 4);
            rafaelA = new SelectableElement(false, "Rafael Amaro", 10, 6);

            elements.Insert(0, abrahamS);
            elements.Insert(1, tylerH);
            elements.Insert(2, rafaelA);
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
