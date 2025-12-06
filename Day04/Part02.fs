module Day04.Part02

let dirs = [ (-1, -1); (0, -1); (1, -1); (-1, 1); (0, 1); (1, 1); (-1, 0); (1, 0) ]
let elem m i j = Array.tryItem j (Array.tryItem i m |> Option.defaultValue [||]) |> Option.defaultValue '.' 
let vals m i j = seq { for x, y in dirs -> elem m (i+x) (j+y) } |> Seq.filter ((=) '@') |> Seq.length 

let count (m: bool array array) =
    seq {
        for i in 0 .. m.Length - 1 do
            for j in 0 .. m[i].Length - 1 do
                yield m[i][j]
    }
    |> Seq.filter ((=) true)
    |> Seq.length
    
let removeRolls (m: char array array) (m': (int * int) seq) =
    Seq.fold (fun (v: char array array) (x: int, y: int) ->
        Array.set v[x] y '.'
        v
    ) m m'

let rec reduce (acc: int) (m: char array array) =
    let m' = seq {
                for i in 0 .. m.Length - 1 do
                    for j in 0 .. m[i].Length - 1 do
                        yield m[i][j] = '@' && (vals m i j) < 4, (i, j)
             }
             |> Seq.filter fst
             |> Seq.map snd
             |> Seq.toList
    if m'.Length = 0 then acc else reduce (acc + m'.Length) (removeRolls m m')

let solution =
    System.IO.File.ReadAllLines(__SOURCE_DIRECTORY__ + "/input.txt")
    |> Array.map (Seq.toArray)
    |> reduce 0
    