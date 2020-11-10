using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{
    public class Menu
    {

        protected string title;
        private bool hasContent;

        private MenuContent content;
        private Menu parentMenu;
        private List<Menu> childMenus;

        public Menu(string title, bool hasContent)
        {
            
            this.hasContent = hasContent;
            this.title = title;
            childMenus = new List<Menu>();
            if(hasContent)
                content = new MenuContent(this, "Howdy do day partner, this is content for " + title);

        }
        public bool getHasContent()
        {
            return hasContent;
        }

        public MenuContent getContent()
        {
            return content;
        }
        
        public Menu getParentMenu()
        {
            return parentMenu;
        }

        public List<Menu> getChildMenuList()
        {
            return childMenus;
        }


        public Menu createChildMenu(string title, bool hasContent)
        {
            Menu newMenu = new Menu(title, hasContent);
            newMenu.parentMenu = this;
            childMenus.Add(newMenu);

            return newMenu;
        }



        public void displayChildren()
        {
            
            
            int childNumber = 1;
            foreach(Menu childMenu in childMenus)
            {
                Console.WriteLine(childMenu.title);
               
                childNumber++;
            }
        }


    }

}
