from itertools import takewhile
from typing import Iterator


def fibs() -> Iterator[(int, int)]:
    (x, y) = (1, 2)
    while(True):
        yield x
        (x, y) = (y, x+y)


even_fibs: Iterator[int] = filter(lambda x: x % 2 == 0, fibs())
print(
    sum(takewhile(lambda x: x < 4000000, even_fibs))
)
