using System;
using System.Collections.Generic;
using System.Security.Cryptography;


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

public static class Display
{

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
    //private string owner;
    private List<Stock> contents;

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
        } else
        {
            //It would be cool to have like a "screen" class that controls the display of things
            //Here we would call a display an error that the portfolio already exists
            //For now we will just write to console
            Console.WriteLine("Hey Bub! You already have a portfolio named this!");
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
        Stock stock1, stock2, stock3;
        stock1 = new Stock("abc");
        stock2 = new Stock("amd");
        stock3 = new Stock("noob");

        User user1 = new User("james", "password");
        user1.createPortfolio("main");

        
       
    }
}
