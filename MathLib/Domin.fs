// Дополнительные сведения о F# см. на http://fsharp.net
namespace MathLib
open System.Collections.Generic

module public Domin = 
    let rec fib n =
        match n with
        | 1 | 2 -> 1
        | n -> fib(n-1) + fib(n-2)
    

    let ret (input:double [][])=
        let  mutable arr = input
        let rows = arr.GetUpperBound(0) + 1
        let firstDominated coll = Array.forall2 (fun elem1 elem2 -> elem1 <= elem2) coll
        //for i in 0 .. rows
        let dominated = new List<int>()
        for i in 0..rows-1 do
            let other = Array.concat [arr.[0..i-1].[*]; arr.[i+1..].[*]]
            let mutable is_dominated = false
            for new_row in other do
                if firstDominated arr.[i].[*] new_row then
                    is_dominated <- true 
                    //TODO: make MF break!
            if is_dominated then
                //arr <- other 
                dominated.Add(i)    
        dominated      
            //printf "%A" other
            //row i arr
        
        //firstDominated arr.[0] arr.[1]
