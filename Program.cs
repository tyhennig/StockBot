using System;
using System.Collections.Generic;


/*TODO:
 * 
 * 11/5/2020
 * Figure out how the portfolio class and user class will work
 * Creating a portfolio through users? or creating protfolio from a user?
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
    private string owner;
    private List<Stock> contents;

    public Portfolio(string owner, string displayName)
    {
        this.owner = owner;
        this.displayName = displayName;
        contents = new List<Stock>();
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

public class User 
{
    private string username;
    private string password;
    private List<Portfolio> portfolios;
    //I'm thinking about having a portfolio class instead, that way users can have more than one portfolio

    public User(string username, string password)
    {
        this.username = username;
        this.password = password;
    }

    public string getUsername()
    {
        return username;
    }

    public Portfolio createPortfolio(string displayName)
    {
        return new Portfolio(username, displayName);
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
        user1.createPortfolio("first");

        Console.ReadLine();
    }
}
