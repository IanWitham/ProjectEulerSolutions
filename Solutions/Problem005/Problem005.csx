#r "System"

IEnumerable<int> PrimeFactors(int n)
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

Dictionary<K, V> MergeDictsBy<K, V>(Dictionary<K, V> dictA, Dictionary<K, V> dictB, Func<V, V, V> merger)
{

    var result = new Dictionary<K, V>(dictA);
    foreach (K key in dictB.Keys)
    {
        if (result.ContainsKey(key))
        {
            result[key] = merger(result[key], dictB[key]);
        }
        else
        {
            result[key] = dictB[key];
        }
    }
    return result;
}

// get the prime factors of the numbers 2--20
var primeFactors = Enumerable.Range(2, 19).Select(PrimeFactors);

// count the distinct prime factors for these numbers
var primeFactorCounts = primeFactors
    .Select(p =>
        p.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count())
    );

// get the most times each prime factor appears in the numbers 2 -- 20l
var factors = primeFactorCounts.Aggregate(new Dictionary<int, int>(), (acc, elem) => MergeDictsBy(acc, elem, Math.Max));

var result = 1;
foreach (var kvp in factors)
{
    result *= (int)Math.Pow(kvp.Key, kvp.Value);
}

Console.WriteLine(
    result
);
