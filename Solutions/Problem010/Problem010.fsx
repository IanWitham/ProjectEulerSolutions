// Find the sum of all the primes below two million.

let MAX = 1_999_999

let mutable candidates = [|0..MAX|]
candidates.[1] <- 0
let mutable i = 0
while i < candidates.Length do
    match candidates.[i] with
    | 0 -> i <- i + 1
    | x -> seq {x+x..x..MAX} |> Seq.iter (fun y -> candidates.[y] <- 0); i <- i + 1

candidates |> Array.filter (fun x -> x <> 0) |> Array.sumBy int64
    
 