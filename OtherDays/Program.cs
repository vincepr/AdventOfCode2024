
namespace OtherDays;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Day7.Run();
    }
}

public static class Day7
{
    public static void Run()
    {
        List<(long Result, List<long> Nrs)> data = [];
        var input = File.ReadAllLines("input7");
        foreach(var line in input){
            var split = line.Split(":");
            var nrs = split[1].Split(" ").Where(s => s != string.Empty).Select(s => long.Parse(s)).ToList();
            data.Add((Result: long.Parse(split[0]), Nrs: nrs));
        }
        long sum = 0;
        foreach(var entry in data){
            bool isValid = IsValidEntry(entry.Result, entry.Nrs);
            if(isValid){
                sum += entry.Result;
                System.Console.WriteLine($"Valid /{entry.Result}/: {string.Join(" ", entry.Nrs)}");
            } else {
                System.Console.WriteLine($"NOT valid /{entry.Result}/: {string.Join(" ", entry.Nrs)}");
            }
        }
        System.Console.WriteLine(sum);
    }

    private static bool IsValidEntry(long Result, List<long> Nrs)
    {
        if(Nrs.Count <= 1){
            return Result == Nrs.First();
        }
        // addition first 2 elements
        var first = Nrs[0];
        var second = Nrs[1];
        if (IsValidEntry(Result, [first + second, ..Nrs.Skip(2)])){
            return true;
        }
        if (IsValidEntry(Result, [first * second, ..Nrs.Skip(2)])){
            return true;
        }
        return false;
    }
}