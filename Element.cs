using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{
    public abstract class Element
    {
        public int xLocation;
        public int yLocation;
        public string displayedText;


        public void setDisplayedText(string text)
        {
            displayedText = text;
        }

        public string getDisplayedText()
        {
            return displayedText;
        }
        public void setX(int x)
        {
            xLocation = x;
        }
        public void setY(int y)
        {
            yLocation = y;
        }
    }
}
