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

        public MenuContent(string title)
        {
            
            this.title = title;
            elements = new List<SelectableElement>();
        }

        public void setOwner(Menu menu)
        {
            owner = menu;
        }
        public abstract void display();
        public abstract void run();

    }
}
