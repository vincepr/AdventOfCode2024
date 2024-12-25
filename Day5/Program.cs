// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var input = File.ReadAllLines("./input");
List<(int, int)> rules = [];
List<List<int>> lists = [];
foreach (var str in input)
{
    if (str == "")
    {
        continue;
    }
    if (str.Contains("|"))
    {
        var split = str.Split("|");
        rules.Add((int.Parse(split[0]), int.Parse(split[1])));
    }
    if (str.Contains(","))
    {
        var nrs = str.Split(",").Select(nr => int.Parse(nr)).ToList();
        lists.Add(nrs);
    }
}

List<int> successMiddles = [];
foreach (var list in lists)
{
    var isTrue = true;
    foreach (var rule in rules)
    {
        var idx1 = list.FindIndex(itm => itm == rule.Item1);
        var idx2 = list.FindIndex(itm => itm == rule.Item2);
        if (idx1 != -1 && idx2 != -1)
        {
            if (idx1 > idx2){
                isTrue = false;
            }
        }
    }
    if (isTrue)
    {
        System.Console.WriteLine(string.Join(",", list));
        System.Console.WriteLine($"Added {list[list.Count / 2]}");
        successMiddles.Add(list[list.Count / 2]);
    }
}
System.Console.WriteLine($"SumMiddles: {successMiddles.Sum()}");
