using System;
using System.Collections.Generic;
using System.Text;

namespace NoCap_3_5_6_8_
{

    class Menu
    {
        private static int index = 0;

        List<string> menuItems = new List<string>()
        {
            "Start","Settings","Exit"
        };
        public Menu()
        {
            Console.CursorVisible = false;
        }

        public string drawMenu()
        {
            for (int i = 0; i < menuItems.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                int centerX = (Console.WindowWidth / 2) - (menuItems[i].Length / 2);
                int centerY = (Console.WindowHeight / 2) + i;
                Console.SetCursorPosition(centerX, centerY);
                Console.Write(menuItems[i]);
                Console.ResetColor();
            }

            ConsoleKeyInfo okey = Console.ReadKey();

            if (okey.Key == ConsoleKey.DownArrow)
            {
                if (index == menuItems.Count - 1) index = 0;
                else index++;
            }
            else if (okey.Key == ConsoleKey.UpArrow)
            {
                if (index <= 0) index = menuItems.Count - 1;
                else index--;
            }
            else if (okey.Key == ConsoleKey.Enter)
            {
                return menuItems[index];
            }
            else
            {
                return "";
            }

            Console.Clear();
            return "";

        }

    }

}
