module GameofLife

open System
open Utility



let universeSize = 50
let universe = 
    List.init (universeSize * universeSize) (fun i -> if i % universeSize = 4 || i % universeSize = 3 then 1 else 0 ) 

let generate size grid =
    grid |> List.mapi (fun i value->
       
        let count =
            let s = size
            [-1-s;-s;1-s;
             -1;     1;
             -1+s;s; 1+s]
            |> Seq.sumBy (fun o ->
                let offset = abs((i + o) % grid.Length)
                grid.[offset]
            )
        
        match value, count with 
        | _, 3 -> 1
        | n, 2 -> n
        | _, _ -> 0 
    )

   
let show (size:int) (grid:int list) =
    let color (num:int) = 
        match num with
        |1 -> cwrite System.ConsoleColor.Green (num.ToString())
        |a -> Console.Write(num)
    let colorn nums =
      List.iter (fun c -> color c) nums
      System.Console.WriteLine("")

    for y=0 to (grid.Length/size)-1 do
       [0..size-1] 
       |> List.map (fun x -> grid.[y * size + x])
       |> colorn
      

    
let rec lifecycle grid period =
    let work =
        let nextGen = generate universeSize grid
        Console.Clear()
        show universeSize nextGen
        Console.WriteLine()
        //Console.ReadLine()
        System.Threading.Thread.Sleep(100);
        nextGen

    match period with
        | 150 -> Console.WriteLine("done")
        | n ->  lifecycle work (period+1)
    


let live = lifecycle universe 0