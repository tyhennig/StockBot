using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{
    class Sound : MenuContent
    {
        SelectableElement soonS;
        public Sound(string title, MenuTree owner) : base(title, owner)
        {
            soonS = new SelectableElement(false, "Sound Settings Coming Soon!", 10, 2);

            elements.Insert(0, soonS);
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
