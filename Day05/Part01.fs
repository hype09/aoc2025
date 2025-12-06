module Day05.Part01

let inline (>=<) a (b, c) = a >= b && a <= c   

let solution =
    System.IO.File.ReadAllLines(__SOURCE_DIRECTORY__ + "/input01.txt")
    |> Seq.fold
        (fun (rs, ids) l ->
            if l = "" then rs, ids
            elif String.exists ((=) '-') l then (l.Split [| '-' |] |> (fun l' -> int64 l'[0], int64 l'[1])) :: rs, ids
            else rs, int64 l :: ids)
        ([], [])
    |> (fun (rs, ids) -> Seq.fold (fun acc id -> if (Seq.exists ((>=<) id) rs) then acc + 1 else acc) 0 ids)
