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

        

        public static void run(Menu mainMenu)
        {
            currentMenu = mainMenu;
            while(running)
            {

                currentMenu.displayMenu();
                int selection;
                if(Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out selection))
                {
                    if(selection > 0 && selection <= currentMenu.getChildMenuList().Count)
                    {
                        currentMenu = currentMenu.getChildMenuList()[selection-1];
                    }
                    else
                    {
                        Console.WriteLine("Please Input value between 0 and " + currentMenu.getChildMenuList().Count);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input!");
                }
            
            }
            

        }

        

    }
}
