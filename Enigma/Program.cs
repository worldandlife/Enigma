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
    /// <summary>
    /// Enigma - WW2 encryption machine (light version)
    /// © worldandlife
    /// </summary>
    class Enigma
    {
        //alphabet
        char[] table = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        //reflector
        char[] tableReflector = "yruhqsldpxngokmiebfzcwvjat".ToCharArray();

        //switching panel
        //the letters are paired together
        Dictionary<char, char> commutationPanel = new Dictionary<char, char>
        {
            {'q', 'e'}, {'z', 'd'}, {'v', 'i'}, {'s', 'b'},
            {'e', 'q'}, {'d', 'z'}, {'i', 'v'}, {'b', 's'},

            {'a', 'j'}, {'p', 'y'}, {'f', 't'},
            {'j', 'a'}, {'y', 'p'}, {'t', 'f'},

            {'c', 'l'}, {'g', 'x'}, {'n', 'o'},
            {'l', 'c'}, {'x', 'g'}, {'o', 'n'},
        };
        //rotors
        int rightRotor, middleRotor, leftRotor;
        //setting the rotors starting position
        public Enigma(int rr, int mr, int lr)
        {
            rightRotor = rr;
            middleRotor = mr;
            leftRotor = lr;
        }

        //encryption function
        public char Encrypt(char ch)
        {
            //get the length of the alphabet
            var len = table.Length;
            //changing the letter before getting the position according to the switching scheme
            if (commutationPanel.ContainsKey(ch))
                ch = commutationPanel[ch];
            //current position of the character in the alphabet
            var pos = Array.IndexOf(table, ch);
            //get a position with a shift using the movement of the rotors
            pos = (pos + rightRotor + middleRotor + leftRotor) % len;
            //before handing the position to refactor subtract the last rotor
            pos = (pos + (len - leftRotor)) % len;
            //passing the position to the reflector
            pos = (Array.IndexOf(table, tableReflector[pos]) + leftRotor) % len;
            pos = (pos + (len - leftRotor - middleRotor - rightRotor)) % len;
            //if the position is negative, set it to the correct position
            if (pos < 0)
                pos += len;

            //moving the rotors
            rightRotor++;
            if (rightRotor == len)
            {
                rightRotor = 0;
                middleRotor++;
                if (middleRotor == len)
                {
                    middleRotor = 0;
                    leftRotor++;
                    if (leftRotor == len)
                        leftRotor = 0;
                }
            }
            //changing the letter after getting the position according to the switching scheme
            var result = table[pos];
            if (commutationPanel.ContainsKey(table[pos]))
                result = commutationPanel[table[pos]];

            return result;
        }
    }
}
