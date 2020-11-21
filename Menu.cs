﻿using System;
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
            hasContent = false;
        }

        public string getTitle()
        {
            return title;
        }
        public bool getHasContent()
        {
            return hasContent;
        }

        public MenuContent getContent()
        {
            return content;
        }
        public void setContent(MenuContent content)
        {
            this.content = content;
            hasContent = true;
        }
        
        public Menu getParentMenu()
        {
            return parentMenu;
        }

        public List<Menu> getChildMenuList()
        {
            return childMenus;
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
