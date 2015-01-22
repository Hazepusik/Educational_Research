namespace MathLib
open System.Collections.Generic
open Microsoft.FSharp.Math

module public Common = 

    let getColumn (c, mat:double[][]) = 
        [0..mat.GetUpperBound(0)] |> List.map(fun i -> mat.[i].[c]) |> List.toArray


    let MakeReverse(A:double[][], ids) = 
        let containsNumber number arr = Seq.exists (fun elem -> elem = number) arr
        let maxes = List.map(fun i -> Array.max (getColumn (i, A))) [0..A.[0].GetUpperBound(0) + 1-1]
        Array.iteri (fun i row ->
            Array.iteri (fun j aij ->
                if containsNumber (j+1) ids then
                    A.[i].[j] <- maxes.[j] - aij ) row) A
        A


    let GetGraphCore(A:int[][]) = 
        // returns array of 0 and 1: 1 - model is in core
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
        // returns sorted array 
        let list = ref List.Empty
        Array.iteri (fun i row ->
            Array.iteri (fun j aij ->
                if not (List.exists(fun e -> e = aij) !list) && (i<>j) then list := !list @ [aij]
                    ) row) A
        !list |> List.toArray |> Array.sort

    let LeadingZeros(s:string) = 
        let mutable str = s
        let maxL = 6
        while str.Length<maxL do
            str <- "0"+str
        str

    let CountPlaces pairs = 
        // returns sorted array of tuples. conact models with equal scores
        let mutable last = ""
        let mutable groups = List.empty
        let mutable group = List.empty
        for p in pairs do
            if (last<>fst p) && (last<>"") then
                groups <- group :: groups
                group <- []
            group <- snd p :: group
            last <- fst p
        groups <- group :: groups |> List.rev
        let mutable score = 0.0
        let mutable cur = 1.0
        let mutable result = List.empty
        for eq in groups do
            let n = float eq.Length
            score <-  (2.0 * cur + n - 1.0) / 2.0
            for m in eq do
                result <- result @ [(m, score)]
            cur <- cur + n   
        result |> List.toArray

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
        
        
    let EqualIndex (input:double[][], num:int) =
        let ans = ref 0 
        input.[0..num-1].[*] |> Array.iteri (fun i x -> 
            if (x=input.[num].[*]) && (!ans = 0) then
                ans := i ) 
      
        !ans + 1 // model ID, not number

module public Superiority = 
    let CalcIndexes (A:double[][], P:int[]) =   
        let crCnt = A.[0].GetUpperBound(0) + 1
        let modCnt = A.GetUpperBound(0) + 1
        let C = [| for j in 1..modCnt -> [| for i in 1 .. modCnt -> 0.0 |] |]
        let plus = ref 0.0
        let minus = ref 0.0

        for ii = 0 to modCnt - 1 do
            for jj = 0 to modCnt - 1 do
                if ii<>jj then
                    plus := 0.0
                    minus := 0.0
                    Array.iteri2 (fun i x y ->
                        if x>y then
                            plus := !plus + float P.[i]
                        else
                            minus := !minus + float P.[i] ) A.[ii].[*] A.[jj].[*]
                    C.[ii].[jj] <- !plus / !minus
        C

    let GetGraphByIndexes(C:double[][], Y) = 
        let modCnt = C.GetUpperBound(0) + 1
        let eps = 0.000001 //round errors
        let graph = [| for j in 1..modCnt -> [| for i in 1 .. modCnt -> 0 |] |]
        Array.iteri (fun i row  ->
            Array.iteri (fun j cij ->
                if (cij>=Y-eps) && (i<>j) then
                    graph.[i].[j] <- 1) row) C 
        graph


    let FinalScore(C:double[][], names:string[]) = 
        let modCnt = C.GetUpperBound(0) + 1
        let cores = [| for j in 1..modCnt+1 -> [| for i in 1 .. modCnt+1 -> 0 |] |]
        let yset = Common.GetSet C
        for y in yset do
            let graph = GetGraphByIndexes (C, y)
            let core = Common.GetGraphCore graph
            let coreCnt = Array.sum core
            if coreCnt>0 then
                Array.iteri (fun i x -> if x>0 then cores.[coreCnt].[i] <- cores.[coreCnt].[i] + 1) core
        let results = Array.create modCnt ""
        for m=0 to modCnt-1 do //models
            for c=1 to modCnt-1 do //cores
                results.[m] <- results.[m] + Common.LeadingZeros (sprintf "%d" cores.[c].[m])
        let pairs = Array.zip results names |> Array.sortBy (fun (x,y) -> (x,y)) |> Array.rev
        Common.CountPlaces pairs



module public Electre = 
    let CalcIndexes (A:double[][], P:int[]) =   
        let crCnt = A.[0].GetUpperBound(0) + 1
        let modCnt = A.GetUpperBound(0) + 1
        let Li = Array.zeroCreate<double> crCnt
        //let Li1 = Array.zeroCreate<double> crCnt
        let maxp = float (Array.max P)
        let Psum = Array.sum P
        //for i = 0 to crCnt - 1 do
        //    Li.[i] <- (Array.max (Common.getColumn (i, A)))-(Array.min (Common.getColumn (i, A)))

        let Li = List.map(fun i -> (Array.max (Common.getColumn (i, A))-(Array.min (Common.getColumn (i, A)))) * maxp / float P.[i]) [0..crCnt-1]
        //let Li = List.map(fun i -> (Array.max (Common.getColumn (i, A))-(Array.min (Common.getColumn (i, A))))) [0..crCnt-1]


        let C = [| for j in 1..modCnt -> [| for i in 1 .. modCnt -> 0.0 |] |]
        let D = [| for j in 1..modCnt -> [| for i in 1 .. modCnt -> 0.0 |] |]
        let pij = ref 0.0
        let dij = ref 0.0


        for ii = 0 to modCnt - 1 do
            for jj = 0 to modCnt - 1 do
                if ii<>jj then
                    pij := 0.0
                    dij := 0.0
                    Array.iteri2 (fun i x y ->
                        if x>=y then
                            pij := !pij + float P.[i]
                        else
                            let qq = ((y-x)/Li.[i])
                            dij := max !dij qq ) A.[ii].[*] A.[jj].[*]
                    C.[ii].[jj] <- !pij/float Psum
                    D.[ii].[jj] <- !dij
        [| C, D |]


    let GetGraphByIndexes(C:double[][], D:double[][], Y, Q) = 
        let modCnt = C.GetUpperBound(0) + 1
        let eps = 0.000001 //round errors
        let graph = [| for j in 1..modCnt -> [| for i in 1 .. modCnt -> 0 |] |]
        Array.iteri2 (fun i rowC rowD ->
            Array.iteri2 (fun j cij dij ->
                if (cij>=Y-eps) && (dij<=Q+eps) && (i<>j) then
                    graph.[i].[j] <- 1) rowC rowD) C D
        graph


    let FinalScore(C:double[][], D:double[][], names:string[]) = 
        let modCnt = C.GetUpperBound(0) + 1
        let cores = [| for j in 1..modCnt+1 -> [| for i in 1 .. modCnt+1 -> 0 |] |]
        let yset = Common.GetSet C
        let qset = Common.GetSet D
        for y in yset do
            for q in qset do
                let graph = GetGraphByIndexes (C, D, y, q)
                let core = Common.GetGraphCore graph
                let coreCnt = Array.sum core
                printfn "Y=%f, Q=%f, count=%d" y q coreCnt
                if coreCnt>0 then
                    Array.iteri (fun i x -> if x>0 then cores.[coreCnt].[i] <- cores.[coreCnt].[i] + 1) core
        let results = Array.create modCnt ""
        //[1..modCnt-1] |> List.iter ( [1..modCnt-1] |> List.map )
        for m=0 to modCnt-1 do //models
            for c=1 to modCnt-1 do //cores
                results.[m] <- results.[m] + Common.LeadingZeros (sprintf "%d" cores.[c].[m])
        let pairs = Array.zip results names |> Array.sortBy (fun (x,y) -> (x,y)) |> Array.rev
        Common.CountPlaces pairs

module public IdealPoint = 
    let distance2(pnt:double[], ideal, worst, P) = 
        let pnt = pnt |> Array.toList
        //TODO: check without alco
        let diffs = List.map3(fun x i w -> ((i-x)/(i-w))**2.0) pnt ideal worst
        //let diffs = List.map2(fun x i -> (i-x)**2.0) pnt ideal
        //let dists = diffs
        let dists = List.map2(fun d p -> d*(float p/100.0)**2.0) diffs P
        sprintf "%d" (int ((dists |> List.sum |> sqrt) * 10000.0))
    let FinalScore(A:double[][], P:int[], names:string[]) = 
        let names = names |> Array.toList
        let P = P |> Array.toList
        let ideal = [0..A.[0].GetUpperBound(0)] |> List.map(fun i -> Array.max (Common.getColumn(i, A)))
        let worst = [0..A.[0].GetUpperBound(0)] |> List.map(fun i -> Array.min (Common.getColumn(i, A))) 
        let qq = A.[0].GetUpperBound(0)
        let qqw = A.GetUpperBound(0)
        let dists = [0..A.GetUpperBound(0)] |> List.map(fun i -> Common.LeadingZeros (distance2 (A.[i], ideal, worst, P)))
        let pairs = List.zip dists names |> List.sortBy (fun (x,y) -> (x,y)) |> List.toArray
        Common.CountPlaces pairs


module public Convolution = 
    let oneConv(pnt:double[], ideal, worst, P) = 
        let pnt = pnt |> Array.toList
        //TODO: check without alco
        let conv = List.map3(fun x i w -> (x-w)/(i-w)) pnt ideal worst
        let conv = List.map2(fun d p -> d*float p/100.0) conv P
        sprintf "%d" (int ((conv |> List.sum) * 10000.0))
    let FinalScore(A:double[][], P:int[], names:string[]) = 
        let names = names |> Array.toList
        let P = P |> Array.toList
        let ideal = [0..A.[0].GetUpperBound(0)] |> List.map(fun i -> Array.max (Common.getColumn(i, A)))
        let worst = [0..A.[0].GetUpperBound(0)] |> List.map(fun i -> Array.min (Common.getColumn(i, A)))
        let convolution = [0..A.GetUpperBound(0)] |> List.map(fun i -> Common.LeadingZeros ( oneConv (A.[i], ideal, worst, P)))
        let pairs = List.zip convolution names |> List.sortBy (fun (x,y) -> (x,y)) |> List.rev |> List.toArray
        Common.CountPlaces pairs


module public Promethee = 


    let fx(x:double) =
        let p = 0.15
        let q = 0.85
        let ans = ref 0.0
        if (x<p) then
             ans := 0.0
        else 
            if (x>q) then
                ans := 1.0
            else
                ans := (!ans - p) / (q - p) // TODO: CHECK IT
        !ans

    let p(a,b,f) =
        a

    let H(x,f) = 
        x

    let P_f(a,b,f) = 
        if a<b then
            0.0
        else
            let x = float(a-b)
            fx(x) // func 1-6


    let oneCnt(pnt:double[], ideal, worst, P, f) = 
        let critdata = pnt |> Array.toList
        let row = List.map2(fun d p -> fx(d) * float p / 100.0) critdata P
        sprintf "%d" (int ((row |> List.sum) * 10000.0))

    let norm(pnt:double[], ideal, worst) = 
        let pnt = pnt |> Array.toList
        List.map3(fun x i w -> (x-w)/(i-w)) pnt ideal worst |> List.toArray

    let pi_f(a,b,p,f) = 
        let pidata = List.map3(fun aa bb pp -> float(pp) * P_f(aa, bb, f) ) a b p //|> List.map(fun i -> float(i))
        pidata |> List.sum

    let phiplus(A:double[][], i:int, P, f:int) = 
        let a = A.[i] |> Array.toList
        let sum = [0..A.GetUpperBound(0)] |> List.map(fun j -> pi_f(a, A.[j] |> Array.toList, P, f))
        sum
    

    let FinalScore(A:double[][], P:int[], names:string[], f:int) = 
        let names = names |> Array.toList
        let P = P |> Array.toList
        let ideal = [0..A.[0].GetUpperBound(0)] |> List.map(fun i -> Array.max (Common.getColumn(i, A)))
        let worst = [0..A.[0].GetUpperBound(0)] |> List.map(fun i -> Array.min (Common.getColumn(i, A)))
        let normdata = [0..A.GetUpperBound(0)] |> List.toArray |> Array.map(fun i -> norm(A.[i], ideal, worst))
        let promethee = phiplus(normdata, 1, P, f)
        let promethee = [0..A.GetUpperBound(0)] |> List.map(fun i -> Common.LeadingZeros ( oneCnt (normdata.[i], ideal, worst, P, f)))
        let pairs = List.zip promethee names |> List.sortBy (fun (x,y) -> (x,y)) |> List.rev |> List.toArray
        Common.CountPlaces pairs