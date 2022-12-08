using AdventOfCode2022.Utils;

namespace AdventOfCode2022;

public sealed class DaySeven : IAdventChallenge
{
  public int GetDay() => 7;

  private class Node
  {
    public string Name { get; set; }
    public int FileSize { get; set; }
    public int DirSize { get; set; }
    public IList<Node> Children { get; } = new List<Node>();
    public bool IsDir => FileSize == 0;
    public bool IsFile => !IsDir;
    public Node Parent { get; set; }
  }

  public void Run()
  {
    var root = BuildTree();
    CalculateDirectorySizes(root);

    var all = AllDirectories(root);
    var total = all
      .Where(c => c.DirSize <= 100_000 && c.IsDir)
      .Sum(c => c.DirSize);
    Console.WriteLine("Part 1: " + total);

    var neededToDelete = 30_000_000 - 70_000_000 - root.DirSize;
    var best = all.OrderBy(d => d.DirSize).First(d => d.DirSize >= neededToDelete);
    Console.WriteLine("Part 2: " + best.DirSize);
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
      if (int.TryParse(line.Split(" ").First(), out var fileSize))
      {
        var fileName = line.Split(" ")[1];
        var alreadyHasFile = current.Children.Any(c => c.Name == fileName && !c.IsDir);
        if (alreadyHasFile) continue;

        current.Children.Add(new Node { Name = fileName, FileSize = fileSize, Parent = current });
      }
    }

    return root;
  }

  private static IEnumerable<Node> AllDirectories(Node root)
  {
    if (!root.IsDir) return Array.Empty<Node>();
    var all = new List<Node> { root };

    var childrenDirectories = root.Children.Where(c => c.IsDir);

    foreach (var childDir in childrenDirectories)
    {
      all.Add(childDir);
      all.AddRange(AllDirectories(childDir));
    }

    return all.Distinct();
  }

  private static void CalculateDirectorySizes(Node root)
  {
    if (!root.IsDir) return;

    foreach (var child in root.Children)
    {
      CalculateDirectorySizes(child);
    }

    var childrenFileSizes = root.Children.Where(c => c.IsFile).Select(c => c.FileSize).Sum();
    var childrenDirSizes = root.Children.Where(c => c.IsDir).Select(c => c.DirSize).Sum();

    root.DirSize = childrenFileSizes + childrenDirSizes;
  }
}