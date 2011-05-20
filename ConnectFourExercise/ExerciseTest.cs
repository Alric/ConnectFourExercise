using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ConnectFourExercise
{
  [TestFixture]
  public class ExerciseTest
  {  

    [TestCase(2, 6, new int[] { 1, 2, 1, 2, 1, 2, 1, 2 }, Result = Exercise.Player.Red)]
    [TestCase(3, 6, new int[] { 1, 2, 1, 2, 1, 2, 3, 2 }, Result = Exercise.Player.Black)]
    [TestCase(2, 4, new int[] { 1, 2, 1, 2, 1, 2 }, Result = null)]
    [TestCase(3, 6, new int[] { 1, 2, 1, 2, 1, 2, 3, 1, 3, 3 }, Result = null)]
    public Exercise.Player? Can_Find_Vertical_Winner(int width, int height, int[] moves)
    {
      var exercise = new Exercise();

      return exercise.PlayMoves(width, height, moves);
    }

    [TestCase(4, 2, new int[] { 1, 1, 2, 2, 3, 3, 4, 4 }, Result = Exercise.Player.Red)]
    [TestCase(4, 4, new int[] { 1, 1, 2, 2, 3, 3, 1, 4, 1, 4 }, Result = Exercise.Player.Black)]
    [TestCase(3, 6, new int[] { 1, 2, 1, 2, 1, 2, 3, 1 }, Result = null)]
    [TestCase(3, 3, new int[] { 1, 2, 1, 2, 1, 2 }, Result = null)]
    public Exercise.Player? Can_Find_Horizontal_Winner(int width, int height, int[] moves)
    {
      var exercise = new Exercise();

      return exercise.PlayMoves(width, height, moves);
    }

    [TestCase(4, 6, new int[] { 1, 1, 
                                1, 2, 
                                1, 2, 
                                2, 3, 
                                3, 1,
                                4, 1 }, Result = Exercise.Player.Red)]
    [TestCase(8, 8, new int[] { 1, 1, 
                                1, 2, 
                                1, 2, 
                                2, 2, 
                                3, 3,
                                4, 3,
                                6, 4,
                                6, 5, 
                                7, 7}, Result = Exercise.Player.Black)]
    [TestCase(4, 6, new int[] { 1, 1, 
                                1, 1, 
                                2, 2, 
                                2, 3, 
                                3, 1,
                                4, 4,
                                4, 4}, Result = null)]
    public Exercise.Player? Can_Find_Diagonal_FromTopLeft_Winner(int width, int height, int[] moves)
    {
      var exercise = new Exercise();

      return exercise.PlayMoves(width, height, moves);
    }

    [TestCase(4, 6, new int[] { 1, 1, 
                                1, 2, 
                                2, 2, 
                                3, 3, 
                                3, 4,
                                4, 4,
                                4, 1}, Result = Exercise.Player.Red)]
    [TestCase(8, 8, new int[] { 2, 1, 
                                3, 2, 
                                3, 3, 
                                4, 4, 
                                4, 4}, Result = Exercise.Player.Black)]
    [TestCase(6, 6, new int[] { 2, 1, 
                                2, 3, 
                                3, 3, 
                                4, 4, 
                                4, 4, 
                                5, 5,
                                5, 5,
                                6, 5,
                                6, 6, 
                                6, 6, 
                                1, 6}, Result = Exercise.Player.Black)]
    [TestCase(6, 6, new int[] { 2, 1, 
                                2, 3, 
                                3, 3, 
                                4, 4, 
                                4, 4, 
                                5, 5,
                                5, 6,
                                5, 4,
                                6, 6, 
                                6, 6, 
                                1, 6}, Result = Exercise.Player.Red)]
    [TestCase(4, 6, new int[] { 2, 1, 
                                2, 3, 
                                3, 3, 
                                4, 4, 
                                4, 4}, Result = null)]
    public Exercise.Player? Can_Find_Diagonal_FromBottomLeft_Winner(int width, int height, int[] moves)
    {
      var exercise = new Exercise();

      return exercise.PlayMoves(width, height, moves);
    }

  }
}
