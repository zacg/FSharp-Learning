#light


module Utility

open System

/// Converts a string into a list of characters.
let explode (s:string) =
    [for c in s -> c]

/// Converts a list of characters into a string.
let implode (xs:char list) =
    let sb = System.Text.StringBuilder(xs.Length)
    xs |> List.iter (sb.Append >> ignore)
    sb.ToString()

/// Colored printf
let cprintf c (fmt:string) = 

    Printf.kprintf 
        (fun s -> 
            let old = System.Console.ForegroundColor 
            try 
              Console.ForegroundColor <- c;
              Console.Write s
            finally
              Console.ForegroundColor <- old) 
        "%s"
        fmt 
        
// Colored printfn
let cprintfn c fmt = 
    cprintf c fmt
    printfn ""
//()

let cwrite color (txt:string) = 
    let oldColor = System.Console.ForegroundColor
    System.Console.ForegroundColor <- color
    System.Console.Write(txt)
    System.Console.ForegroundColor <- oldColor

let cwriteln color (txt:string) =
    cwrite color txt
    System.Console.WriteLine("")

let pause =
    Console.WriteLine "Press any key to continue..."
    Console.ReadLine() //|> ignore

//let blue (txt:string) = cprintfn System.ConsoleColor.Blue txt

