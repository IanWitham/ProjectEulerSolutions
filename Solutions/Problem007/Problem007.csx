#r "System"

IEnumerable<int> primes()
{
    List<int> foundPrimes = new List<int> { 2 };
    int i = 3;
    yield return 2;
    while (true)
    {
        if (!foundPrimes.Any(x => i % x == 0))
        {
            foundPrimes.Add(i);
            yield return i;
        }
        i++;
    }
}

Console.WriteLine(
    primes().Skip(10_000).First()
);