using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{

    public static class Display
    {
        public static Menu currentMenu;
        static bool running = true;
        static bool clearScreen = true;
        static int selection = 0;

        

        public static void run(Menu mainMenu)
        {
            currentMenu = mainMenu;
            
            while(running)
            {
                currentMenu.displayChildren();
                
                Console.MoveBufferArea(0, selection, 10, 1, 1, 0);
                Console.SetCursorPosition(0, selection);
                Console.Write(">");
                ConsoleKeyInfo key = Console.ReadKey();
                switch(key)
                {
                    case ConsoleKey.UpArrow:

                    case ConsoleKey.DownArrow:
                }

            }
            

        }

        

    }
}
