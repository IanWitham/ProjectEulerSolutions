#r "System"

IEnumerable<long> PrimeFactors(long n)
{
    int i = 2;
    while (i <= n)
    {
        if (n % i == 0)
        {
            n /= i;
            yield return i;
        }
        else
        {
            i++;
        }
    }
}

long LargestPrimeFactor(long n)
{
    return PrimeFactors(n).Last();
}

Console.WriteLine(
    LargestPrimeFactor(600851475143)
);
