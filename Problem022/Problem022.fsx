open System.IO

let fileContent() =
    use reader = new StreamReader("names.txt")
    reader.ReadToEnd()

let alphabetValue c =
    (int c) - (int 'A') + 1

let alphabetScore s =
    s |> Seq.sumBy alphabetValue

fileContent()
|> (fun x -> x.Split(","))
|> Seq.map (fun x -> x.Trim('"'))
|> Seq.sort
|> Seq.mapi (fun i s -> (i + 1) * (alphabetScore s))
|> Seq.sum


