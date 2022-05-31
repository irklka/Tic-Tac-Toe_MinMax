using System;
using System.Linq;

namespace Tic_Tac_Toe_MinMax
{
    public static class GameStart
    {
        static string[] board;

        static void Main(string[] args)
        {
            board = new string[9];
            string turn = "X";

            // დაფის შევსება რიცხვებით
            for (int i = 0; i < 9; ++i)
                board[i] = (i + 1).ToString();

            PrintBoard();
            Console.WriteLine("Game Started!");

            while (true)
            {
                int numInput;
                Console.WriteLine("Your Turn, Enter Number {you are 'X'}: ");

                while (true)
                {
                    numInput = Int32.Parse(Console.ReadLine()[0].ToString());
                    if (numInput > 0 && numInput <= 9)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong Number, Try again: ");
                    }
                }

                if (board[numInput - 1] == numInput.ToString())
                {
                    board[numInput - 1] = turn;
                    turn = "O";
                }

                if (turn == "O")
                {
                    MinMax.PlayBestMove(board);
                    PrintBoard();
                    turn = "X";
                }
                else
                {
                    Console.WriteLine("Number is already taken try again: ");
                }

                if (WinnerIsKnown()) break;

            }
        }

        public static string CheckWinner()
        {
            for (int i = 0; i < 8; i++)
            {
                string line = string.Empty;

                switch (i)
                {
                    case 0:
                        line = board[0] + board[1] + board[2];
                        break;
                    case 1:
                        line = board[3] + board[4] + board[5];
                        break;
                    case 2:
                        line = board[6] + board[7] + board[8];
                        break;
                    case 3:
                        line = board[0] + board[3] + board[6];
                        break;
                    case 4:
                        line = board[1] + board[4] + board[7];
                        break;
                    case 5:
                        line = board[2] + board[5] + board[8];
                        break;
                    case 6:
                        line = board[0] + board[4] + board[8];
                        break;
                    case 7:
                        line = board[2] + board[4] + board[6];
                        break;
                }

                //თუ X-მ გაიმარჯვა
                if (line == "XXX")
                    return "X";
                //თუ O-მ გაიმარჯვა
                else if (line == "OOO")
                    return "O";
            }
            for (int i = 0; i < 9; i++)
            {
                if (!board.Contains((i + 1).ToString()))
                {
                    if (i == 8)
                        return "Draw";
                }
                else break;
            }
            return null;
        }

        public static bool WinnerIsKnown()
        {
            string winner = CheckWinner();
            if (winner != null)
            {
                if (winner == "O")
                {
                    Console.Write("You lost, ");
                }
                else if (winner == "Draw")
                {
                    Console.Write("Draw, ");
                }
                else Console.WriteLine("You won, ");
                Console.WriteLine("Game Over.");

                return true;
            }
            return false;
        }

        public static void PrintBoard()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"|---|---|---|");
            Console.WriteLine($"| {board[0]} | {board[1]} | {board[2]} |");
            Console.WriteLine($"|-----------|");
            Console.WriteLine($"| {board[3]} | {board[4]} | {board[5]} |");
            Console.WriteLine($"|-----------|");
            Console.WriteLine($"| {board[6]} | {board[7]} | {board[8]} |");
            Console.WriteLine($"|---|---|---|");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
