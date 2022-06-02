let tee f x =
    f x
    x

let tap f xs = Seq.map (tee f) xs

let memo = System.Collections.Generic.Dictionary<int64, int>()

let collatzLength (n: int64) =
    let rec collatzLengthInner (length: int) (n: int64) =
        match (memo.ContainsKey(n), n, n % 2L) with
        | true, _, _ -> length + memo.[n]
        | _, 1L, _ -> length + 1
        | _, _, 0L -> collatzLengthInner (length + 1) (n / 2L)
        | _, _, _ -> collatzLengthInner (length + 1) (3L * n + 1L)

    memo.Add(n, collatzLengthInner 0 n)
    memo.[n]

{ 1..999_999 }
|> Seq.map (int64)
|> Seq.maxBy collatzLength
