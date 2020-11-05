using System;
using System.Collections.Generic;


/*TODO:
 * 
 * Mishra's Wants
 *  Find best stocks to buy
 *  Sorting by stocks that have decremented the most
 *  Basically what we were going to do anyways
 * 
 */




public static class API //just a temp class to test functionality
{
    public static bool isTicker(string ticker)
    {
        if (ticker == "abc")
            return true;
        else
            return false;
    }
}

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
        } else
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

public class Portfolio
{
    private string displayName;
    private string id;
    private string owner;
    private List<Stock> contents;

    public Portfolio(string owner)
    {
        this.owner = owner;
        contents = new List<Stock>();
    }
}

public class User 
{
    private string username;
    private string password;
    //I'm thinking about having a portfolio class instead, that way users can have more than one portfolio
    private List<Stock> portfolio;

    public User(string username, string password)
    {
        this.username = username;
        this.password = password;
        portfolio = new List<Stock>();  //initialize the portfolio in memory once a user is created

    }

    public void addStock(Stock stock)
    {
        portfolio.Add(stock);
    }

    public void removeStock(Stock stock)
    {
        portfolio.Remove(stock);
    }

    public void displayPortfolio()
    {
        foreach (Stock stock in portfolio) //iterates list, writes stock ToString() to console
        {
            Console.WriteLine(stock);
        }
    }

}

public class TradingBot
{

}

class Program
{
    static void Main(string[] args)
    {
        Stock stock1 = new Stock("abc");
        User user1 = new User("james", "password");
        user1.addStock(stock1);
        user1.displayPortfolio();
        Console.ReadLine();
    }
}
