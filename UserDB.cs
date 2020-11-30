using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{
    //May have to store all data in here. Perhaps only have one user to make things simple. May have to be static
    public static class UserDB
    {
        public static Dictionary<string, User> userDB = new Dictionary<string, User>();

        public static bool addUser(string username, string password)
        {
            if (userDB.ContainsKey(username))
            {
                return false;
            }
            else
            {
                User createdUser = new User(username, password);
                userDB.Add(username, createdUser);
                return true;
            }
        }

        //might be unecessary
        private static void removeUser(string username)
        {
            //if (userDB.ContainsKey(username))
            //{
            //    userDB.Remove(username);
            //    Console.WriteLine("User " + username + " removed.");
            //} else{
            //    Console.WriteLine("Username " + username + " does not exist.");
            //}
            
        }

        public static int attemptLogin(string username, string password)
        {
            //bool success = false;
            User value;
            if (userDB.TryGetValue(username, out value))
            {
                if (value.getPassword().Equals(password))
                {
                    Display.currentUser = value;
                    return 0;
                }
                else return 1;
            }
            else return 2;
                //This loop is infinite if the username is correct but the password is wrong
                
            
        }
    }
}
