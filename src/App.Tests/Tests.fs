module Tests

open Xunit
open App.Lib

[<Fact>]
let ``Fails when converting numbers greater than 3999`` () =
    for i in 4000u .. 5000u do
        Assert.ThrowsAny<System.Exception>(fun () -> (toRomanNumeral i) |> ignore)
        |> ignore

/// Test data that maps an Arabic number to the correct Roman numeral.
let testData: obj[] list =
    // Romans didn't have a zero.
    [ [| 0u; "" |]
      [| 1u; "I" |]
      [| 2u; "II" |]
      [| 3u; "III" |]
      [| 4u; "IV" |]
      [| 5u; "V" |]
      [| 6u; "VI" |]
      [| 7u; "VII" |]
      [| 8u; "VIII" |]
      [| 9u; "IX" |]
      [| 10u; "X" |]
      [| 11u; "XI" |]
      [| 20u; "XX" |]
      [| 30u; "XXX" |]
      [| 31u; "XXXI" |]
      [| 32u; "XXXII" |]
      [| 33u; "XXXIII" |]
      [| 34u; "XXXIV" |]
      [| 35u; "XXXV" |]
      [| 40u; "XL" |]
      [| 50u; "L" |]
      [| 60u; "LX" |]
      [| 70u; "LXX" |]
      [| 80u; "LXXX" |]
      [| 90u; "XC" |]
      [| 100u; "C" |]
      [| 3497u; "MMMCDXCVII" |]
      // Largest possible Roman numeral is 3999.
      [| 3999u; "MMMCMXCIX" |] ]

[<Theory>]
[<MemberData(nameof (testData))>]
let ``Converts Arabic number to Roman numeral`` arabicNumber expectedRomanNumeral =
    let romanNumeral = toRomanNumeral arabicNumber
    Assert.Equal(expectedRomanNumeral, romanNumeral)
