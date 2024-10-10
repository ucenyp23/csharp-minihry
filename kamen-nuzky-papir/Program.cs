namespace kamen_nuzky_papir
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int playerWins = 0;
            int aiWins = 0;

            string[] options = { "stone", "paper", "scissors" };

            while (playerWins < 2 && aiWins < 2)
            {
                Console.Write("Input (stone, paper, scissors): ");
                string x = Console.ReadLine().ToLower();
                int y = rnd.Next(0, 3);

                string aiChoice = options[y];
                Console.WriteLine($"AI chose: {aiChoice}");

                if (x == aiChoice)
                {
                    Console.WriteLine("Draw!");
                }
                else if ((x == "stone" && aiChoice == "scissors") || (x == "paper" && aiChoice == "stone") || (x == "scissors" && aiChoice == "paper"))
                {
                    Console.WriteLine("You won this round!");
                    playerWins++;
                }
                else if ((x == "stone" && aiChoice == "paper") || (x == "paper" && aiChoice == "scissors") || (x == "scissors" && aiChoice == "stone"))
                {
                    Console.WriteLine("You lost this round!");
                    aiWins++;
                }
                else
                {
                    Console.WriteLine("Incorrect input!");
                }

                Console.WriteLine($"Score: You {playerWins} - {aiWins} AI");
            }

            if (playerWins == 2)
            {
                Console.WriteLine("Congratulations! You won the game!");
            }
            else
            {
                Console.WriteLine("Sorry! You lost the game.");
            }
        }
    }
}
