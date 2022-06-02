open System.Collections.Generic

let tee f x =
    f x
    x

let tap f xs = xs |> Seq.map (tee f)

let triangleNumbers () =
    Seq.unfold (fun (i: int, t: int) -> Some(t + i, (i + 1, t + i))) (1, 0)

// let triangleNumber n = n * (n + 1L) / 2L

// note, memoisation is necessary for this problem to be solved quickly.
let primeFactorMemo = new Dictionary<int, int list>()

let primeFactors x =
    let rec primeFactorsInner p n ps =
        if primeFactorMemo.ContainsKey(n) then
            primeFactorMemo.[n] @ ps
        else
            let nextP = { p..n } |> Seq.find (fun y -> (n % y = 0))

            match nextP with
            | np when np >= n -> np :: ps
            | np -> primeFactorsInner nextP (n / nextP) (np :: ps)

    let result = primeFactorsInner 2 x []
    primeFactorMemo.Add(x, result)
    result

let numberOfDivisors x =
    x
    |> primeFactors
    |> Seq.countBy id
    |> Seq.map (snd >> (+) 1)
    |> Seq.fold (*) 1
// |> tee (printfn "num divisors in %d: %d" x)

triangleNumbers ()
|> Seq.skip 1
// |> tap (printfn "%d")
|> Seq.find (fun x -> numberOfDivisors x > 500)
|> printfn "%d"
