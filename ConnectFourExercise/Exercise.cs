using System;

namespace ConnectFourExercise
{

  public class Exercise
  {

    public enum Player
    {
      Red = 1,
      Black = 2,
    }

    public string FindWinner(int width, int height, int[] moves)
    {
      return GetWinningPlayerDescription(PlayMoves(width, height, moves));
    }

    public Player? PlayMoves(int width, int height, int[] moves)
    {
      Player? winningPlayer = null;

      var board = new int[width, height];
      var columFloors = new int[width];

      for (int idx = 0; idx < moves.Length; idx++)
      {
        var player = GetPlayer(idx);
        int moveColumn = moves[idx] - 1;
        int moveColumnFloor = columFloors[moveColumn];

        //Increment the bottom because we're dropping a piece in the column
        columFloors[moveColumn]++;

        //Perform the move
        board[moveColumn, moveColumnFloor] = (int)player;

        //Determine if the move creates a winning condition
        winningPlayer = EvaluateWinConditions(board, width, height, player, moveColumn, moveColumnFloor);

        if (winningPlayer.HasValue) break;
      }

      return winningPlayer;
    }

    public Player? EvaluateWinConditions(int[,] board, int width, int height, Player movePlayer, int moveColumn, int moveRow)
    {      
      //Get the bounding box for pieces that could participate in this move
      int top = moveRow + 3 < (height - 1) ? moveRow + 3 : (height - 1);
      int bottom = moveRow - 3 > 0 ? moveRow - 3 : 0;
      int left = moveColumn - 3 > 0 ? moveColumn - 3 : 0;
      int right = moveColumn + 3 < (width - 1) ? moveColumn + 3 : (width - 1);
      
      Player? winner = EvaluateVerticalWin(board, moveColumn, movePlayer, top, bottom);
      if (winner.HasValue) return winner;

      winner = EvaluateHorizontalWin(board, moveRow, movePlayer, left, right);
      if (winner.HasValue) return winner;
      
      winner = EvaluateDiagonalWin_TopLeftToBottomRight(board, movePlayer, top, right, bottom, left);
      if (winner.HasValue) return winner;

      winner = EvaluateDiagonalWin_BottomLeftToTopRight(board, movePlayer, top, right, bottom, left);
      if (winner.HasValue) return winner;     

      return null;
    }

    private Player? EvaluateVerticalWin(int[,] board, int currentPlayColumn, Player currentPlayer, int top, int bottom)
    {
      if (top - bottom >= 3)
      {
        int consecutivePieces = 0;
        for (int i = bottom; i <= top; i++)
        {
          if (board[currentPlayColumn, i] == (int)currentPlayer)
          {
            consecutivePieces++;
          }
          else
          {
            consecutivePieces = 0;
          }

          if (consecutivePieces >= 4) return currentPlayer;
        }
      }

      return null;
    }

    private Player? EvaluateHorizontalWin(int[,] board, int currentPlayRow, Player currentPlayer, int left, int right)
    {
      if (right - left >= 3)
      {
        int consecutivePieces = 0;
        for (int i = left; i <= right; i++)
        {
          if (board[i, currentPlayRow] == (int)currentPlayer)
          {
            consecutivePieces++;
          }
          else
          {
            consecutivePieces = 0;
          }

          if (consecutivePieces >= 4) return currentPlayer;
        }
      }

      return null;
    }
    
    private Player? EvaluateDiagonalWin_TopLeftToBottomRight(int[,] board, Player currentPlayer, int top, int right, int bottom, int left)
    {
      if (top - bottom >= 3 && right - left >= 3)
      {
        int consecutivePieces = 0;
        int iteration = 0;

        //Evaluate from top left to bottom right
        for (int i = top; i >= bottom; i--)
        {
          int column = left + iteration;
          iteration++;

          //Stop evaluation if we'll exceed the horizontal bounds
          if (column > right) break;

          if (board[column, i] == (int)currentPlayer)
          {
            consecutivePieces++;
          }
          else
          {
            consecutivePieces = 0;
          }

          if (consecutivePieces >= 4) return currentPlayer;
        }
      }

      return null;
    }

    private Player? EvaluateDiagonalWin_BottomLeftToTopRight(int[,] board, Player currentPlayer, int top, int right, int bottom, int left)
    {
      //Evaluate from bottom left to top right
      int iteration = 0;
      int consecutivePieces = 0;
      for (int i = bottom; i <= top; i++)
      {
        int column = left + iteration;
        iteration++;

        //Stop evaluation if we'll exceed the horizontal bounds
        if (column > right) break;

        if (board[column, i] == (int)currentPlayer)
        {
          consecutivePieces++;
        }
        else
        {
          consecutivePieces = 0;
        }

        if (consecutivePieces >= 4) return currentPlayer;
      }

      return null;
    }

    public Player GetPlayer(int moveIndex)
    {
      //Red always goes first (moveIndex is 0-based)
      if ((moveIndex + 1) % 2 == 0) return Player.Black;

      return Player.Red;
    }

    public string GetWinningPlayerDescription(Player? player)
    {
      if (player == null) return "a draw";

      switch (player.Value)
      {
        case Player.Red:
          return "Red";

        case Player.Black:
          return "Black";

        default:
          throw new ArgumentOutOfRangeException("Invalid Player specified: " + player);
      }
    }

  }

}
