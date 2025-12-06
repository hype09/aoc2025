module Day04.Part01

let dirs = [ (-1, -1); (0, -1); (1, -1); (-1, 1); (0, 1); (1, 1); (-1, 0); (1, 0) ]
let elem m i j = Array.tryItem j (Array.tryItem i m |> Option.defaultValue [||]) |> Option.defaultValue false 
let vals m i j = seq { for x, y in dirs -> elem m (i+x) (j+y) } |> Seq.filter ((=) true) |> Seq.length 

let solution =
    System.IO.File.ReadAllLines(__SOURCE_DIRECTORY__ + "/input.txt")
    |> Array.map (Seq.toArray >> Array.map (fun c -> c = '@'))
    |> (fun m -> seq { for i in 0 .. m.Length - 1 do
                           for j in 0 .. m[i].Length - 1 do
                               yield m[i][j] && (vals m i j) < 4
    })
    |> Seq.filter ((=) true)
    |> Seq.length