{ 1I .. 100I }
|> Seq.reduce (*)
|> string
|> Seq.sumBy (string >> int)
|> printfn "%d"
// note... Seq.sumBy implicitly converts the input string to a char[].
// It is important to convert these chars back to strings before converting
// them to ints, otherwise it gives the ascii values of the chars, rather than a parsed int.
