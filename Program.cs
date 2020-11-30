using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Threading;



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
            MenuTree movers = root.createChildMenu("Movers");

            MenuTree video = options.createChildMenu("Resolution");
            MenuTree sound = options.createChildMenu("Sound");
            MenuTree credits = options.createChildMenu("Credits");

            MenuTree forgotPass = login.createChildMenu("Forgot Password");
            MenuTree createAccount = login.createChildMenu("Create Account");

            //MenuTree test = login.createChildMenu("testing");

            LogIn loginPage = new LogIn("Log In Page", login);
            MainMenu mainMenu = new MainMenu("Main Menu Page", root);
            Movers moversPage = new Movers("Movers Page", movers);

            return root;
        }

        


        



        static void Main(string[] args)
        {
            Console.SetWindowSize(160, 40);
            //The "root" of the menu tree
            MenuTree root = createMenuTree();
            Display.run(root);

            UserDB db = new UserDB();
            


            var url = "https://finance.yahoo.com/gainers";
            User paul = new User("A", "A");
            paul.createPortfolio("chungus");
            TradingBot bot = new TradingBot();
            Portfolio currentDisplay = new Portfolio("default");

            
        }
    }

}