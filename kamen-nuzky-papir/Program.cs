namespace kamen_nuzky_papir
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.Write("Input (stone, paper, scisors): ");
            string x = Console.ReadLine();
            int y = rnd.Next(0, 3);

            if ((x == "stone" && y == 2) || (x == "paper" && y == 0) || (x == "scisors" && y == 1))
            {
                Console.WriteLine("You Won!");
            }
            else if ((x == "stone" && y == 0) || (x == "paper" && y == 1) || (x == "scisors" && y == 2))
            {
                Console.WriteLine("Draw!");
            }
            else if ((x == "stone" && y == 1) || (x == "paper" && y == 2) || (x == "scisors" && y == 0))
            {
                Console.WriteLine("You Lost!");
            }
            else
            {
                Console.WriteLine("Incorect input!");
            }
        }
    }
}
