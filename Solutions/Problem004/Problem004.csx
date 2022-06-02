#r "System"

IEnumerable<int> ThreeDigitNumbers() => Enumerable.Range(100, 900);

IEnumerable<int> Products =>
    ThreeDigitNumbers().SelectMany(i =>
        ThreeDigitNumbers().Select(j => i * j));

bool IsPalindrome(int n) => n.ToString() == new string(n.ToString().Reverse().ToArray());

int result = Products.Where(IsPalindrome).Max();

Console.WriteLine(result);
