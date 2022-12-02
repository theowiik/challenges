// using System.Reflection;
//
// public class Program
// {
//   public static int PartOne()
//   {
//     var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data.dat");
//     var strategies = new List<Func<Shape, int>>
//       { ScoreCalculator.WinScore, ScoreCalculator.LoseScore, ScoreCalculator.TieScore };
//
//     var i = 0;
//     var sum = File.ReadLines(path).Sum(x => strategies[i++ % 3].Invoke(x.ToShape()));
//
//     return sum;
//   }
//
//   public static int PartOneV2()
//   {
//     var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data.dat");
//
//     var i = 0;
//     var sum = File.ReadLines(path).Sum(x => x.Split(" ").First().ToShape().ToScore());
//
//     return sum;
//   }
//
//   public static void Maxin(string[] args)
//   {
//     Console.WriteLine("Score: " + PartOneV2());
//   }
// }
//
// public static class ScoreCalculator
// {
//   public static int WinScore(Shape s)
//   {
//     return s switch
//     {
//       Shape.Rock => Shape.Paper.ToScore(),
//       Shape.Paper => Shape.Scissor.ToScore(),
//       Shape.Scissor => Shape.Rock.ToScore()
//     } + 6;
//   }
//
//   public static int TieScore(Shape s) => s.ToScore() + 3;
//
//   public static int LoseScore(Shape s) => s.ToScore();
// }
//
// public static class ShapeExtensions
// {
//   public static Shape ToShape(this string str)
//   {
//     return str switch
//     {
//       "A" or "X" => Shape.Rock,
//       "B" or "Y" => Shape.Paper,
//       "C" or "Z" => Shape.Scissor,
//       _ => throw new Exception()
//     };
//   }
//
//   public static int ToScore(this Shape s)
//   {
//     return s switch
//     {
//       Shape.Rock => 1,
//       Shape.Paper => 2,
//       Shape.Scissor => 3,
//       _ => throw new Exception()
//     };
//   }
// }
//
// public enum Shape
// {
//   Rock,
//   Paper,
//   Scissor
// }