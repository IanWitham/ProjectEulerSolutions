pown 2I 1000
|> string
|> Seq.sumBy (string >> int)
|> printfn "%d"
