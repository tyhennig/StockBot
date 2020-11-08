using System;
using System.Collections.Generic;
using System.Security.Cryptography; 



namespace StockBot
{


    /*TODO:
     * 
     * 11/5/2020
     * Figure out how the portfolio class and user class will work
     * Creating a portfolio through users? or creating protfolio from a user?
     * 
     */


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

}