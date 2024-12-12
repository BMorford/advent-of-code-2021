using System.Text.RegularExpressions;

string[] input = File.ReadAllLines("./input.txt");
var matches = input
    .Select(s => Regex.Match(s, @"(?<direction>[^\s]+) (?<value>.*)"))
    .Select(s => new
    {
        Direction = s.Groups["direction"].Value,
        Value = int.Parse(s.Groups["value"].Value)
    });

// Part 1
(int, int) result = matches.Aggregate((0, 0), (acc, match) =>
     match.Direction switch
     {
         "forward" => (acc.Item1 + match.Value, acc.Item2),
         "down" => (acc.Item1, acc.Item2 + match.Value),
         "up" => (acc.Item1, acc.Item2 - match.Value),
         _ => throw new InvalidDataException()
     }
 );
Console.WriteLine(result.Item1 * result.Item2);

// Part 2
(int, int, int) aimResult = matches.Aggregate((0, 0, 0), (acc, match) =>
     match.Direction switch
     {
         "forward" =>
             (acc.Item1 + match.Value,
             acc.Item2 + (acc.Item3 * match.Value),
             acc.Item3),
         "down" =>
            (acc.Item1,
            acc.Item2,
            acc.Item3 + match.Value),
         "up" =>
            (acc.Item1,
            acc.Item2,
            acc.Item3 - match.Value),
         _ => throw new InvalidDataException()
     }
 );
Console.WriteLine(aimResult.Item1 * aimResult.Item2);