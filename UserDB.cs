using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{
    //May have to store all data in here. Perhaps only have one user to make things simple. May have to be static
    public static class UserDB
    {
        //public static Dictionary<int, User> userDB = new Dictionary<int, User>(); //web-scrape code
        public static Dictionary<string, User> userDB = new Dictionary<string, User>();

        public static bool addUser(string username, string password, string bday)
        {
            if (userDB.ContainsKey(username))
            {
                Console.WriteLine("Username Taken!");
                return false;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(username)) // Checks if the inputted Username is blank or purely spaces
                {
                    Display.error("Enter Valid Username");
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(password)) // Checks if the inputted Password is blank or purely spaces
                {
                    Display.error("Enter Valid Password");
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(bday)) // Checks if the inputted Birthday is blank or purely spaces
                {
                    Display.error("Enter Valid Birthday");
                    return false;
                }
                else
                {
                    User createdUser = new User(username, password, bday);
                    //userDB.Add(username, createdUser);
                    return true;
                }
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

        public static string forgotPassword(string username, string bday)
        {
            User value;
            if(userDB.TryGetValue(username, out value))
            {
                if (value.getBday().Equals(bday))
                    return value.getPassword();
            } 
            return null;
                
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
