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

                Console.Clear();
                Console.CursorVisible = false;
                if (!currentMenu.getHasContent())
                {
                    currentMenu.displayChildren();
                    Console.MoveBufferArea(0, selection, 20, 1, 1, selection);
                    Console.SetCursorPosition(0, selection);
                    Console.Write(">");
                    ConsoleKeyInfo key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (selection > 0)
                                selection--;
                            break;
                        case ConsoleKey.DownArrow:
                            if (selection < currentMenu.getChildMenuList().Count)
                                selection++;
                            break;
                        case ConsoleKey.Enter:
                            currentMenu = currentMenu.getChildMenuList()[selection];
                            break;
                        case ConsoleKey.Escape:
                            if (currentMenu == mainMenu)
                                return;
                            else
                                currentMenu = currentMenu.getParentMenu();
                            break;
                    }
                }
                else
                {
                    currentMenu.getContent().getSelectableElements()[selection].setDisplayedText(">" + currentMenu.getContent().getSelectableElements()[selection].getDisplayedText());

                    /*
                     * WE STOPPED HERE TODO:
                     * FIX THE SELECTED ELEMENT COUNTER
                     * 
                     */

                    currentMenu.getContent().display();
                    currentMenu.getContent().getSelectableElements()[selection].getDisplayedText();
                    ConsoleKeyInfo key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (selection > 0)
                                selection--;
                            break;
                        case ConsoleKey.DownArrow:
                            if (selection < currentMenu.getContent().getSelectableElements().Count())
                                selection++;
                            break;
                        case ConsoleKey.Enter:
                            currentMenu = currentMenu.getChildMenuList()[selection];
                            break;
                        case ConsoleKey.Escape:
                            if (currentMenu == mainMenu)
                                return;
                            else
                                currentMenu = currentMenu.getParentMenu();
                            break;
                    }

                }
                

            }
            

        }

        

    }
}
