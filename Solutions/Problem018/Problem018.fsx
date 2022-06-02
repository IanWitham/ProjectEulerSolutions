let input =
    """75
95 64
17 47 82
18 35 87 10
20 04 82 47 65
19 01 23 75 03 34
88 02 77 73 07 63 67
99 65 04 28 06 16 70 92
41 41 26 56 83 40 80 70 33
41 48 72 33 47 32 37 16 94 29
53 71 44 65 25 43 91 52 97 51 14
70 11 33 28 77 73 17 78 39 68 17 57
91 71 52 38 17 14 91 43 58 50 27 29 48
63 66 04 68 89 53 67 30 73 16 69 87 40 31
04 62 98 27 23 09 70 98 73 93 38 53 60 04 23"""

let rows =
    input.Split("\n")
    |> Array.map (fun x -> x.Split(" ") |> Array.map int)

let rowReducer i j =
    let pairs = j |> Array.pairwise

    Array.zip i pairs
    |> Array.map (fun (ie, (pel, per)) -> ie + max pel per)

Array.reduceBack rowReducer rows

// The trick... work from the bottom to the top.
// For each element in row n - 1 , add to it the greater
// of the two diagonally adjacent elements in row n. Row n-1 is now
// updated to reflect a these running maximal totals.
// Now do the same for row n - 2 and the running totals in row n - 1.
// Continue doing this until you have one value left in row zero.
