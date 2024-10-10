using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace sibenice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines("slova.txt");
            Random random = new Random();
            string wordToGuess = words[random.Next(words.Length)];
            char[] guessedWord = new string('_', wordToGuess.Length).ToCharArray();
            List<char> incorrectGuesses = new List<char>();
            string[] difficultyLevels = new string[3] { "easy", "medium", "hard" };

            string difficulty = "";
            while (!Array.Exists(difficultyLevels, element => element == difficulty))
            {
                Console.Write("Choose difficulty (easy, medium, hard): ");
                difficulty = Console.ReadLine().ToLower();
            }

            int attempts;
            switch (difficulty)
            {
                case "easy":
                    attempts = 15;
                    break;
                case "hard":
                    attempts = 8;
                    break;
                default:
                    attempts = 12;
                    break;
            }

            bool hintUsed = false;
            while (attempts > 0 && new string(guessedWord) != wordToGuess)
            {
                Console.Clear();
                Console.WriteLine("Šibenice");
                Console.WriteLine("Slovo: " + new string(guessedWord));
                Console.WriteLine("Špatné pokusy: " + string.Join(", ", incorrectGuesses));
                Console.WriteLine("Zbývající pokusy: " + attempts);
                Console.WriteLine("Hint left: " + (!hintUsed ? "Yes" : "No"));

                Console.Write("Hádej písmeno (or type 'hint' for a hint): ");
                string input = Console.ReadLine().ToLower();

                if (input == "hint" && !hintUsed)
                {
                    hintUsed = true;
                    UseHint(wordToGuess, guessedWord);
                    continue;
                }

                if (string.IsNullOrEmpty(input) || input.Length > 1 || !Regex.IsMatch(input, @"^[a-zA-Z]+$"))
                {
                    continue;
                }

                char guess = input[0];

                if (wordToGuess.Contains(guess))
                {
                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuess[i] == guess)
                        {
                            guessedWord[i] = guess;
                        }
                    }
                }
                else
                {
                    if (!incorrectGuesses.Contains(guess))
                    {
                        incorrectGuesses.Add(guess);
                        attempts--;
                    }
                }
            }

            Console.Clear();
            if (new string(guessedWord) == wordToGuess)
            {
                Console.WriteLine("Gratulace! Uhodl jsi slovo: " + wordToGuess);
                Console.Write("Prosím, přidejte svoje slovo: ");
                string inputWord = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(inputWord))
                {
                    File.AppendAllText("slova.txt", Environment.NewLine + inputWord);
                }
            }
            else
            {
                Console.WriteLine("Prohrál jsi. Slovo bylo: " + wordToGuess);
            }
        }

        static void UseHint(string wordToGuess, char[] guessedWord)
        {
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (guessedWord[i] == '_')
                {
                    guessedWord[i] = wordToGuess[i];
                    break;
                }
            }
        }
    }
}
