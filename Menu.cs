using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{
    public class Menu
    {
       
        private static int currentMenuID = 0;
        //private int menuID;
        //private Nullable<int> parentID;
        protected string title;
        private bool hasContent;//may not be necessary

        private MenuContent content;
        private Menu parentMenu;
        private List<Menu> childMenus;



        /*
         * I strongly dislike this way of doing this
         * (Having a separate list for the content menus)
         * 
         * PROBLEM: You can not add derived objects to a List<BaseClass>
         * This makes sense as you wouldn't want to add a Cat AND Dog object to a List<Mammal>
         * 
         *Each Basic Menu object obviously has a list of its children
         *but because we are creating a new class for the menus with actual content we can't keep them in the same list
         *I like the fact you can easily create a menu hierarchy using this class,
         *but I think more critical thinking needs to be done regarding how to distinguish Menus with actual content
         *
         *POSSIBLE SOLUTION: Have a bool hasContent flag in the constructor that creates a Content class, 
         *Content class would not inherit from anything it would be totally separate.
         *
         */
        //private List<MenuContent> childContent;



        public Menu(/*Nullable<int> parentID, */string title, bool hasContent)
        {
            //this.menuID = ++currentMenuID;
            //this.parentID = parentID;
            this.hasContent = hasContent; //May not be necessary
            this.title = title;
            childMenus = new List<Menu>();
            if(hasContent)
                content = new MenuContent(this, "Howdy do day partner, this is content for " + title);

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
            Menu newMenu = new Menu(/*this.menuID, */title, hasContent);
            newMenu.parentMenu = this;
            childMenus.Add(newMenu);

            return newMenu;
        }



        public void displayMenu()
        {
            Console.Clear();
            Console.SetCursorPosition(0,0);
            int childNumber = 1;
            if(hasContent)
            {
                this.content.display();
            }
            foreach(Menu childMenu in childMenus)
            {
                Console.WriteLine(childNumber + ". " + childMenu.title);
               
                childNumber++;
            }
        }


    }

}
