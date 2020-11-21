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
        public LogIn(string title) : base(title)
        {
            usernameInput = new SelectableElement(true, "Username: ", 10, 2);
            passwordInput = new SelectableElement(true, "Password: ", 10, 4);
            elements.Add(usernameInput);
            elements.Add(passwordInput);

        }

        public override void display()
        {
            throw new NotImplementedException();
        }

        public override void run()
        {
            throw new NotImplementedException();
        }
    }
}
