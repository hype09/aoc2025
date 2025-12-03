module Day03.Part01

let solution =
    System.IO.File.ReadAllLines(__SOURCE_DIRECTORY__ + "/input01.txt")
    |> Seq.map (Seq.toArray >> Array.map (_.ToString() >> int))
    |> Seq.map (Seq.fold (fun (l, r) v -> if l >= r then (l, max r v) else (r, v)) (0, 0))
    |> Seq.map (fun (l, r) -> int (l.ToString() + r.ToString()))
    |> Seq.sum
