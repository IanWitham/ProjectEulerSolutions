let multipleOf x y = y % x = 0

let result =
    seq {1..999}
    |> Seq.filter (fun x -> multipleOf 3 x || multipleOf 5 x)
    |> Seq.sum

printfn "%d" result

