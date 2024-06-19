module Tests

open Xunit
open App.Lib

[<Fact>]
let ``Romans didn't have a 0`` () =
    let zero = 0u
    let roman = toRomanNumeral zero
    Assert.Equal("", roman)

[<Fact>]
let ``Converts 1 to I`` () =
    let one = 1u
    let roman = toRomanNumeral one
    Assert.Equal("I", roman) 