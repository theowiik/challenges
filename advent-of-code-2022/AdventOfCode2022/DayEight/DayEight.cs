using AdventOfCode2022.Utils;

namespace AdventOfCode2022.DayEight;

public sealed class DayEight : IAdventChallenge
{
  public int GetDay() => 8;

  private class Tree
  {
    public int Height { get; set; }
  }

  public void Run()
  {
    var grid = BuildGrid();
    var visible = new List<Tree>();

    foreach (var column in grid)
    {
      for (var i = 0; i < column.Count; i++)
      {
        if (i == 0)
        {
          visible.Add(column.First());
          continue;
        }

        if (column[i].Height > column[i - 1].Height)
        {
          visible.Add(column[i]);
        }
        else
        {
          break;
        }
      }
    }

    Console.WriteLine("Part 1: " + visible.Distinct().Count());
  }

  private List<List<Tree>> BuildGrid()
  {
    var grid = new List<List<Tree>>();

    foreach (var line in AdventFileReader.GetLines(GetDay()))
    {
      var i = 0;
      foreach (var c in line)
      {
        if (grid.Count < i + 1) grid.Add(new List<Tree>());

        var height = int.Parse(c.ToString());
        grid[i].Add(new Tree { Height = height });

        i++;
      }
    }

    return grid;
  }
}