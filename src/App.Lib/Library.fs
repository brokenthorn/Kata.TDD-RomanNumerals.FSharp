module App.Lib

let private standardArabicToRomanPairs = [|
    (5u, "V")
    (1u, "I")
|]

let private getFactor (arabicNumber: uint32) =
    Array.find
    <| fun pair -> (pair |> fst) <= arabicNumber
    <| standardArabicToRomanPairs

/// Takes an unsigned Arabic number and converts it to a Roman numeral.
let rec toRomanNumeral (arabicNumber: uint32) : string =
    match arabicNumber with
    | 0u -> ""
    | _ ->
        let (arabicPair, romanPair) = getFactor arabicNumber
        romanPair + toRomanNumeral (arabicNumber - arabicPair)
