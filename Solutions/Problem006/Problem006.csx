#r "System"

int sumOfSquares(IEnumerable<int> nums) =>
    nums.Select(x => x * x).Sum();

int squareOfSum(IEnumerable<int> nums) =>
    nums.Sum() * nums.Sum();

IEnumerable<int> first100NaturalNumbers = Enumerable.Range(1, 100);

int result = squareOfSum(first100NaturalNumbers)
    - sumOfSquares(first100NaturalNumbers);

Console.WriteLine(result);
