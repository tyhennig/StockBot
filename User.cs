using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{

    public class User
    {
        static int numInstantiated = 0;
        int id; //numInstantiated increments every time a new user is created. Look at constructor
        private string username { set; get; }
        private string password { set; get; }
        //Maybe a list is better? What happens when you delete a user, creating holes
        //public Dictionary<string, Portfolio> portfolios;//DONE//I'm thinking about having a portfolio class instead, that way users can have more than one portfolio
        public List<Portfolio> portfolios;
        private decimal buyingPower; //perhaps this should be global (static)

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
            //portfolios = new Dictionary<string, Portfolio>();
            portfolios = new List<Portfolio>();
            createPortfolio("Botfolio");
            id = numInstantiated;
            numInstantiated++;
            UserDB.userDB.Add(id, this);
        }

        //public string getUsername()
        //{
        //    return username;
        //}



        public decimal getBuyingPower()
        {
            return buyingPower;
        }

        public void addBuyingPower(decimal amountAdded)
        {
            if(amountAdded > 0)
            {
                buyingPower += amountAdded;
            }
            else
            {
                Console.WriteLine("Enter a valid amount...");
            }            
        }

        //may need some editing. May need a loop or might need to change
        //return something. Use in buyStock class. Think about it. DRY
        public bool subBuyingPower(decimal amountRemoved)
        {
            decimal difference = buyingPower - amountRemoved;
            if (amountRemoved < 0)
            {
                Console.WriteLine("Enter a non-negative number");
                return false;
            }
            else if((difference < 0))
            {
                Console.WriteLine("Amount removed exceeds buying power by $" + difference);
                return false;
            }
            else
            {
                this.buyingPower -= amountRemoved;
                return true;
            }
            
        }

        //Navigate through movers
        //Select portfolio
        //Create stock object
        //Check if symbol exists in portfolio
            //If it does, add to list
            //If not, create new key with new list, add to list
            //
        public void buyStock(Portfolio folio, dynamic stock, int quantity)
        {
            Stock bStock = new Stock(stock, quantity);
            decimal price = folio.updateStockPricesAsync(bStock);
            bStock.updatePrice(price);
            if (subBuyingPower(price * quantity))
            {
                if (folio.contents.ContainsKey(bStock.symbol))
                {
                    folio.contents[bStock.symbol].Add(bStock);
                }
                else
                {
                    List<Stock> stockPool = new List<Stock>();
                    
                    stockPool.Add(bStock);
                    
                    folio.contents.Add(bStock.symbol, stockPool);
                    //might not be needed?
                    //folio.currentStockPrices.Add(bStock.symbol, bStock.regularMarketPrice);
                }
            }
        }



        //The stock must exist in portfolio
        //The quantity anttempted to sell must not exceed the quantity owned
        //The most current price must be used
        //Stocks must be removed from portfolio 
        //Earnings/losings must be added to buyingPower
        public void sellStock(Portfolio folio, Stock stock, int quantity)
        {
            string symbol = stock.symbol;
            if (folio.contents.ContainsKey(symbol))
            {
                int qtyOwned = 0; 
                foreach(Stock stk in folio.contents[symbol])
                {
                    qtyOwned += stk.quantity;
                }
                if(qtyOwned >= quantity)
                {
                    //decimal price = await TradingBot.updateStockPricesAsync();
                    decimal price = folio.updateStockPricesAsync(stock);
                    //not that easy buck-o
                    decimal total = folio.removeStock(symbol, price, quantity);



                    addBuyingPower(total);
                    Console.WriteLine("SOLD!");
                }
                else
                {
                    Console.WriteLine("Quantity attempting to sell exceeds the owned quantity");
                }
                
            }
            else
            {
                Console.WriteLine("Stock does not exist in p");
            }
        }

        //bot will buy the first 5 top movers
        //if any of the 5 is replaced on top gainers,
        //bot sells the replaced stock
        //bot buys new stock
        //Note: bot will buy in percentages of buyingPower
        //50% of buying power will be used by the bot
        //10% per stock
        //Stock quantity must be integer
        public void botbuy()
        {
            decimal singlestockbudget = (buyingPower * 0.5m) * 0.20m;
            for (int i = 0; i < 5; i++)
            {
                Stock stock = new Stock(TradingBot.movers[i]);
                int quantity = (int)(singlestockbudget / stock.regularMarketPrice);
                if (quantity > 0)
                {
                    buyStock(portfolios[0], stock, quantity);
                }
            }


            //foreach (dynamic stock in folio.contents)
            //{

            //    string symbol = stock.symbol;
            //    for (int i = 0; i < 5; i++)
            //    {
            //        if (tradingbot.movers[i].symbol.equals(symbol))
            //        {
            //            console.writeline("match");
            //        }
            //    }

            //}
            //for (int i = 0; i < 5; i++)
            //{
            //    buystock(folio, tradingbot.movers[i], 2);
            //}

        }

        public void updateStock()
        {

        }


        //might have to change. Search if key exists inside portfolio
        private bool portfolioExists(string folio)
        {
            foreach (Portfolio x in portfolios)
            {
                if (folio.Equals(x.getDisplayName()))
                {
                    return true;
                }
            }
            
            return false;
        }

        //or print each key? Idk which is better
        public void listPortfolios()
        {
            foreach (Portfolio portfolio in portfolios)
            {
                Console.WriteLine(portfolio.getDisplayName());
            }
        }

        public void createPortfolio(string folio)
        {
            if (!portfolioExists(folio))
            {
                portfolios.Add(new Portfolio(folio));
            }
            else
            {
                //It would be cool to have like a "screen" class that controls the display of things
                //Here we would call a display an error that the portfolio already exists
                //For now we will just write to console
                Console.WriteLine("Hey Bub! You already have a portfolio named this!");
            }
        }
    }
}
