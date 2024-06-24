module Tests

open Xunit
open App.Lib

/// Test data that maps an Arabic number to the correct Roman numeral.
let testData: obj[] list = [ [| 0; "" |]; [| 1; "I" |]; [| 2; "II" |]; [| 5; "V" |] ]

[<Theory>]
[<MemberData(nameof (testData))>]
let ``Converts Arabic number to Roman numeral`` arabicNumber expectedRomanNumeral =
    let romanNumeral = toRomanNumeral arabicNumber
    Assert.Equal(expectedRomanNumeral, romanNumeral)
