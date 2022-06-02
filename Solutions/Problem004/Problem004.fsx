let products =
    seq {
        for x in { 100..999 } do
            for y in { 100..999 } do
                yield x * y
    }

let isPalindrome n =
    let a = n |> string |> Array.ofSeq
    a = Array.rev a

products
|> Seq.distinct
|> Seq.sortDescending
|> Seq.filter isPalindrome
|> Seq.head
|> printfn "%d"
