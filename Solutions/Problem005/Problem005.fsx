let primeFactors x =
    Seq.unfold (fun (f, n) ->
        seq {2..x}
        |> Seq.tryFind (fun y -> (n % y) = 0)
        |> Option.map (fun y -> (y, (y, n / y))))
        (2, x)

// F# 6 will have a getKeys method built-in.
let getKeys (m : Map<'k, 'v>) =
    m |> Map.toSeq |> Seq.map fst

let mergeMapsBy f a b  =
    (Seq.append (a |> getKeys) (b |> getKeys))
    |> Seq.distinct
    |> Seq.choose (fun x ->
        match (Map.tryFind x a, Map.tryFind x b) with
        | Some(u), None -> Some (x, u) 
        | None, Some(v) -> Some (x, v) 
        | Some(u), Some(v) -> Some (x,  f u v) 
        | _ -> None)
    |> Map.ofSeq

let primeCounts x =
    x
    |> primeFactors
    |> Seq.countBy id
    |> Map.ofSeq

{2..20}
|> Seq.map primeCounts 
|> Seq.reduce (mergeMapsBy max)
|> Map.toSeq
|> Seq.map (fun (x, y) -> ((float x) ** (float y)))
|> Seq.reduce (*)
|> int

