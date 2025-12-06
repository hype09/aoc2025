module Day06.Part02

open System
open System.Linq

let operations =
    let line = System.IO.File.ReadLines(__SOURCE_DIRECTORY__ + "/input01.txt").Last()
    line
    |> Seq.toList
    |> Seq.fold (fun (acc, i) c ->
        if c <> ' ' then ((c, i) :: acc, i + 1) else (acc, i + 1)
    ) ([], 0)
    |> (fun ls -> ('?', line.Length + 1) :: fst ls)
    |> Seq.rev
    |> Seq.pairwise
    |> Seq.map (fun ((op, s), (_, e)) -> (if op = '+' then (+) else (*)), (s, e - 2))

let problems =
    System.IO.File.ReadAllLines(__SOURCE_DIRECTORY__ + "/input01.txt").Take(4)
    |> Seq.map Seq.toArray
    |> Seq.toArray

let extractProblem (s: int) (e: int) (p: char array): int64 =
    Seq.fold (fun acc i -> acc + p[i].ToString()) "" (seq {s .. e})
    |> int64

let solution =
    Seq.map (fun (op, (s, e)) ->
        seq { for x in s..e -> seq { for y in 0..3 -> problems[y][x] } }
        |> Seq.map (fun cs -> cs |> Seq.toArray |> String |> _.Trim() |> int64)
        |> Seq.reduce op
    ) operations
    |> Seq.sum