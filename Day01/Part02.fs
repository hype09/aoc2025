module Day01.Part02

let inline modE a b = ((a % b) + b) % b

let solution =
    System.IO.File.ReadLines(__SOURCE_DIRECTORY__ + "/input01.txt")
    |> Seq.map (fun line -> (if line[0] = 'L' then -1 else 1) * int line[1..])
    |> Seq.fold (fun (res, acc) v ->
        let f x = floor (float x / 100.0)
        let c = (if v > 0 then f (acc + v) else f (acc + v - 1) - f (acc - 1)) |> abs |> int
        res + c, modE (acc + v) 100
    ) (0, 50)
    |> fst