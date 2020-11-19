using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{
    //May have to store all data in here. Perhaps only have one user to make things simple
    public class UserDB
    {
        public Dictionary<string, string> userDB = new Dictionary<string, string>();

        public UserDB()
        {

        }

        public void addUser(string username, string password)
        {
            if (userDB.ContainsKey(username))
            {
                Console.WriteLine("Username taken.");
            }
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
            } else{
                Console.WriteLine("Username " + username + " does not exist.");
            }
            
        }

        public void signInAttempt(string username, string password)
        {
            bool success = false;
            if (userDB.ContainsKey(username))
                //This loop is infinite if the username is correct but the password is wrong
                while(!success)
                    if (userDB[username] == password)
                    {
                        success = true;
                        Console.WriteLine("Access Granted");
                    } else{
                        Console.WriteLine("Try again");
                    }
            else{
                Console.WriteLine("User does not exist");
            }
        }
    }
}
