using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{
    class LogIn : MenuContent
    {
        SelectableElement usernameInput;
        SelectableElement passwordInput;
        public LogIn(string title, Menu owner) : base(title, owner)
        {
            usernameInput = new SelectableElement(true, "Username: ", 10, 2);
            passwordInput = new SelectableElement(true, "Password: ", 10, 4);
            elements.Add(usernameInput);
            elements.Add(passwordInput);
            loadElements();

        }

        public override void display()
        {
            foreach(SelectableElement thing in elements)
            {
                Console.SetCursorPosition(thing.xLocation, thing.yLocation);
                Console.Write(thing.displayedText);
            }
        }

        public override void run()
        {
            throw new NotImplementedException();
        }
    }
}
