using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography; 



namespace StockBot
{


    


    class Program
    {

        static void createMenu(Menu mainMenu)
        {
            
            Menu login = mainMenu.createChildMenu("Log In");
            Menu createAccount = mainMenu.createChildMenu("Create Account");
            Menu options = mainMenu.createChildMenu("Options");

            

            Menu video = options.createChildMenu("Resolution");
            Menu sound = options.createChildMenu("Sound");
            Menu credits = options.createChildMenu("Credits");

            Menu forgotPass = login.createChildMenu("Forgot Password");
            Menu check = login.createChildMenu("Check something");

            LogIn loginPage = new LogIn("Log In Page", login);
        }

        



        static void Main(string[] args)
        {
            Menu mainMenu = new Menu("main");//The "root" of the menu tree
            createMenu(mainMenu);
            Display.run(mainMenu);

        }
    }

}