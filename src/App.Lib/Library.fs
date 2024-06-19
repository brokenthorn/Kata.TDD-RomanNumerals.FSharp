module App.Lib

let toRomanNumeral (num: uint32): string =
    match num with
    | 0u -> ""
    | 1u -> "I"
    | _ -> ""