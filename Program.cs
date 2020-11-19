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
            Menu login = mainMenu.createChildMenu("Log In", true);
            Menu createAccount = mainMenu.createChildMenu("Create Account", true);
            Menu options = mainMenu.createChildMenu("Options", false);

            Menu video = options.createChildMenu("Resolution", true);
            Menu sound = options.createChildMenu("Sound", true);
            Menu credits = options.createChildMenu("Credits", true);

            Menu forgotPass = login.createChildMenu("Forgot Password", true);
            Menu check = login.createChildMenu("Check something", true);
        }

        


        



        static void Main(string[] args)
        {
            //Menu mainMenu = new Menu("main", false);//The "root" of the menu tree
            //createMenu(mainMenu);
            //Display.run(mainMenu);
            UserDB db = new UserDB();
            db.addUser("Elite561", "Batman98");
            Console.WriteLine(db.userDB["Elite561"]);
            db.signInAttempt("Elite561", "Batman98");

            var url = "https://finance.yahoo.com/gainers";
            TradingBot bot = new TradingBot();
            bot.scrapeHTML(url);
            Console.ReadLine();
        }
    }

}