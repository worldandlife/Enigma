using System;
using System.Collections.Generic;

namespace Enigma
{
    class Program
    {
        //converts char characters to uppercase
        static char ToUpper(char s)
        {
            if (s < 'a' || s > 'z') return s;

            return (char)(s - 32);
        }
        //drawing UI
        public static void DrawUI(char ch)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            char[] alphabet = "qwertyuiopasdfghjklzxcvbnm".ToCharArray();
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (alphabet[i] == 'a' || alphabet[i] == 'z')
                    Console.WriteLine();
                if (alphabet[i] == ch)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(ToUpper(alphabet[i]) + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                    Console.Write(ToUpper(alphabet[i]) + " ");
            }

        }
        static void Main(string[] args)
        {
            //starting the Enigma with the specified starting position
            var e = new Enigma(12, 8, 20);
            var newCh = '.';
            while (true)
            {
                DrawUI(newCh);
                ConsoleKeyInfo pressed;
                pressed = Console.ReadKey();
                newCh = e.Encrypt(pressed.KeyChar);
            }
        }
    }
  
}
