let pascalsTriangleRows =
    let newRowFromPrevRow xs =
        seq {
            0
            yield! xs
            0
        }
        |> Seq.windowed 2
        |> Seq.map Array.sum

    Seq.unfold (fun prevRow -> Some(newRowFromPrevRow prevRow, newRowFromPrevRow prevRow)) (seq { 1 })

let square n = n * n

pascalsTriangleRows
|> Seq.item 19 // the 20th row of Pascal's triangle
|> Seq.sumBy (int64 >> square)
