let fibs = Seq.unfold (fun (a, b) -> Some(b, (b, a + b))) (1, 1)
let isEven x = x % 2 = 0
let lessThan x = (>=) x

fibs
|> Seq.takeWhile (lessThan 4_000_000)
|> Seq.filter isEven
|> Seq.sum
|> printfn "result: %d"
