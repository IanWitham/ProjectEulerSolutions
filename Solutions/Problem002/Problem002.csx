#r "System"

IEnumerable<int> fibs()
{
    int i = 0;
    int j = 1;
    while (true)
    {
        (i, j) = (j, i + j);
        yield return i;
    }
}

Console.WriteLine(
    fibs()
    .TakeWhile(x => x < 4000000)
    .Where(x => x % 2 == 0)
    .Sum()
);
