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
            foreach (int[] i in x) {
                foreach (int j in i)
                {
                    if (j == 0)
                    {
                    Console.Write("-");
                    }
                    else if (j == 1)
                    {
                    Console.Write("X");
                    }
                    else if (j == 2)
                    {
                    Console.Write("O");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
