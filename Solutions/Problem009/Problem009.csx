#r "System"

int findResult()
{
    for (int a = 1; a <= 332; a++)
    {
        for (int b = a + 1; b < 1000 - (a + b); b++)
        {
            int c = 1000 - (a + b);
            Console.WriteLine("a:{0}, b:{1}, c:{2}", a, b, c);
            if (IsPythagorean(a, b, c))
            {
                return a * b * c;
            }
        }
    }
    return -1;
}

bool IsPythagorean(int a, int b, int c)
{
    return a * a + b * b == c * c;
}

Console.WriteLine(
    findResult()
);


