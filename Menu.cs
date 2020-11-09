using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{
    public class Menu
    {
       
        private static int currentMenuID = 0;
        private int menuID;
        private Nullable<int> parentID;
        private string title;

        private List<Menu> childMenus;


        public Menu(Nullable<int> parentID, string title)
        {
            this.menuID = ++currentMenuID;
            this.parentID = parentID;
            this.title = title;
            childMenus = new List<Menu>();

        }

        public List<Menu> getChildMenuList()
        {
            return childMenus;
        }

        public Menu createChildMenu(string title)
        {
            Menu newMenu = new Menu(this.menuID, title);
            childMenus.Add(newMenu);

            return newMenu;
        }



        public void displayMenu()
        {
            Console.Clear();
            Console.SetCursorPosition(0,0);
            int childNumber = 1;
            foreach(Menu childMenu in childMenus)
            {
                Console.WriteLine(childNumber + ". " + childMenu.title);
                childNumber++;
            }
        }


    }

}
