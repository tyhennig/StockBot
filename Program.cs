using System;


public class Stock
{
    private string ticker;
    private string name;
    private decimal latestPrice;
    private decimal dailyHigh;
    private decimal dailyLow;

    Stock(string ticker, decimal latestPrice)
    {
        this.ticker = ticker;
        this.latestPrice = latestPrice;
    }

    private void updatePrice()
    {

    }


}

public class User
{
    private string username;
    private string password;

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
