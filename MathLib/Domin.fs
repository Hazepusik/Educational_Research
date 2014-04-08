// Дополнительные сведения о F# см. на http://fsharp.net
namespace MathLib
open System.Collections.Generic

module public Domin = 
    let rec fib n =
        match n with
        | 1 | 2 -> 1
        | n -> fib(n-1) + fib(n-2)
    

    let CalcDominated (input:double[][])=
        let mutable arr = input
        let rows = arr.GetUpperBound(0) + 1
        let first_dominated_or_equal coll = Array.forall2 (fun elem1 elem2 -> elem1 <= elem2) coll
        let rec is_dominated (checkable:double[]) (other:double[][]) =
            if other.Length = 0 then -1
            elif checkable = other.[0].[*] then max (is_dominated checkable other.[1..].[*]) 0
            elif first_dominated_or_equal checkable other.[0].[*] then 1
            else is_dominated checkable other.[1..].[*]

        let dominated = new List<int>()
        let equal  = new List<int>()
        for i = rows-1 downto 0 do     // for for dominated numbers
            //printfn "%A" arr.Length    // downto for deleting in cicle
            let other = Array.concat [arr.[0..i-1].[*]; arr.[i+1..].[*]]
            match (is_dominated arr.[i].[*] other) with
            | 1 -> dominated.Add(i+1); arr <- Array.concat [arr.[0..i-1].[*]; arr.[i+1..].[*]]
            | 0 -> equal.Add(i+1); arr <- Array.concat [arr.[0..i-1].[*]; arr.[i+1..].[*]]  //TODO: equal list
            | _ -> printfn "Pareto"
        printfn "%A" arr    
        [| dominated; equal |]      
