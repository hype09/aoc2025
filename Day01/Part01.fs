module Day01.Part01

let solution =
    System.IO.File.ReadLines(__SOURCE_DIRECTORY__ + "/input01.txt")
    |> Seq.map (fun line -> (if line[0] = 'L' then -1 else 1) * int line[1..])
    |> Seq.scan (fun acc v -> (acc + v) % 100) 50
    |> Seq.filter ((=) 0)
    |> Seq.length
