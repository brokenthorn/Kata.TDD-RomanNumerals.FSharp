module App.Lib

/// Takes an unsigned 32bit integer and converts it to a Roman numeral string.
let toRomanNumeral (num: uint32) : string =
    match num with
    | 0u -> ""
    | 1u -> "I"
    | 5u -> "V"
    | _ -> failwith (sprintf "Could not convert %u to a Roman numeral" num)
