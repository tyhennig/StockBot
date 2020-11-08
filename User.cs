using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{

    public class User
    {
        private string username;
        private string password;
        private Dictionary<string, Portfolio> portfolios;
        //DONE//I'm thinking about having a portfolio class instead, that way users can have more than one portfolio

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
            portfolios = new Dictionary<string, Portfolio>();
        }

        public string getUsername()
        {
            return username;
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
