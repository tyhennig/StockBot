using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{

    public static class API //just a temp class to test functionality
    {
        public static bool isTicker(string ticker)
        {
            if (!String.IsNullOrEmpty(ticker))
                return true;
            else
                return false;
        }
    }
}
