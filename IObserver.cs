using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{
    public interface IObserver
    {
        void Update(dynamic stocks);
    }
}
