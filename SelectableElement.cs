using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{
    public class SelectableElement
    {
        private bool takesText;
        int xLocation;
        int yLocation;

        public string displayedText;

        public SelectableElement(bool takesText, string text, int x, int y)
        {
            this.takesText = takesText;
            displayedText = text;
            xLocation = x;
            yLocation = y;
            
        }
    }
}
