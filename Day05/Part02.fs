module Day05.Part02

let solution =
    System.IO.File.ReadAllLines(__SOURCE_DIRECTORY__ + "/input01.txt")
    |> Seq.fold
        (fun (rs, ids) l ->
            if l = "" then rs, ids
            elif String.exists ((=) '-') l then (l.Split [| '-' |] |> (fun l' -> int64 l'[0], int64 l'[1])) :: rs, ids
            else rs, int64 l :: ids)
        ([], [])
    |> fst
    |> Seq.collect (fun (lbs, ubs) -> seq { ('L', lbs); ('U', ubs) })
    |> Seq.sortBy (fun e -> snd e, fst e)
    |> (fun s ->
        Seq.iter (printfn "%A") s
        s
        )
    |> Seq.fold (
        fun ((s, sNum), n, acc) (v, vNum) ->
            printfn $"s:{s}, v: {v}: sNum: {sNum}, vNum: {vNum}, n: {n}, acc: {acc}"
            if s = 'L' && v = 'L' then (s, sNum), n + 1, acc
            elif s = 'L' && v = 'U' && n = 0 then (v, vNum), n, acc + (vNum - sNum) + 1L
            elif s = 'L' && v = 'U' && n > 0 then (s, sNum), n - 1, acc
            elif s = 'U' && v = 'V' then (v, vNum), 0, acc
            else (v, vNum), 0, acc
    ) (('U', 0), 0, 0L)