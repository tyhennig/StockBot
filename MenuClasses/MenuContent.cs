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
        protected SelectableElement selectedElement;

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
            int xLocation;
            int yLocation;

            //int i = Console.BufferHeight - owner.getChildMenuList().Count();
            foreach(MenuTree child in owner.getChildMenuList())
            {


                SelectableElement temp = new SelectableElement(false, child.getTitle());
                temp.IsMenu = true;
                elements.Add(temp);
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
