using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{
    class Menu
    {
        private bool isSubMenu;
        private List<MenuItem> menuItems;
        private static int currentMenuID = 0;
        private int menuID;

        public Menu(bool isSubMenu)
        {
            menuID = ++currentMenuID;
            isSubMenu = this.isSubMenu;
        }

        public void addMenuItem(MenuItem item)
        {
            menuItems.Add(item);
        }
    }

    class MenuItem
    {
        private string title;
        private int parentMenuID;
        private int childMenuID;
        MenuItem(string title)
        {
            title = this.title;

        }
    }
}
