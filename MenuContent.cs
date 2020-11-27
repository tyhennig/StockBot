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
            //int i = Console.BufferHeight - owner.getChildMenuList().Count();
            foreach(MenuTree child in owner.getChildMenuList())
            {
                SelectableElement temp = new SelectableElement(false, child.getTitle());
                elements.Add(temp);
            }
        }
        public List<SelectableElement> getSelectableElements()
        {
            return elements;
        }
        public abstract void display();
        public abstract void run();

    }
}
