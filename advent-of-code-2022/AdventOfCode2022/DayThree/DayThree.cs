using AdventOfCode2022.Utils;

namespace AdventOfCode2022.DayThree;

public sealed class DayThree : IAdventChallenge
{
  private static readonly IList<string> Alphabet = new List<string> {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"};
  
  public int GetDay()
  {
    return 3;
  }

  public void Run()
  {
    var sum = 0;
    foreach (var line in AdventFileReader.GetLines(GetDay()))
    {
      if (string.IsNullOrWhiteSpace(line)) continue;

      var first = line[..(line.Length / 2)];
      var second = line[(line.Length / 2)..];

      var h1 = first.ToCharArray().ToHashSet();
      var h2 = second.ToCharArray().ToHashSet();

      var dupe = h1.First(s => h2.Contains(s));
      
      sum += GetPoints(dupe.ToString());
    }
    
    Console.WriteLine(sum);
  }

  private static int GetPoints(string s)
  {
    var offset = s.Equals(s.ToUpper()) ? 26 : 0;
    return Alphabet.IndexOf(s.ToLower()) + 1 + offset;
  }
}