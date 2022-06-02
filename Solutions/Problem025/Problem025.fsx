let fibs = Seq.unfold (fun (a, b) -> Some(a, (b, a + b))) (1I, 1I)

let lowestNumberWith1000Digits = 10I ** 999

fibs
|> Seq.findIndex (fun x -> x >= lowestNumberWith1000Digits)
|> (+) 1
|> printfn "%d"
