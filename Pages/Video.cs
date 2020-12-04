using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{
    class Video : MenuContent
    {
        SelectableElement soonV;
        public Video(string title, MenuTree owner) : base(title, owner)
        {
            soonV = new SelectableElement(false, "Video Settings Coming Soon!", 10, 2);

            elements.Insert(0, soonV);
        }

        public override void run()
        {
            display();
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    Display.setCurrentMenu(owner.getParentMenu());
                    break;
            }
        }

    }
}
