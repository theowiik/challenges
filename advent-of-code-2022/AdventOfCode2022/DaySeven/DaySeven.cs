using AdventOfCode2022.Utils;

namespace AdventOfCode2022;

public sealed class DaySeven : IAdventChallenge
{
  public int GetDay() => 7;

  private class Node
  {
    public string Name { get; set; }
    public int FileSize { get; set; } = -1;
    public int DirSize { get; set; } = -1;
    public IList<Node> Children { get; } = new List<Node>();
    public bool IsDir => FileSize == -1;
    public Node Parent { get; set; }
  }

  public void Run()
  {
    var root = BuildTree();
    MeasureSizesRec(root);
    var total = AllDirUnder(root, 100_000).Sum(c => c.DirSize);

    Console.WriteLine("Part 1: " + total);
  }

  private Node BuildTree()
  {
    var root = new Node { Name = "/" };
    root.Parent = root;
    var current = root;

    foreach (var line in AdventFileReader.GetLines(GetDay()))
    {
      if (line.StartsWith("$ cd .."))
      {
        current = current.Parent;
        continue;
      }

      if (line.StartsWith("$ cd /"))
      {
        current = root;
        continue;
      }

      if (line.StartsWith("$ cd"))
      {
        var go = line.Split(" ")[2];

        var notAdded = current.Children.All(c => c.Name != go);
        if (notAdded) current.Children.Add(new Node { Name = go, Parent = current });

        current = current.Children.First(c => c.Name == go && c.IsDir);
        continue;
      }

      if (line.StartsWith("$ ls"))
      {
        continue;
      }

      // Is currently listing directories and files
      var isNumber = int.TryParse(line.Split(" ").First(), out var fileSize);

      if (isNumber)
      {
        var fileName = line.Split(" ")[1];
        var alreadyHasFile = current.Children.Any(c => c.Name == fileName && !c.IsDir);
        if (alreadyHasFile) continue;

        current.Children.Add(new Node() { Name = fileName, FileSize = fileSize, Parent = current });
      }
    }

    return root;
  }

  private static IEnumerable<Node> AllDirUnder(Node root, int maxSize)
  {
    if (!root.IsDir) return Array.Empty<Node>();

    var all = new List<Node>();
    var children = root.Children.Where(c => c.IsDir && c.FileSize <= maxSize);
    all.AddRange(children);

    foreach (var child in children)
    {
      all.AddRange(AllDirUnder(child, maxSize));
    }

    return all;
  }

  private void MeasureSizesRec(Node root)
  {
    if (!root.IsDir) return;

    foreach (var child in root.Children)
    {
      MeasureSizesRec(child);
    }

    var childrenFileSizes = root.Children.Where(c => !c.IsDir).Select(c => c.FileSize).Sum();
    var childrenDirSizes = root.Children.Where(c => c.IsDir).Select(c => c.DirSize).Sum();

    root.DirSize = childrenFileSizes + childrenDirSizes;
  }
}