let recurringCycleLength d =
    let t = match () with
    | () 
    Seq.initInfinite (fun i -> (1m / d) * (pown 10m (i + 1))  )
    
    

//recurringCycleLength 7m |> Seq.take 10 |> Seq.toList

let d = recurringCycleLength 7m |> Seq.take 10 |> Seq.map (fun x -> x % 10m |> int )|> Seq.toList

