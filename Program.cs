using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Threading;



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
            //db.addUser("Elite561", "Batman98");
            //Console.WriteLine(db.userDB["Elite561"]);
            //db.signInAttempt("Elite561", "Batman98");
            TradingBot bot = new TradingBot();
            bot.FetchMovers();
            User paul = new User("Elite561", "ABC");
            paul.createPortfolio("default");
            paul.createPortfolio("default2");
            paul.addBuyingPower(1000);
            paul.listPortfolios();
            paul.buyStock(paul.portfolios[0], TradingBot.movers[4], 10);
            paul.buyStock(paul.portfolios[0], TradingBot.movers[2], 5);
            //paul.botBuy(paul.portfolios[0]);
            //paul.buyStock(portfolioName, selectedstock);
            paul.portfolios[0].displayPorfolioContent();
            paul.portfolios[0].updateStocksAsync();
            Console.WriteLine(paul.getBuyingPower());

            
            //Portfolio currentDisplay = new Portfolio("default");
            //Portfolio port2 = new Portfolio(bot);
            //while(true)
            {
                //Thread.Sleep(1000);
                //Console.Clear();
                //bot.FetchMovers();
                //bot.Display();
            }
            
            //bot.scrapeHTML(url);
            Console.ReadLine();
        }
    }

}