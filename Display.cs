using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{

    public static class Display
    {
        public static User currentUser;

        public static MenuTree currentMenu;
        public static bool running = true;
        //static bool clearScreen = true;
        //static int selection = 0;

        public static void setCurrentMenu(MenuTree menu)
        {
            foreach(SelectableElement element in currentMenu.getContent().getSelectableElements())
            {
                element.clearValue();
            }
            currentMenu = menu;
        }

        public static void run(MenuTree root)
        {
            currentMenu = root;
            
            while(running)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);
                if(currentUser != null)
                    Console.Write("Current User: " + currentUser.Username);
                Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 3);

                currentMenu.run();  
            }
            

        }

        internal static void error(string v)
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            Console.Write(v);
        }
    }
}
