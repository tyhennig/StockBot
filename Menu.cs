using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{
    class Menu
    {
        private bool isSubMenu;
        //private List<MenuItem> menuItems;
        private static int currentMenuID = 0;
        private int menuID;
        private int parentID;


        public Menu(bool isSubMenu)
        {
            menuID = ++currentMenuID;
            isSubMenu = this.isSubMenu;
        }

        public void createMenuItem(string title)
        {
            menuItems.Add(new MenuItem(title));
        }



        public void displayMenu()
        {
            Console.SetCursorPosition(0,0);
            foreach(MenuItem menuItem in menuItems)
            {
                Console.WriteLine(menuItem.title);
            }
        }


    }

    /*
    class MenuItem
    {
        private string title{get; set;}
        private int parentMenuID;
        private int childMenuID;
        MenuItem(string title, int parentMenuID, )
        {
            title = this.title;

        }
    }
    */
}
