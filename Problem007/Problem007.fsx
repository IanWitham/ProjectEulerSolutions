let primes () = 
    let generator (p, ps) =
        Seq.initInfinite (fun x -> x+1)
        |> Seq.map ((+) (p+1))
        |> Seq.find (fun x -> ps |> Seq.forall (fun n -> x % n <> 0))
        |> (fun x -> (x, (x, x::ps )))
        |> Some

    Seq.unfold generator (0, [])

primes() |> Seq.skip 10_000 |> Seq.head