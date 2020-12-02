using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{
    //convert stock object in constructor

    //We might not need this class. The objects extracted from the json file are already functional




    //Structure of one mover
    //{ 
    //"symbol":"DADA",
    //"shortName":"Dada Nexus Limited",
    //"longName":"Dada Nexus Limited",
    //"quoteType":"EQUITY",
    //"currency":"USD",
    //"regularMarketPrice":{
    //                "raw":43.81,
    //                "fmt":"43.81"
    //},
    //"regularMarketChange":{
    //                "raw":10.23,
    //                "fmt":"10.23"
    //},
    //"regularMarketChangePercent":{
    //                "raw":30.46456,
    //                "fmt":"30.46%"
    //},
    //"regularMarketVolume":{
    //                "raw":3931400,
    //                "fmt":"3.931M",
    //                "longFmt":"3,931,400"
    //},
    //"averageDailyVolume3Month":{
    //                "raw":1275627,
    //                "fmt":"1.276M",
    //                "longFmt":"1,275,627"
    //},
    //"marketCap":{
    //                "raw":9840033792,
    //                "fmt":"9.84B",
    //                "longFmt":"9,840,033,792"
    //},
    //"fiftyTwoWeekLow":{
    //                "raw":14.6,
    //                "fmt":"14.60"
    //},
    //"fiftyTwoWeekHigh":{
    //                "raw":44.9,
    //                "fmt":"44.90"
    //},
    //"regularMarketOpen":{
    //                "raw":34.5,
    //                "fmt":"34.50"
    //},
    //"priceHint":2
    //}

    public class Stock
    {
        private string ticker;
        private string name;
        private decimal latestPrice;
        private decimal dailyHigh; //or some other value we want to keep track of
        private decimal dailyLow;

        private string symbol;
        private string shortName;
        private decimal regularMarketPrice;
        private decimal regularMarketChange;
        private decimal regularMarketChangePercent;
        private decimal regularMarketVolume;
        private decimal averageDailyVolume3Month;
        private decimal marketCap;
        private decimal fiftyTwoWeekLow;
        private decimal fiftyTwoWeekHigh;
        private decimal regularMarketOpen;


        public Stock(string s, string sn, decimal p, decimal c, decimal cp, decimal v, decimal adv, decimal mc, decimal ftwl, decimal ftwh, decimal mo)
        {
            this.symbol = s;
            this.shortName = sn;
            this.regularMarketPrice = p;
            this.regularMarketChange = c;
            this.regularMarketChangePercent = cp;
            this.regularMarketVolume = v;
            this.averageDailyVolume3Month = adv;
            this.marketCap = mc;
            this.fiftyTwoWeekLow = ftwl;
            this.fiftyTwoWeekHigh = ftwh;
            this.regularMarketOpen = mo;
    }

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
