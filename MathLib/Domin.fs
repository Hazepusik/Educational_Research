namespace MathLib
open System.Collections.Generic
open Microsoft.FSharp.Math

module public Domin =  

    let CalcDominated (input:double[][]) = 
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


module public Electre = 
    let CalcIndexes (A:double[][], P:int[], Li:double[]) =   
        let crCnt = A.[0].GetUpperBound(0) + 1
        let modCnt = A.GetUpperBound(0) + 1
        //let getColumn (c, mat:double[][]) = 
        //    let rows = mat.GetUpperBound(0) + 1
        //    let mutable column = Array.zeroCreate<double> rows
        //    for r = 0 to rows-1 do
        //        column.[r] <- mat.[r].[c]
        //    column
        //let Li = Array.zeroCreate<double> crCnt
        //for i = 0 to crCnt - 1 do
            //Li.[i] <- (Array.max (getColumn (i, A)))-(Array.min (getColumn (i, A)))
        let C = Array2D.zeroCreate<double> modCnt modCnt
        let D = Array2D.zeroCreate<double> modCnt modCnt
        let pij = ref 0.0
        let dij = ref 0.0

        let Psum = Array.sum P

        for ii = 0 to modCnt - 1 do
            for jj = 0 to modCnt - 1 do
                if ii<>jj then
                    pij := 0.0
                    dij := 0.0
                    Array.iteri2 (fun i x y ->
                        if x>=y then
                            pij := !pij + float P.[i]
                        else
                            dij := max !dij ((y-x)/Li.[i]) ) A.[ii].[*] A.[jj].[*]
                    C.[jj,ii] <- !pij/float Psum
                    D.[jj,ii] <- !dij
        [| C, D |]





    let CalcIndexes111 (A:double[][], P:int[]) =   
        let crCnt = A.[0].GetUpperBound(0) + 1
        let modCnt = A.GetUpperBound(0) + 1
        let getColumn (c, mat:double[][]) = 
            let rows = mat.GetUpperBound(0) + 1
            let mutable column = Array.zeroCreate<double> rows
            for r = 0 to rows-1 do
                column.[r] <- mat.[r].[c]
            column
        let Li = Array.zeroCreate<double> crCnt
        for i = 0 to crCnt - 1 do
            Li.[i] <- (Array.max (getColumn (i, A)))-(Array.min (getColumn (i, A)))
        let C = Array2D.zeroCreate<double> modCnt modCnt
        let D = Array2D.zeroCreate<double> modCnt modCnt
        let pij = ref 0.0
        let dij = ref 0.0

        let Psum = Array.sum P

        for ii = 0 to modCnt - 1 do
            for jj = 0 to modCnt - 1 do
                if ii<>jj then
                    pij := 0.0
                    dij := 0.0
                    Array.iteri2 (fun i x y ->
                        if x>=y then
                            pij := !pij + float P.[i]
                        else
                            dij := max !dij ((y-x)/Li.[i]) ) A.[ii].[*] A.[jj].[*]
                    C.[jj,ii] <- !pij/float Psum
                    D.[jj,ii] <- !dij
        [| C, D |]