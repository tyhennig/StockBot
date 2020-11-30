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

        public void buyStock(Portfolio folio, dynamic stock, int quantity)
        {
            float p = stock.regularMarketPrice.raw;
            decimal price = Convert.ToDecimal(p);
            if(subBuyingPower(price * quantity))
            {
                for (int i = 0; i < quantity; i++)
                {
                    folio.contents.Add(stock);
                }
            }       
        }

        public void sellStock(Portfolio folio, dynamic stock, int quantity)
        {
            float p = stock.regularMarketPrice.raw;
            decimal price = Convert.ToDecimal(p);

            if (subBuyingPower(price * quantity))
            {
                for (int i = 0; i < quantity; i++)
                {
                    folio.contents.Add(stock);
                }
            }
        }

        public void botBuy(Portfolio folio)
        {
            foreach(dynamic stock in folio.contents)
            {
                string symbol = stock.symbol;
                for(int i = 0; i < 5; i++)
                {
                    if (TradingBot.movers[i].symbol.Equals(symbol))
                    {
                        Console.WriteLine("Match");
                    }
                }
                
            }
            //for (int i = 0; i < 5; i++)
            //{
            //    buyStock(folio, TradingBot.movers[i], 2);
            //}

        }

        public void updateStock()
        {

        }

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
