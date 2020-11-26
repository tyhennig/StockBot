﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{
    public class Portfolio
    {
        //we might need an id for each portfolio. Index may be handy for when you navigate
        private string displayName;
        //private string owner;
        public List<Stock> contents;
        private TradingBot bot; //Each portfolio might have its own bot

        public Portfolio(string displayName)
        {
            //this.owner = owner;
            this.displayName = displayName;
            
            contents = new List<Stock>();
        }

        public string getDisplayName()
        {
            return displayName;
        }

        public void addStock(Stock stock)
        {
            contents.Add(stock);
        }

        public void removeStock(Stock stock)
        {
            contents.Remove(stock);
        }

        public void displayPortfolio()
        {
            foreach (Stock stock in contents) //iterates list, writes stock ToString() to console
            {
                Console.WriteLine(stock);
            }
        }
    }
}
