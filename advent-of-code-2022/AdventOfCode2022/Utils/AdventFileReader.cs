using System.Reflection;

namespace AdventOfCode2022.Utils;

public sealed class AdventFileReader
{
  public static IEnumerable<string> GetLines(int day)
  {
    return GetLines($"{day}.data");
  }

  public static IEnumerable<string> GetLines(string fileName)
  {
    var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"Data/{fileName}");
    return File.ReadLines(path);
  }
}