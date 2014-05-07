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
    let CalcIndexes (A:double[][], P:int[]) =   
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
        let C = [| for j in 1..modCnt -> [| for i in 1 .. modCnt -> 0.0 |] |]
        let D = [| for j in 1..modCnt -> [| for i in 1 .. modCnt -> 0.0 |] |]
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
                    C.[jj].[ii] <- !pij/float Psum
                    D.[jj].[ii] <- !dij
        [| C, D |]


    let GetGraphByIndexes(C:double[][], D:double[][], Y, Q) = 
        let modCnt = C.GetUpperBound(0) + 1
        let graph = [| for j in 1..modCnt -> [| for i in 1 .. modCnt -> 0 |] |]
        Array.iteri2 (fun i rowC rowD ->
            Array.iteri2 (fun j cij dij ->
                if (cij>=Y) && (dij<=Q) && (i<>j) then
                    graph.[i].[j] <- 1) rowC rowD) C D
        graph


    let GetGraphCore(A:int[][]) =
        let modCnt = A.GetUpperBound(0) + 1
        let precore = Array.create modCnt 0
        Array.iter (fun row ->
            Array.iteri (fun i r ->
                precore.[i] <- precore.[i]+r ) row) A
        Array.map(fun x -> 
                            match x with
                            | x when x=0 -> 1
                            | _ -> 0 ) precore

    let GetSet(A:double[][]) = 
        let list = ref List.Empty
        Array.iteri (fun i row ->
            Array.iteri (fun j aij ->
                if not (List.exists(fun e -> e = aij) !list) && (i<>j) then list := !list @ [aij]
                    ) row) A
        !list |> List.toArray

    let LeadingZeros(s:string) = 
        let mutable str = s
        let maxL = 4
        while str.Length<maxL do
            str <- "0"+str
        str

    let FinalScore(C:double[][], D:double[][], names:string[]) = 
        let modCnt = C.GetUpperBound(0) + 1
        let cores = [| for j in 1..modCnt -> [| for i in 1 .. modCnt -> 0 |] |]
        //Array.iteri2 (fun i rowC rowD ->
        //    Array.iteri2 (fun j cij dij ->
        //        if not (List.exists(fun e -> e = cij) !clist) && (i<>j) then clist := !clist @ [cij]
        //        if not (List.exists(fun e -> e = dij) !dlist) && (i<>j) then dlist := !dlist @ [dij]
        //            ) rowC rowD) C D
        let yset = GetSet C
        let qset = GetSet D
        printfn "Y=%O, Q=%O" yset qset
        for y in yset do
            for q in qset do
                let graph = GetGraphByIndexes (C, D, y, q)
                let core = GetGraphCore graph
                let coreCnt = Array.sum core
                printfn "Y=%f, Q=%f, count=%d" y q coreCnt
                if coreCnt>0 then
                    Array.iteri (fun i x -> if x>0 then cores.[coreCnt].[i] <- cores.[coreCnt].[i] + 1) core
        let results = Array.create modCnt ""
        for m=0 to modCnt-1 do //models
            for c=1 to modCnt-1 do //cores
                results.[m] <- results.[m] + LeadingZeros (sprintf "%d" cores.[c].[m])
        let pairs = Array.zip results names |> Array.sortBy (fun (x,y) -> (x,y)) |> Array.rev
        cores

