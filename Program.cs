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

            MenuTree portfolios = root.createChildMenu("Portfolios");
            MenuTree login = root.createChildMenu("Log In");
            MenuTree settings = root.createChildMenu("Settings");
            MenuTree movers = root.createChildMenu("Movers");

            MenuTree video = settings.createChildMenu("Video");
            MenuTree sound = settings.createChildMenu("Sound");
            MenuTree credits = settings.createChildMenu("Credits");

            MenuTree forgotPass = login.createChildMenu("Forgot Password");
            MenuTree createAccount = login.createChildMenu("Create Account");


            //MenuTree test = login.createChildMenu("testing");

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
            DeletePortfolio deletePortfolioPage = new DeletePortfolio("Delete Portfolio Page", deletePort);

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