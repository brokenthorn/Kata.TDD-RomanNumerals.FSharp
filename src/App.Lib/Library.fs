module App.Lib

let private standardArabicToRomanPairs =
    [| (1000u, "M")
       (900u, "CM")
       (500u, "D")
       (400u, "CD")
       (100u, "C")
       (90u, "XC")
       (50u, "L")
       (40u, "XL")
       (10u, "X")
       (9u, "IX")
       (5u, "V")
       (4u, "IV")
       (1u, "I") |]

/// Gets the Arabic number and Roman numeral pair corresponding to the passed in Arabic number.
/// The passed Arabic number must match one of the standard Arabic to Roman numeral pairs, otherwise the function will throw `System.Collections.Generic.KeyNotFoundException`.
let private getConversionPair (inArabic: uint32) =
    Array.find
    <| fun (arabic, _) -> arabic <= inArabic
    <| standardArabicToRomanPairs

/// Takes an unsigned Arabic number and converts it to a Roman numeral.
let rec toRomanNumeral (inArabic: uint32) : string =
    match inArabic with
    | 0u -> ""
    | x when x > 3999u ->
        failwith (sprintf "Cannot convert numbers greater than 3999 to Roman numeral, tried to convert %u" x)
    | _ ->
        let (arabic, roman) = getConversionPair inArabic
        let remArabicToConvert = inArabic - arabic
        roman + toRomanNumeral remArabicToConvert
