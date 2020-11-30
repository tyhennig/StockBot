using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StockBot
{

    public abstract class MenuContent
    {
        private string title;
        protected MenuTree owner;

        protected List<SelectableElement> elements;
        protected Element selectedElement;

        public MenuContent(string title, MenuTree owner)
        { 
            this.title = title;
            this.owner = owner;
            owner.setContent(this);
            elements = new List<SelectableElement>();
            loadInitialElements();

        }

        public void setOwner(MenuTree menu)
        {
            owner = menu;
        }

        public void loadInitialElements()
        {
            int xSpacing;
            int ySpacing;
            int i = 0;

            //int i = Console.BufferHeight - owner.getChildMenuList().Count();
            foreach(MenuTree child in owner.getChildMenuList())
            {
                xSpacing = Console.WindowWidth / 2 - 5;
                ySpacing = Console.WindowHeight - (8 - (2 * i));
                SelectableElement temp = new SelectableElement(false, child.getTitle(), xSpacing, ySpacing);
                elements.Add(temp);
                i++;
            }
        }
        public List<SelectableElement> getSelectableElements()
        {
            return elements;
        }
        public virtual void display()
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
        public abstract void run();

    }
}
