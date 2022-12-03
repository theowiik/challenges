using AdventOfCode2022;
using AdventOfCode2022.DayOne;
using AdventOfCode2022.DayThree;
using AdventOfCode2022.DayTwo;

void PrintComment(int day)
{
  Console.WriteLine("");
  Console.WriteLine($"--------- Day {day} ---------");
}

var challenges = new List<IAdventChallenge>() { new DayOne(), new DayTwo(), new DayThree() };

foreach (var c in challenges)
{
  try
  {
    PrintComment(c.GetDay());
    c.Run();
  }
  catch (Exception e)
  {
    Console.WriteLine("Ouchie :(");
    throw;
  }
}