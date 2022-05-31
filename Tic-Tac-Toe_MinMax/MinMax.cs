using System;

namespace Tic_Tac_Toe_MinMax
{
    public static class MinMax
    {
        private static int MAX_DEPTH = 6;

        public static void PlayBestMove(string[] board)
        {
            int bestMove = -1;
            int bestValue = Int32.MinValue;

            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] != "X" && board[i] != "O")
                {
                    var tmp = board[i];
                    board[i] = "O";
                    int moveValue = MiniMax(board, MAX_DEPTH, false);

                    board[i] = tmp;

                    if (moveValue > bestValue)
                    {
                        bestMove = i;
                        bestValue = moveValue;
                    }
                }
            }

            if (bestMove == -1)
            {
                return;
            }

            board[bestMove] = "O";
        }

        public static int MiniMax(string[] board, int depth, bool isMax)
        {
            string boardVal = GameStart.CheckWinner();
            if (boardVal != null)
            {
                if (boardVal == "O")
                    return 10;
                else if (boardVal == "X")
                    return -10;
                else if (depth == 0 || boardVal == "Draw")
                    return 0;
            }


            // Maximising player, find the maximum attainable value.
            if (isMax)
            {
                int highestVal = Int32.MinValue;
                for (int i = 0; i < board.Length; i++)
                {
                    if (board[i] != "X" && board[i] != "O")
                    {
                        board[i] = "O";
                        highestVal = Math.Max(highestVal, MiniMax(board, depth - 1, false));
                        board[i] = (i + 1).ToString();
                    }
                }
                return highestVal;
                // Minimising player, find the minimum attainable value
            }
            else
            {
                int lowestVal = Int32.MaxValue;
                for (int i = 0; i < board.Length; i++)
                {
                    if (board[i] != "X" && board[i] != "O")
                    {
                        board[i] = "X";
                        lowestVal = Math.Min(lowestVal, MiniMax(board, depth - 1, true));
                        board[i] = (i + 1).ToString();
                    }
                }
                return lowestVal;
            }
        }
    }
}
