Imports InventorAddin2.Core.Services
Imports Xunit

Public Class PartMassCalculatorTests

    '60 cm3 * 7.85 g/cm3 = 471 g = 0.471 kg
    <Fact>
    Public Sub CalculateMassKg_ForSteelBlock_ReturnsCorrectMass()

        ' Arrange
        Dim calculator As New PartMassCalculator()

        Dim volumeCm3 As Double = 60.0
        Dim densitySteel As Double = 7.85

        ' Act
        Dim result = calculator.CalculateMassKg(volumeCm3, densitySteel)

        ' Assert
        Assert.Equal(0.471, result, 3)

    End Sub

End Class