// Cant be bothered fighting with the path :-)
const string path = "/home/deux/Documents/Git/challenges/advent-of-code-2022/day1/data.txt";

var current = 0;
var total = new List<int>();

foreach (var line in File.ReadLines(path))
  if (string.IsNullOrWhiteSpace(line))
  {
    total.Add(current);
    current = 0;
  }
  else
    current += int.Parse(line);

total.Sort();
total.Reverse();

Console.WriteLine("Highest: " + total.First());
Console.WriteLine("Top 3 combined: " + total.Take(3).Sum());