using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography; 



namespace StockBot
{

    class Program
    { 
        
        static MenuTree createMenuTree()
        {
            MenuTree root = new MenuTree("Main Menu");

            MenuTree portfolio = root.createChildMenu("Portfolio");
            MenuTree login = root.createChildMenu("Log In");
            MenuTree options = root.createChildMenu("Options");

            MenuTree video = options.createChildMenu("Resolution");
            MenuTree sound = options.createChildMenu("Sound");
            MenuTree credits = options.createChildMenu("Credits");

            MenuTree forgotPass = login.createChildMenu("Forgot Password");
            MenuTree createAccount = login.createChildMenu("Create Account");

            LogIn loginPage = new LogIn("Log In Page", login);
            MainMenu mainMenu = new MainMenu("Main Menu Page", root);

            return root;
        }

        



        static void Main(string[] args)
        {
            //The "root" of the menu tree
            MenuTree root = createMenuTree();
            Display.run(root);

        }
    }

}