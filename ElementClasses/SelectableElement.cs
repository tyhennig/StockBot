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
        private bool takesText;
        private string value;

        public SelectableElement(bool takesText, string text, int x, int y)
        {
            this.takesText = takesText;
            displayedText = text;
            xLocation = x;
            yLocation = y;
        }

        public SelectableElement(bool takesText, string text)
        {
            this.takesText = takesText;
            displayedText = text;
        }

        public void addToValue(string added)
        {
            value = value + added;
        }

        public void delFromValue()
        {
            value = value.Remove(value.Length - 1);
        }
        
    }
}
