﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBot
{
    public delegate void Action();

    class LogIn : MenuContent
    {
        SelectableElement usernameInput;
        SelectableElement passwordInput;
        SelectableElement submit;

        public LogIn(string title, MenuTree owner) : base(title, owner)
        {

            Action del = new Action(submitCredentials);

            usernameInput = new SelectableElement(true, "Username: ", 10, 2);
            passwordInput = new SelectableElement(true, "Password: ", 10, 4);
            submit = new SelectableElement(false, "Submit", 10, 6, del);


            elements.Insert(0, usernameInput);
            elements.Insert(1, passwordInput);
            elements.Insert(2, submit);

            selectedElement = elements[0];

            elements[3].xLocation = Console.WindowWidth / 2 - 5;
            elements[3].yLocation = Console.WindowHeight - 8;

            elements[4].xLocation = Console.WindowWidth / 2 - 5;
            elements[4].yLocation = Console.WindowHeight - 6;


        }

        public void submitCredentials()
        {
            string username = usernameInput.getValue();
            string pass = passwordInput.getValue();

            switch (UserDB.attemptLogin(username, pass))
            {
                case 0:
                    Console.WriteLine("Successfully Logged In!");
                    
                    break;

                case 1:
                    Console.WriteLine("Incorrect Password!");
                    break;

                case 2:
                    Console.WriteLine("Account Does Not Exist!");
                    break;
            }
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
            Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 3 );
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
                    if(Char.IsLetterOrDigit(key.KeyChar))
                    {
                        if(selectedElement.TakesText)
                            (selectedElement).addToValue(key.KeyChar);
                        //usernameInput.setDisplayedText(usernameInput.getDisplayedText() + key.KeyChar);
                    }
                    break;
            }
        }
    }
}
