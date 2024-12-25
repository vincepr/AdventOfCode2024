List<List<char>> test = [
    ['A', 'B', 'C', 'D'],
    ['1', '2', '3', '4'],
    ['E', 'F', 'G', 'H'],
    ['5', '6', '7', '8']
];
var x = GetDiagonals(test);
foreach(var z in x)
    Console.WriteLine(z);

Console.WriteLine("starting");
var lines = File.ReadAllLines("./input4.csv").ToList();
List<string> wordsToSearch = ["XMAS"];
List<int> contains = [];

foreach (var word in wordsToSearch)
{
    // search left to right
    foreach (var line in lines)
    {
        contains.AddRange(ContainsIndexes(line, word));
    }
    // search right to left
    foreach (var line in lines)
    {
        contains.AddRange(ContainsIndexes(Reverse(line), word));
    }
}
// build diagonals
// 0 // 0 1 2 3 4 5 6 7 8 9
// 1 // 0 1 2 3 4 5 6 7 8 9
// 2 // 0 1 2 3 4 5 6 7 8 9
// 3 // 0 1 2 3 4 5 6 7 8 9
// 4 // 0 1 2 3 4 5 6 7 8 9
// 5 // 0 1 2 3 4 5 6 7 8 9
// 6 // 0 1 2 3 4 5 6 7 8 9
// 7 // 0 1 2 3 4 5 6 7 8 9
// 8 // 0 1 2 3 4 5 6 7 8 9
// 9 // 0 1 2 3 4 5 6 7 8 9
// (0,0m)
// (0,1) (1,0)
// (0,2) (1,1) (2,0)
// (0,3) (1,2) (2,1) (3,0)

System.Console.WriteLine(contains.Count);

IEnumerable<int> ContainsIndexes(string line, string word)
{
    return System.Text.RegularExpressions.Regex.Matches(line, word)
        .Cast<System.Text.RegularExpressions.Match>()
        .Select(m => m.Index);
}
static string Reverse(string s)
{
    char[] charArray = s.ToCharArray();
    Array.Reverse(charArray);
    return new string(charArray);
}

static IEnumerable<string> GetDiagonals(List<List<char>> lines)
{
    for (var len = 0; len < lines.Count; len++)
    {
        string str = "";
        for (var i = 0; i <= len; i++)
        {
            str += lines[len - i][i - len + len];
        }
        if (str != string.Empty)
            yield return str;

        for (var i = 0; i <+ len; i++)
        {
            str += lines[i][len - i];
        }
        if (str != string.Empty)
            yield return str;
    }
}
