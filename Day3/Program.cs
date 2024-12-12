string[] input = File.ReadAllLines("./input.txt");

// Part 1
decimal CalculateGammaRate(string[]input)
{
    int itemLength = input.First().Length;
    int inputLength = input.Length;
    IEnumerable<int> gammaRate = input.SelectMany(x => x)
        .Select((x, i) => new { Value = x, Index = i % itemLength })
        .GroupBy(x => x.Index)
        .Select(g => g
            .Sum(z => char.GetNumericValue(z.Value)) < inputLength / 2 ? 0 : 1);

    return Convert.ToInt32(string.Join("", gammaRate), 2);
}

decimal gammaRate = CalculateGammaRate(input);
uint epsilonRate = (uint)gammaRate ^ 0xFFF;
Console.WriteLine(gammaRate * epsilonRate);