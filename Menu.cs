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

        public Menu(string title)
        {
            
            this.title = title;
            childMenus = new List<Menu>();
        }
        public Menu(string title, MenuContent content)
        {
            this.title = title;
            childMenus = new List<Menu>();
            this.content = content;
            content.setOwner(this);
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


        public Menu createChildMenu(string title, MenuContent content)
        {
            Menu newMenu = new Menu(title, content);
            newMenu.parentMenu = this;
            childMenus.Add(newMenu);

            return newMenu;
        }

        public Menu createChildMenu(string title)
        {
            Menu newMenu = new Menu(title);
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
