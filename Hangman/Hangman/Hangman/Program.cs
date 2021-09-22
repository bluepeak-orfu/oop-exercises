using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            var usedLetters = "";
            var secretWord = new string[] { "b", "a", "n", "a", "n" };
            var correctGuesses = new bool[] { false, false, false, false, false };
            var errorCount = 0;
            var defaultLives = 5;
            while (true)
            {
                if (errorCount == defaultLives)
                {
                    Console.WriteLine("Inga gissningar kvar, du har förlorat denna gång!");
                    break;
                }
                var completed = true;
                
                for (var i = 0; i < correctGuesses.Length; i ++)
                {
                    if (!correctGuesses[i])
                    {
                        completed = false;
                        break;
                    }
                }

                if (completed)
                {
                    Console.WriteLine("Grattis du har vunnit!");
                    break;
                }

                var lives = "";
                for (var i = 0; i < defaultLives - errorCount; i++)
                {
                    lives = lives + "|";
                }

                Console.WriteLine("Antal liv kvar " + lives);

                var ghostLetters = "";
                for (var i = 0; i < secretWord.Length; i++)
                {
                    if (correctGuesses[i])
                    {
                        ghostLetters = ghostLetters + secretWord[i];
                    } else
                    {
                        ghostLetters = ghostLetters + "_";
                    }
                    
                }
                Console.WriteLine(ghostLetters);


                Console.WriteLine(usedLetters);

                var input = Console.ReadLine();
                if (usedLetters == "")
                {
                    usedLetters = input;
                } else
                {
                    usedLetters = usedLetters + ", " + input;
                }
                
                var match = false;
                for (var i = 0; i < secretWord.Length; i++)
                {
                    if (input.ToLower() == secretWord[i].ToLower())
                    {
                        correctGuesses[i] = true;
                        match = true;
                    }
                }

                if (!match)
                {
                    errorCount++;
                }
                
                Console.Clear();
            }
        }
    }
}
