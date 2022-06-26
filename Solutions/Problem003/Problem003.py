#!/usr/bin/python3

import math
from typing import Iterator


def primefactors(x: int) -> Iterator[int]:
    n: int = 2
    while(n <= x):
        if (x % n == 0):
            yield n
            x /= n
        else:
            n += 1


print(max(primefactors(600851475143)))
