module Day02.Part01

let solution =
    System.IO.File.ReadAllText(__SOURCE_DIRECTORY__ + "/input01.txt")
    |> _.Split(',')
    |> Seq.map _.Split('-')
    |> Seq.collect (fun s -> seq { for i in int64 s[0] .. int64 s[1] -> i.ToString() })
    |> Seq.filter (fun s -> s[0..(s.Length/2)-1] = s[(s.Length / 2)..])
    |> Seq.fold (fun acc s -> acc + int64 s) 0L