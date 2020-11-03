using System;
using System.Collections.Generic;

public class Stock
{
    private string ticker;
    private string name;
    private decimal latestPrice;
    private decimal dailyHigh;
    private decimal dailyLow;

    Stock(string ticker)
    {
        this.ticker = ticker;
        updatePrice();
        updateHigh();
        updateLow();
        getName();
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

public class User
{
    private string username;
    private string password;
    private List<Stock> portfolio;

    User(string username, string password)
    {
        this.username = username;
        this.password = password;
        portfolio = new List<Stock>();  //initialize the portfolio in memory once a user is created

    }


}

public class TradingBot
{

}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
    }
}
