﻿module FizzBuzz

let fizzbuzz =
    for i = 1 to 100 do
        if i % 15 = 0 then
            printfn "FizzBuzz"
        else if i % 5 = 0 then
            printfn "Buzz"
        else if i % 3 = 0 then
            printfn "Fizz"
        else
            printfn "%i" i
          