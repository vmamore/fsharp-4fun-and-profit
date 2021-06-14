let product n =
    let initialValue = 1
    let action productSoFar x = productSoFar * x
    [1..n] |> List.fold action initialValue

product 10

let sumOfOdds n =
    let initialValue = 0
    let action sumSoFar x = if x%2=0 then sumSoFar else sumSoFar+x
    [1..n] |> List.fold action initialValue

sumOfOdds 10

let alternatingSum n =
    let initialValue = (true,0)
    let action (isNeg, sumSoFar) x = if isNeg then (false, sumSoFar-x)
                                              else (true, sumSoFar+x)
    [1..n] |> List.fold action initialValue |> snd

alternatingSum 100

type NameAndSize = {Name:string;Size:int}

let maxNameAndSize list =

    let innerMaxNameAndSize initialValue rest =
        let action maxSoFar x = if maxSoFar.Size < x.Size then x else x