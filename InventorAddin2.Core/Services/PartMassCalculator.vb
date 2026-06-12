Namespace Services

    Public Class PartMassCalculator

        Public Function CalculateMassKg(volumeCm3 As Double,
                                        densityGPerCm3 As Double) As Double

            If volumeCm3 <= 0 Then
                Throw New ArgumentException("Volume must be greater than zero.")
            End If

            If densityGPerCm3 <= 0 Then
                Throw New ArgumentException("Density must be greater than zero.")
            End If

            Dim massGrams = volumeCm3 * densityGPerCm3

            Return massGrams / 1000.0

        End Function

    End Class

End Namespace