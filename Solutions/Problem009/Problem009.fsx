seq {for a in {1..1000} do for b in {a..1000} do for c in {b..1000} do yield (a, b, c)}
|> Seq.filter (fun (a, b, c) -> a*a + b*b = c*c)
|> Seq.filter (fun (a, b, c) -> a + b + c = 1000)
|> Seq.head
|> (fun (a, b, c) -> a * b * c)
