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

            //Menu mainMenu = new Menu("main", false);//The "root" of the menu tree
            //createMenu(mainMenu);
            //Display.run(mainMenu);
            UserDB db = new UserDB();
            //db.addUser("Elite561", "Batman98");
            //Console.WriteLine(db.userDB["Elite561"]);
            //db.signInAttempt("Elite561", "Batman98");

            var url = "https://finance.yahoo.com/gainers";
            User paul = new User("A", "A");
            paul.createPortfolio("chungus");
            TradingBot bot = new TradingBot();
            Portfolio currentDisplay = new Portfolio("default");
            //Portfolio port2 = new Portfolio(bot);
            while(true)
            {
                Thread.Sleep(1000);
                Console.Clear();
                bot.FetchMovers();
                currentDisplay.Display();
            }
            
            //bot.scrapeHTML(url);
            Console.ReadLine();
        }
    }

}