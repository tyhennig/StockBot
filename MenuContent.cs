using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StockBot
{

    //hey nerd  ̿̿ ̿̿ ̿̿ ̿'̿'\̵͇̿̿\з= ( ▀ ͜͞ʖ▀) =ε/̵͇̿̿/’̿’̿ ̿ ̿̿ ̿̿ ̿̿
    //hey sexy ;)       (ง'̀-'́)ง
    //                                   (╯°□°)╯︵◓      ฅ^•ﻌ•^ฅ
    //      ಠ_ಠ
    public abstract class MenuContent
    {
        private string title;
        protected Menu owner;

        protected List<SelectableElement> elements;

        public MenuContent(string title, Menu owner)
        { 
            this.title = title;
            this.owner = owner;
            owner.setContent(this);
            elements = new List<SelectableElement>();
            

        }

        public void setOwner(Menu menu)
        {
            owner = menu;
        }

        public void loadElements()
        {

            //int i = Console.BufferHeight - owner.getChildMenuList().Count();
            int i = 5;
            foreach(Menu child in owner.getChildMenuList())
            {
                SelectableElement temp = new SelectableElement(false, child.getTitle(), 5, i);
                elements.Add(temp);
                i++;
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
