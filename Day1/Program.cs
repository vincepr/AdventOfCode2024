Console.WriteLine("starting");
var tuples = File.ReadAllLines("./input1.csv").Select(txt =>
{
    var x = txt.Split("  ");
    if (x.Length != 2) throw new FormatException();
    return (int.Parse(x.First()), int.Parse(x.Last()));
}).ToList();

using var leftOrd = tuples.Select(t => t.Item1).Order().GetEnumerator();
using var rightOrd = tuples.Select(t => t.Item2).Order().GetEnumerator();
List<int> distances = [];
var similarityScore = 0;

for (var i = 0; i < tuples.Count; i++)
{
    leftOrd.MoveNext();
    var left = leftOrd.Current;
    rightOrd.MoveNext();
    var right = rightOrd.Current;
    distances.Add(left > right ? left - right : right - left);

    similarityScore += left * tuples.Select(t => t.Item2).Count(r => r == left);
}

var sumDistances = distances.Sum();
Console.WriteLine($"sum distances is {sumDistances}");
Console.WriteLine($"similarity score is {similarityScore}");

