using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StockBot
{
    public class MenuContent
    {
        private string content;
        private Menu owner;
        public MenuContent(Menu owner, string title)
        {
            this.owner = owner;
            content = title;
        }


        public void display()
        {
            Console.WriteLine(content);
        }
    }
}
