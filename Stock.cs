using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{

    public class Stock
    {
        private string ticker;
        private string name;
        private decimal latestPrice;
        private decimal dailyHigh; //or some other value we want to keep track of
        private decimal dailyLow;

        public Stock(string ticker)
        {
            if (API.isTicker(ticker)) //uses some API or something to check if it is a valid ticker
            {
                this.ticker = ticker;
                updatePrice();
                updateHigh();
                updateLow();
                getName();
            }
            else
            {
                throw new ArgumentException("You entered an invalid Ticker");
            }
        }
        public override string ToString()
        {
            return ticker;
        }

        public void updatePrice()
        {
            //interface with API or webpage to get the latest quote
            //latestPrice = API.getPrice(ticker);
        }

        public void updateHigh()
        {

        }

        public void updateLow()
        {

        }

        public void getName()
        {

        }
    }


}
