﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{
    class UserDB
    {
        private Dictionary<string, string> userDB;

        public UserDB()
        {

        }

        private void addUser(string username, string password)
        {
            if (userDB.ContainsKey(username))
                Console.WriteLine("Username taken.");
            else
            {
                userDB.Add(username, password);
                Console.WriteLine("User created.");
            }
        }

        //might be unecessary
        private void removeUser(string username)
        {
            if (userDB.ContainsKey(username))
            {
                userDB.Remove(username);
                Console.WriteLine("User " + username + " removed.");
            } 
            else
            {
                Console.WriteLine("Username " + username + " does not exist.");
            }
            
        }

        private void signIn(string username, string password)
        {
            //if (userDB.ContainsKey(username))
                //if (userDB.AsParallel[username] == password)
        }
    }
}