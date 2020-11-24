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
        private string username;
        private string password;
        private Dictionary<string, Portfolio> portfolios;//DONE//I'm thinking about having a portfolio class instead, that way users can have more than one portfolio
        private decimal buyingPower; //perhaps this should be global (static)

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
            portfolios = new Dictionary<string, Portfolio>();
            id += numInstantiated;
        }

        public string getUsername()
        {
            return username;
        }

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
        public void subBuyingPower(decimal amountRemoved)
        {
            decimal difference = buyingPower - amountRemoved;
            if (amountRemoved < 0)
            {
                Console.WriteLine("Enter a non-negative number");
            }
            else if((difference < 0))
            {
                Console.WriteLine("Amount removed exceeds buying power by $" + difference);
            }
            else
            {
                buyingPower -= amountRemoved;
            }
            
        }

        private bool portfolioExists(string displayName)
        {
            if (portfolios.ContainsKey(displayName))
            {
                return true;
            }
            return false;
        }

        public void createPortfolio(string displayName)
        {
            if (!portfolioExists(displayName))
            {
                portfolios.Add(displayName, new Portfolio(displayName));
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
