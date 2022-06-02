let rec swap x y lst =
    lst |> List.mapi (fun i v ->
        match () with
        | () when i = x -> lst.[y]
        | () when i = y -> lst.[x]
        | () -> v
    )


let permutationFunc k l i =
    match () with
    | () when i < k -> i
    | () when i = l -> k
    | () when i = k -> k + 10 - l
    | _ -> k + 10 - i

let nextLexOrdering xs =
    let k = xs |> List.pairwise |> List.findIndexBack (fun (x, y) -> x < y)
    let l = xs |> List.findIndexBack (fun x -> x > xs.Item(k))
    let p = permutationFunc k l
    xs |> List.permute p
    

let lexOrderings =
    Seq.unfold (fun xs -> Some(xs, nextLexOrdering xs)) [0..9]

lexOrderings
|> Seq.item 999_999
|> List.map string
|> String.concat ""


