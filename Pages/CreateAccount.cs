using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{
    class CreateAccount : MenuContent
    {
        SelectableElement usernameInput;
        SelectableElement passwordInput;
        SelectableElement birthdayInput;
        SelectableElement create;
        public CreateAccount(string title, MenuTree owner) : base(title, owner)
        {
            Action del = new Action(submitCredentials1);

            usernameInput = new SelectableElement(true, "Username: ", 10, 2);
            passwordInput = new SelectableElement(true, "Password: ", 10, 4);
            birthdayInput = new SelectableElement(true, "Birthday: ", 10, 6);
            //create = new SelectableElement(false, "Create", 10, 8);
            create = new SelectableElement(false, "Create", 10, 8, del);

            elements.Insert(0, usernameInput);
            elements.Insert(1, passwordInput);
            elements.Insert(2, birthdayInput);
            elements.Insert(3, create);

            selectedElement = elements[0];
        }

        public void submitCredentials1()
        {
            string username = usernameInput.getValue();
            string pass = passwordInput.getValue();
            string bday = birthdayInput.getValue();

            if (UserDB.addUser(username, pass, bday))
            {
                Console.WriteLine("Successfully Created Account!");
            }
            else Console.WriteLine("Username Taken!");
            Console.ReadKey();

        }

        public override void display()
        {
            foreach (Element element in elements)
            {
                if (element == selectedElement)
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(element.xLocation, element.yLocation);
                Console.Write(element.displayedText);
                Console.ForegroundColor = ConsoleColor.White;
                if (((SelectableElement)element).TakesText)
                    Console.Write(((SelectableElement)element).getValue());
            }
        }

        public override void run()
        {
            display();
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (elements.IndexOf(selectedElement) == 0)
                        selectedElement = elements[elements.Count - 1];
                    else
                        selectedElement = elements[elements.IndexOf(selectedElement) - 1];
                    break;

                case ConsoleKey.DownArrow:
                    if (elements.IndexOf(selectedElement) == elements.Count - 1)
                        selectedElement = elements[0];
                    else
                        selectedElement = elements[elements.IndexOf(selectedElement) + 1];
                    break;

                case ConsoleKey.Enter:
                    if (selectedElement.IsMenu)
                    {
                        Display.setCurrentMenu(owner.getChildMenuList().Where(menu => menu.getTitle().Equals(selectedElement.displayedText)).ToList()[0]);
                    }
                    else
                    {
                        selectedElement.runMethod();
                    }
                    break;

                case ConsoleKey.Escape:
                    Display.setCurrentMenu(owner.getParentMenu());
                    break;

                case ConsoleKey.Backspace:
                    if (selectedElement.TakesText)
                        (selectedElement).delFromValue();
                    break;

                default:
                    if (Char.IsLetterOrDigit(key.KeyChar))
                    {
                        if (selectedElement.TakesText)
                            (selectedElement).addToValue(key.KeyChar);
                        //usernameInput.setDisplayedText(usernameInput.getDisplayedText() + key.KeyChar);
                    }
                    break;
            }
        }
    }
}
