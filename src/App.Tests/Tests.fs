module Tests

open Xunit
open App.Lib

let testData: obj[] list = [ [| 0; "" |]; [| 1; "I" |]; [| 5; "V" |] ]

[<Theory>]
[<MemberData(nameof (testData))>]
let ``Converts Arabic number to Roman numeral`` number expected =
    let actual = toRomanNumeral number
    Assert.Equal(expected, actual)
