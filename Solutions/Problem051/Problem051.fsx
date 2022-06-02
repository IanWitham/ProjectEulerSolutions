let chars = "0123456789*" |> seq |> Seq.toArray
let ints = "0123456789" |> seq |> Seq.toArray
let validOnesPlaces = "1379" |> seq |> Seq.toArray
let lastChar (s : string) = s.[s.Length - 1]
let stringHasValidOnesPlace (s : string) = Array.contains  (lastChar s) validOnesPlaces
let stringStartsWithNonZero (s : string) = s.[0] <> '0'

type ProbabilisticResult =
    | IsComposite
    | IsProbablyPrime

let rng = System.Random()

let memoized (f : 'a -> 'b) : ('a -> 'b) =
    let dict = System.Collections.Generic.Dictionary<'a, 'b>()
    let mf (a : 'a) : 'b = 
        if not (dict.ContainsKey(a)) then
            dict.Add(a, f a)
        dict.[a]
    mf

let probabilisticPrimeTest n =
    {1..5}
    |> Seq.forall (fun x -> pown (rng.Next(1, n-2) |> bigint) (n-1) % (n |> bigint) = 1I )
    |> (fun b -> if b then IsProbablyPrime else IsComposite)

let intToPattern n =
    n |> Seq.unfold (fun n -> if n = 0 then None else Some((chars.[n % 11], n / 11)))
    |> Seq.toArray
    |> Array.rev
    |> System.String

let patterns primeTest =
    Seq.initInfinite id
    |> Seq.skip 10
    //|> Seq.filter (primeTest >> (=) IsProbablyPrime) 
    |> Seq.map intToPattern
    |> Seq.filter (fun x -> x.Contains('*'))
    |> Seq.filter stringHasValidOnesPlace

let resolvePattern (s : string) =
    ints
    |> Array.map (fun c -> s.Replace('*', c) )
    |> Array.filter stringHasValidOnesPlace
    |> Array.filter stringStartsWithNonZero

//patterns |> Seq.filter stringHasValidOnesPlace |> Seq.take 200 |>  Seq.toList

let memoizedProbabilisticPrimeTest = memoized probabilisticPrimeTest

patterns memoizedProbabilisticPrimeTest
|> Seq.filter (resolvePattern >> Array.map int >> Seq.map (fun p -> (memoizedProbabilisticPrimeTest p = IsComposite) >> (fun x -> Seq.length ( (Seq.truncate 5) ) >= 5)))
|> Seq.head



// resolvePattern "12*34"

// [1I..15I] |> List.map (fun n -> pown n 10 % 11I)


    
