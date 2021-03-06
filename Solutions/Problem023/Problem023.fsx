// note, memoisation is necessary for this problem to be solved quickly.
let primeFactorMemo = new System.Collections.Generic.Dictionary<int, int list>()

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
    primeFactorMemo.TryAdd(x, result) |> ignore
    result

let allDivisors n : int seq =
    let rec allDivisorsInner (x: (int * int) list) =
        seq {
            match x with
            | [] -> yield 1
            | (p, c) :: t ->
                for n in { 0..c } do
                    yield!
                        allDivisorsInner t
                        |> Seq.map (fun y -> y * (pown p n))
        }

    n
    |> primeFactors
    |> List.countBy id
    |> allDivisorsInner

let sumOfAllDivisors n = n |> allDivisors |> Seq.sum

let sumOfAllProperDivisors n =
    if n < 2 then
        0
    else
        (sumOfAllDivisors n) - n

type Category =
    | Deficient
    | Perfect
    | Abundant

let Categorize x =
    match sumOfAllProperDivisors x with
    | s when s < x -> Deficient
    | s when s > x -> Abundant
    | _ -> Perfect

let AbundantNumbers =
    [ 1..28123 ]
    |> List.filter (Categorize >> (=) Abundant)

let AbundantNumberSet = AbundantNumbers |> set

let IsTheSumOfTwoAbundantNumbers n =
    AbundantNumbers
    |> List.exists (fun x -> AbundantNumberSet.Contains(n - x))

{ 1..28123 }
|> Seq.filter (IsTheSumOfTwoAbundantNumbers >> not)
|> Seq.sum
|> printfn "%d"
