using System.Numerics;

namespace piskvorky
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[3] { 0, 0, 0 };
            int[] b = new int[3] { 0, 0, 0 };
            int[] c = new int[3] { 0, 0, 0 };
            int[][] x = new int[][] {a, b, c};
            bool z = true;

            while (z)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (x[i][j] == 0)
                        {
                            Console.Write("-");
                        }
                        else if (x[i][j] == 1)
                        {
                            Console.Write("X");
                        }
                        else if (x[i][j] == 2)
                        {
                            Console.Write("O");
                        }
                    }
                    Console.WriteLine();
                }
                Console.Write("Input number of your next move: ");
                int y = Convert.ToInt32( Console.ReadLine());

                for (int i = 0; i < 3; i++)
                {
                    if (x[i][0] == 1 && x[i][1] == 1 && x[i][2] == 1)
                        z = false;
                    if (x[i][0] == 1 && x[i][1] == 1 && x[i][2] == 1)
                        z = false;
                }

                // Check columns
                for (int i = 0; i < 3; i++)
                {
                    if (x[0, i] == player && x[1, i] == player && x[2, i] == player)
                        z = false;
                }

                // Check diagonals
                if (x[0, 0] == player && x[1, 1] == player && x[2, 2] == player)
                    z = false;
                if (x[0, 2] == player && x[1, 1] == player && x[2, 0] == player)
                    z = false;
            }
        }
    }
}
