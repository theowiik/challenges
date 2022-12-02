using System.Reflection;

var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data.dat");

var sum = 0;
foreach (var line in File.ReadLines(path))
{
  if (string.IsNullOrWhiteSpace(line)) continue;

  var opponent = line.Split(" ").First().ToShape();
  var me = line.Split(" ").Last().ToShape();

  sum += GameExtensions.RoundScore(opponent, me) + me.ToScore();
}

Console.WriteLine("Part one: " + sum);

sum = 0;
foreach (var line in File.ReadLines(path))
{
  if (string.IsNullOrWhiteSpace(line)) continue;

  var opponent = line.Split(" ").First().ToShape();
  var me = line.Split(" ").Last();

  sum += GameExtensions.RoundScorePartTwo(opponent, me);
}

Console.WriteLine("Part two: " + sum);

public static class GameExtensions
{
  public static Shape ToShape(this string str)
  {
    return str switch
    {
      "A" or "X" => Shape.Rock,
      "B" or "Y" => Shape.Paper,
      "C" or "Z" => Shape.Scissor,
      _ => throw new Exception()
    };
  }

  public static int ToScore(this Shape s)
  {
    return s switch
    {
      Shape.Rock => 1,
      Shape.Paper => 2,
      Shape.Scissor => 3,
      _ => throw new Exception()
    };
  }

  public static int RoundScore(Shape opponent, Shape me)
  {
    if (me == opponent) return 3;

    if (me == Shape.Paper && opponent == Shape.Rock) return 6;
    if (me == Shape.Scissor && opponent == Shape.Paper) return 6;
    if (me == Shape.Rock && opponent == Shape.Scissor) return 6;

    return 0;
  }

  public static Shape GetLosing(this Shape s)
  {
    return s switch
    {
      Shape.Rock => Shape.Scissor,
      Shape.Paper => Shape.Rock,
      Shape.Scissor => Shape.Paper,
      _ => throw new Exception()
    };
  }
  
  public static Shape GetWinning(this Shape s)
  {
    return s switch
    {
      Shape.Rock => Shape.Paper,
      Shape.Paper => Shape.Scissor,
      Shape.Scissor => Shape.Rock,
      _ => throw new Exception()
    };
  }

  public static int RoundScorePartTwo(Shape opponent, string me)
  {
    switch (me)
    {
      case "X":
        return 0 + opponent.GetLosing().ToScore();
      case "Y":
        return 3 + opponent.ToScore();
      case "Z":
        return 6 + opponent.GetWinning().ToScore();
      default:
        throw new Exception();
    }
  }
}

public enum Shape
{
  Rock,
  Paper,
  Scissor
}