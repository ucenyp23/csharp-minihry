using System.IO;

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
            int attempts = 12;

            while (attempts > 0 && new string(guessedWord) != wordToGuess)
            {
                Console.Clear();
                Console.WriteLine("Šibenice");
                Console.WriteLine("Slovo: " + new string(guessedWord));
                Console.WriteLine("Špatné pokusy: " + string.Join(", ", incorrectGuesses));
                Console.WriteLine("Zbývající pokusy: " + attempts);
                Console.Write("Hádej písmeno: ");
                char guess = Console.ReadLine()[0];

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
    }
}
