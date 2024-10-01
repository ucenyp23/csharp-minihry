using System.Numerics;
using System.Runtime.ExceptionServices;

namespace piskvorky
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] a = new int[3] { 0, 0, 0 };
            int[] b = new int[3] { 0, 0, 0 };
            int[] c = new int[3] { 0, 0, 0 };
            int[][] board = new int[][] {a, b, c};

            while (true)
            {
                PrintBoard(board);
                Console.Write("Input number of your next move (1-9): ");
                int move = Convert.ToInt32(Console.ReadLine()) - 1;

                int row = move / 3;
                int col = move % 3;

                if (move < 0 || move >= 9 || board[row][col] != 0)
                {
                    Console.WriteLine("Invalid move, try again.");
                    continue;
                }

                board[row][col] = 1;

                int rowai = rnd.Next(0, 3);
                int colai = rnd.Next(0, 3);

                board[rowai][colai] = 2;

                if (CheckWin(board, 1))
                {
                    PrintBoard(board);
                    Console.WriteLine("You, win!");
                    break;
                }

                if (CheckWin(board, 2))
                {
                    PrintBoard(board);
                    Console.WriteLine("You, lost!");
                    break;
                }

                if (IsBoardFull(board))
                {
                    PrintBoard(board);
                    Console.WriteLine("It's a draw!");
                    break;
                }
            }
        }
        static void PrintBoard(int[][] board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i][j] == 0)
                    {
                        Console.Write("-");
                    }
                    else if (board[i][j] == 1)
                    {
                        Console.Write("X");
                    }
                    else if (board[i][j] == 2)
                    {
                        Console.Write("O");
                    }
                }
                Console.WriteLine();
            }
        }
        static bool CheckWin(int[][] board, int player)
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i][0] == player && board[i][1] == player && board[i][2] == player)
                    return true;
                if (board[0][i] == player && board[1][i] == player && board[2][i] == player)
                    return true;
            }

            if (board[0][0] == player && board[1][1] == player && board[2][2] == player)
                return true;
            if (board[0][2] == player && board[1][1] == player && board[2][0] == player)
                return true;

            return false;
        }
        static bool IsBoardFull(int[][] board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i][j] == 0)
                        return false;
                }
            }
            return true;
        }
    }
}