using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace StockBot
{
    public class SelectableElement : Element
    {
        public bool TakesText
        {
            get;
        }
        private string value = "";
        public bool IsMenu
        {
            get; set;
        }

        Action a;

        public SelectableElement(bool takesText, string text, int x, int y)
        {
            this.TakesText = takesText;
            this.IsMenu = false;
            displayedText = text;
            xLocation = x;
            yLocation = y;
            
            
        }

        public SelectableElement(bool takesText, string text, int x, int y, Action a)
        {
            this.TakesText = takesText;
            this.IsMenu = false;
            displayedText = text;
            xLocation = x;
            yLocation = y;

            this.a = a;

        }

       

        public string getValue()
        {
            return value;
        }

        public void clearValue()
        {
            value = "";
        }

        public void addToValue(char added)
        {
            if(value.Length <= 12)
                value = value + added;
        }

        public void delFromValue()
        {
            if(value.Length > 0)
                value = value.Remove(value.Length - 1);
        }
        
        public void runMethod()
        {
            a();
        }
    }
}
