type Date = { Year: int; Month: int; DayNo: int }

let daysInMonth year month =
    match (year, month) with
    | y, 1 when (y % 4 = 0) && (y % 100 <> 0 || y % 400 = 0) -> 29
    | _, 1 -> 28
    | _, 3
    | _, 5
    | _, 8
    | _, 10 -> 30
    | _ -> 31

let firstOfNextMonth { Year = y; Month = m; DayNo = dn } =
    let nextMonth = (m + 1) % 12
    let nextYear = if nextMonth = 0 then y + 1 else y
    let nextDayNo = dn + daysInMonth y m

    { Year = nextYear
      Month = nextMonth
      DayNo = nextDayNo }

let isSunday d = d.DayNo % 7 = 0

let beforeYear y d = d.Year < y

let generator d = Some(d, firstOfNextMonth d)

Seq.unfold generator { Year = 1900; Month = 0; DayNo = 1 }
|> Seq.skipWhile (beforeYear 1901)
|> Seq.takeWhile (beforeYear 2001)
|> Seq.filter isSunday
|> Seq.length
|> printfn "%d"
