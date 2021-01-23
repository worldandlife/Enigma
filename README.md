# Enigma - WW2 Encryption machine
The Enigma machine is a cipher device developed and used in the early - to mid-20th century to protect commercial, diplomatic, and military communication. It was employed extensively by Nazi Germany during World War II, in all branches of the German military. The Germans believed, erroneously, that use of the Enigma machine enabled them to communicate securely and thus enjoy a huge advantage in World War II. The Enigma machine was considered to be so secure that even the most top–secret messages were enciphered on its electrical circuits.

![Image alt](http://thomascsanger.com/wp-content/uploads/2018/05/enigma4-600x380.jpg, "Enigma")

# Usage
Seting starting position
```c#
var e = new Enigma(12, 8, 20);
```
Setting up the plugboard
```c#
Dictionary<char, char> plugboard = new Dictionary<char, char>
{
    {'q', 'e'}, {'z', 'd'}, {'v', 'i'}, {'s', 'b'},
    {'e', 'q'}, {'d', 'z'}, {'i', 'v'}, {'b', 's'},

    {'a', 'j'}, {'p', 'y'}, {'f', 't'},
    {'j', 'a'}, {'y', 'p'}, {'t', 'f'},

    {'c', 'l'}, {'g', 'x'}, {'n', 'o'},
    {'l', 'c'}, {'x', 'g'}, {'o', 'n'},
};
```
Enjoy:smiley:

![Image alt](https://psv4.userapi.com/c536132/u75139039/docs/d44/febe4cd05e52/enigma.jpg?extra=jnGk-m-R1cK17Fe7Ps5mP_oyTkMWZ2skpbZqgPuedSCG-HGhBLBN2CWpv3tiGqFN5yUYqqmj0z6xA6XSdK_9lRk0KhPTufIIAy3_AAy-1e6jX6fT8Sz8GNA1N5RfZUdhVNJrK6n1fhz6V906iJXFWSY, "Enigma console")
