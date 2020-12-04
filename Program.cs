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


            //MenuTree StockOptions = root.createChildMenu("Stock Options");
            MenuTree portfolios = root.createChildMenu("Portfolios");
            MenuTree login = root.createChildMenu("Log In");
            MenuTree settings = root.createChildMenu("Settings");
            MenuTree movers = root.createChildMenu("Movers");

            //MenuTree botSets = settings.createChildMenu("Stock Bot Settings");
            MenuTree video = settings.createChildMenu("Video");
            MenuTree sound = settings.createChildMenu("Sound");
            MenuTree credits = settings.createChildMenu("Credits");

            MenuTree forgotPass = login.createChildMenu("Forgot Password");
            MenuTree createAccount = login.createChildMenu("Create Account");
            //MenuTree logOut = login.createChildMenu("Log Out");


            

            MenuTree createPort = portfolios.createChildMenu("Create Portfolio");
            MenuTree deletePort = portfolios.createChildMenu("Delete Portfolio");
            

            LogIn loginPage = new LogIn("Log In Page", login);
            MainMenu mainMenu = new MainMenu("Main Menu Page", root);
            Movers moversPage = new Movers("Movers Page", movers);
            Settings settingPage = new Settings("Settings Page", settings);
            PortfolioContent portfolioPage = new PortfolioContent("Portfolios Page", portfolios);
            Credits creditPage = new Credits("Credits Page", credits);
            Sound soundPage = new Sound("Sound Page", sound);
            Video videoPage = new Video("Video Page", video);
            CreateAccount createAccountPage = new CreateAccount("Create Account Page", createAccount);
            CreatePortfolio createPortfolioPage = new CreatePortfolio("Create Portfolio Page", createPort);
            DeletePortfolioPage deletePortfolioPage = new DeletePortfolioPage("Delete Portfolio Page", deletePort);
            ForgotPassword forgotPasswordPage = new ForgotPassword("Forgot Password Page", forgotPass);

            return root;
        }

        


        



        static void Main(string[] args)
        {

            var stockBot = new Thread(() =>
            {
                while (true)
                {
                    TradingBot.FetchMovers();
                    Thread.Sleep(5000);
                }

            });


            stockBot.Start();

            UserDB.addUser("tyler", "pass", "02/26/1999");
            //UserDB.addUser("james", "pass", "999");

            Display.currentUser = UserDB.userDB["tyler"];
            Display.currentUser.addBuyingPower(10000);

            UserDB.userDB["tyler"].createPortfolio("First Portfolio");
            UserDB.userDB["tyler"].createPortfolio("Second Portfolio");
            UserDB.userDB["tyler"].createPortfolio("Third Portfolio");






            Console.SetWindowSize(160, 40);
            //The "root" of the menu tree
            MenuTree root = createMenuTree();
            Display.run(root);
            
        }
    }

}