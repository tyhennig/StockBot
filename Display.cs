using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{

    public class Display
    {
        Menu currentMenu;
        bool running = true;

        public Display(Menu mainMenu)
        {  
            currentMenu = mainMenu;
        }

        public void run()
        {
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
