let primeFactors x =
    Seq.unfold
        (fun (f, n) ->
            seq { 2L .. n }
            |> Seq.tryFind (fun y -> n % y = 0L)
            |> Option.map (fun y -> (y, (y, n / y))))
        (2L, x)

let largestPrimeFactor x = primeFactors x |> Seq.tryLast

largestPrimeFactor 600851475143L |> printfn "%A"
