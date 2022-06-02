// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.

let square x = (x |> float) ** 2.0 |> int

let sumOfSquares xs = xs |> Seq.sumBy square

let squareOfSum xs = xs |> Seq.sum |> square

(squareOfSum { 1L .. 100L })
- (sumOfSquares { 1L .. 100L })
|> printfn "%d"
