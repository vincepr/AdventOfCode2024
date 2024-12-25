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
List<int> recoveredMiddles = [];
foreach (var list in lists)
{
    bool isTrue = IsAllRulesCorrect(rules, list);
    if (isTrue)
    {
        // success
        System.Console.WriteLine(string.Join(",", list));
        System.Console.WriteLine($"Added {list[list.Count / 2]}");
        successMiddles.Add(list[list.Count / 2]);
    }
    else
    {
        // part 2 recovery
        System.Console.WriteLine("Before swap: " + string.Join(",", list));
        SwapTillRight(list, rules);
        System.Console.WriteLine("After swap : " + string.Join(",", list));
        System.Console.WriteLine($"Added recovered: {list[list.Count / 2]}");
        recoveredMiddles.Add(list[list.Count / 2]);
    }
}

System.Console.WriteLine($"SumMiddles: {successMiddles.Sum()}");
System.Console.WriteLine($"SumRecoveredMiddles: {recoveredMiddles.Sum()}");

static bool IsAllRulesCorrect(List<(int, int)> rules, List<int> list)
{
    var isTrue = true;
    foreach (var rule in rules)
    {
        var idx1 = list.FindIndex(itm => itm == rule.Item1);
        var idx2 = list.FindIndex(itm => itm == rule.Item2);
        if (idx1 != -1 && idx2 != -1)
        {
            if (idx1 > idx2)
            {
                isTrue = false;
            }
        }
    }

    return isTrue;
}

void SwapTillRight(List<int> list, List<(int, int)> rules)
{
    if (IsAllRulesCorrect(rules, list))
    {
        return;
    }
    SwapFirstWrongElements(rules, list);
    SwapTillRight(list, rules);
}

void SwapFirstWrongElements(List<(int, int)> rules, List<int> list)
{
    foreach (var rule in rules)
    {
        var idx1 = list.FindIndex(itm => itm == rule.Item1);
        var idx2 = list.FindIndex(itm => itm == rule.Item2);
        if (idx1 != -1 && idx2 != -1)
        {
            if (idx1 > idx2)
            {
                (list[idx1], list[idx2]) = (list[idx2], list[idx1]);
            }
        }
    }
}