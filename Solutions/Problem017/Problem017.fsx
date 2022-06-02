let rec toWords i =
    match i with
    | 0 -> ""
    | 1 -> "one"
    | 2 -> "two"
    | 3 -> "three"
    | 4 -> "four"
    | 5 -> "five"
    | 6 -> "six"
    | 7 -> "seven"
    | 8 -> "eight"
    | 9 -> "nine"
    | 10 -> "ten"
    | 11 -> "eleven"
    | 12 -> "twelve"
    | 13 -> "thirteen"
    | 14 -> "fourteen"
    | 15 -> "fifteen"
    | 16 -> "sixteen"
    | 17 -> "seventeen"
    | 18 -> "eighteen"
    | 19 -> "nineteen"
    | x when x < 30 -> "twenty" + (toWords (x % 10))
    | x when x < 40 -> "thirty" + (toWords (x % 10))
    | x when x < 50 -> "forty" + (toWords (x % 10))
    | x when x < 60 -> "fifty" + (toWords (x % 10))
    | x when x < 70 -> "sixty" + (toWords (x % 10))
    | x when x < 80 -> "seventy" + (toWords (x % 10))
    | x when x < 90 -> "eighty" + (toWords (x % 10))
    | x when x < 100 -> "ninety" + (toWords (x % 10))
    | x when x < 1000 && x % 100 = 0 -> (toWords (x / 100)) + "hundred"
    | x when x < 1000 ->
        (toWords (x / 100))
        + "hundredand"
        + (toWords (x % 100))
    | _ -> "onethousand"

{ 1..1000 }
|> Seq.sumBy (toWords >> String.length)
|> printfn "%d"
