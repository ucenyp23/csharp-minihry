using System;
using System.Numerics;

namespace piskvorky
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter board size (3-20): ");
            int size = Convert.ToInt32(Console.ReadLine());
            if (size < 3 || size > 20)
            {
                Console.WriteLine("Invalid board size. Please enter a number between 3 and 20.");
                return;
            }

            int[][] board = new int[size][];
            for (int i = 0; i < size; i++)
            {
                board[i] = new int[size];
            }

            int currentPlayer = 1;

            while (true)
            {
                PrintBoard(board, size);
                Console.Write($"Player {currentPlayer}, input number of your next move (1-{size * size}): ");
                int move = Convert.ToInt32(Console.ReadLine()) - 1;

                int row = move / size;
                int col = move % size;

                if (move < 0 || move >= size * size || board[row][col] != 0)
                {
                    Console.WriteLine("Invalid move, try again.");
                    continue;
                }

                board[row][col] = currentPlayer;

                int winCondition = size >= 6 ? 5 : size;

                if (CheckWin(board, size, winCondition, currentPlayer))
                {
                    PrintBoard(board, size);
                    Console.WriteLine($"Player {currentPlayer} wins!");
                    break;
                }

                if (IsBoardFull(board, size))
                {
                    PrintBoard(board, size);
                    Console.WriteLine("It's a draw!");
                    break;
                }

                currentPlayer = 3 - currentPlayer;
            }
        }

        static void PrintBoard(int[][] board, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
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

        static bool CheckWin(int[][] board, int size, int winCondition, int player)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j <= size - winCondition; j++)
                {
                    bool winRow = true;
                    bool winCol = true;
                    for (int k = 0; k < winCondition; k++)
                    {
                        if (board[i][j + k] != player)
                            winRow = false;
                        if (board[j + k][i] != player)
                            winCol = false;
                    }
                    if (winRow || winCol)
                        return true;
                }
            }

            for (int i = 0; i <= size - winCondition; i++)
            {
                for (int j = 0; j <= size - winCondition; j++)
                {
                    bool winDiag1 = true;
                    bool winDiag2 = true;
                    for (int k = 0; k < winCondition; k++)
                    {
                        if (board[i + k][j + k] != player)
                            winDiag1 = false;
                        if (board[i + k][j + winCondition - 1 - k] != player)
                            winDiag2 = false;
                    }
                    if (winDiag1 || winDiag2)
                        return true;
                }
            }

            return false;
        }

        static bool IsBoardFull(int[][] board, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (board[i][j] == 0)
                        return false;
                }
            }
            return true;
        }
    }
}
