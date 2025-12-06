module Day06.Part01

open System
open System.Linq

let operations =
    System.IO.File.ReadLines(__SOURCE_DIRECTORY__ + "/input01.txt").Last()
    |> _.Split([| ' ' |], StringSplitOptions.TrimEntries ||| StringSplitOptions.RemoveEmptyEntries)
    |> Seq.map (fun o -> if o = "+" then (+) else (*))
    |> Seq.toArray

let problems =
    System.IO.File.ReadAllLines(__SOURCE_DIRECTORY__ + "/input01.txt").Take(4) 
    |> Seq.map (_.Split([| ' ' |], StringSplitOptions.TrimEntries ||| StringSplitOptions.RemoveEmptyEntries) >> Array.map int64)
    |> Seq.toArray
    |> (fun ps -> seq { for x in 0 .. ps[0].Length - 1 do seq { for y in 0 .. ps.Length - 1 -> ps[y][x] } })

let solution =
    problems
    |> Seq.mapi (fun i ps ->
        printfn $"ps: %A{ps}, op: %A{operations[i]}"
        Seq.reduce operations[i] ps
    )
    |> Seq.fold (+) 0L