using System;
using System.Collections.Generic;

namespace Enigma
{
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

        //plugboard
        //the letters are paired together
        Dictionary<char, char> plugboard = new Dictionary<char, char>
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
            //changing the letter before getting the position according to the plugboard scheme
            if (plugboard.ContainsKey(ch))
                ch = plugboard[ch];
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
            //changing the letter after getting the position according to the plugboard scheme
            var result = table[pos];
            if (plugboard.ContainsKey(table[pos]))
                result = plugboard[table[pos]];

            return result;
        }
    }
}
