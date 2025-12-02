module Day02.Part02

let solution =
    System.IO.File.ReadAllText(__SOURCE_DIRECTORY__ + "/input01.txt")
    |> _.Split(',')
    |> Seq.map _.Split('-')
    |> Seq.collect (fun s -> seq { for i in int64 s[0] .. int64 s[1] -> i.ToString() })
    |> Seq.filter (fun s ->
        seq { for l in 1 .. s.Length/2 -> Seq.chunkBySize l s }
        |> Seq.map (Seq.distinct >> Seq.length)
        |> Seq.exists ((=) 1) 
    )
    |> Seq.fold (fun acc s -> acc + int64 s) 0L