namespace MathLib
open System.Collections.Generic

module public Domin =  

    let CalcDominated (input:double[][])=
        let mutable arr = input
        let rows = arr.GetUpperBound(0) + 1
        let first_is_dominated_or_equal coll = Array.forall2 (fun elem1 elem2 -> elem1 <= elem2) coll
        let rec is_dominated (checkable:double[]) (other:double[][]) =
            if other.Length = 0 then -1 // not dominated
            elif checkable = other.[0].[*] then max (is_dominated checkable other.[1..].[*]) 0 // equal or dominated
            elif first_is_dominated_or_equal checkable other.[0].[*] then 1 // dominated
            else is_dominated checkable other.[1..].[*] // unknown

        let dominated = new List<int>() // output dominated IDs
        let equal  = new List<int>()    // output equal IDs
        for i = rows-1 downto 0 do
            let other = Array.concat [arr.[0..i-1].[*]; arr.[i+1..].[*]]
            match (is_dominated arr.[i].[*] other) with
            | 1 -> dominated.Add(i+1); arr <- Array.concat [arr.[0..i-1].[*]; arr.[i+1..].[*]]
            | 0 -> equal.Add(i+1); arr <- Array.concat [arr.[0..i-1].[*]; arr.[i+1..].[*]]
            | _ -> printfn "Pareto"
        [| dominated; equal |]      
