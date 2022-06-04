#r "System"

long[] arr = Enumerable.Range(0, 2_000_000).Select(x => (long)x).ToArray();

for (int i = 2; i < 2_000_000; i++)
{
    if (arr[i] == 0) continue;
    for (int j = 2 * i; j < 2_000_000; j += i)
    {
        arr[j] = 0;
    }
}

Console.WriteLine(
    arr.Skip(2)
        .Sum()
);
