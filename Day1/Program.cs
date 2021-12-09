// Part 1
int[] input = Array.ConvertAll(File.ReadAllLines("./input.txt"), int.Parse);

// This is just for fun, it's bad though so don't actually use linq for this.
int result = input.Skip(1).Zip(input, (x, y) => x > y ? 1 : 0).Sum();

Console.WriteLine(result);


// Part 2
static int CalculateIncreasingWindowCount (int[] input, int windowSize)
{
    int currentSum = 0;
    int count = 0;

    for (int i = 0; i < windowSize; i++)
    {
        currentSum += input[i];
    }

    int windowSum = currentSum;
    for (int i = windowSize; i < input.Length; i++)
    {
        windowSum += input[i] - input[i - windowSize];
        if (windowSum > currentSum)
        {
            count++;
        }
        currentSum = windowSum;
    }
    return count;
}

Console.WriteLine(CalculateIncreasingWindowCount(input, 3));