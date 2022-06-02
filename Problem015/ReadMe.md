<p>Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.</p>
<div class="center">
<img src="https://projecteuler.net/project/images/p015.png" class="dark_img" alt="" /></div>
<p>How many such routes are there through a 20×20 grid?</p>

My Notes
---

The trick here is that for each route from the start to a "half-way" point in the grid,
(i.e. those points along the SW to NE diagonal, given a square grid) there are an equal number of routes
from that half-way point to the exit.

The number of full routes passing through each half-way point is therefore the number of routes
from the start point to that half-way point, squared.

Pascal's triangle (i.e. combinatorics) can be used to calculate the number of routes to each half-way point.

The full number of routes is the sum of all routes passing through each half-way point.

