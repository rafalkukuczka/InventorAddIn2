Imports System.Runtime.Versioning
Imports Inventor
Imports InventorAddin.Core.Services
Imports InventorAddin2.Core.Services
Imports Xunit

<SupportedOSPlatform("windows")>
Public Class PartMassIntegrationTests
    Implements IDisposable

    Private fixture As InventorFixture
    Private disposedValue As Boolean

    Sub New()
        fixture = New InventorFixture()
    End Sub

    <Fact>
    Public Sub Inventor_CreatesBox_CoreCalculatesMass()

        ' Arrange
        Dim app = fixture.Application

        Dim partDoc =
            CType(app.Documents.Add(
                DocumentTypeEnum.kPartDocumentObject,
                ,
                True),
                PartDocument)

        Try
            Dim compDef = partDoc.ComponentDefinition

            Dim sketch =
                compDef.Sketches.Add(
                    compDef.WorkPlanes.Item(3))

            Dim tg = app.TransientGeometry

            ' Inventor internal units are centimeters.
            ' Rectangle: 1 cm x 2 cm
            sketch.SketchLines.AddAsTwoPointRectangle(
                tg.CreatePoint2d(0, 0),
                tg.CreatePoint2d(1, 2))

            Dim profile =
                sketch.Profiles.AddForSolid()

            ' Extrude 3 cm
            Dim extrudeDef =
                compDef.Features.ExtrudeFeatures.CreateExtrudeDefinition(
                    profile,
                    PartFeatureOperationEnum.kJoinOperation)

            extrudeDef.SetDistanceExtent(
                3,
                PartFeatureExtentDirectionEnum.kPositiveExtentDirection)

            compDef.Features.ExtrudeFeatures.Add(extrudeDef)

            partDoc.Update()

            Dim volumeCm3 =
                compDef.MassProperties.Volume

            Dim calculator As New PartMassCalculator()

            Dim massKg =
                calculator.CalculateMassKg(volumeCm3, 7.85)

            ' Assert
            Assert.Equal(6.0, volumeCm3, 2)
            Assert.Equal(0.0471, massKg, 3)

        Finally
            partDoc.Close(True)
            'fixture.Dispose()
        End Try

    End Sub

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects)
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override finalizer
            If fixture IsNot Nothing AndAlso fixture.Application IsNot Nothing Then
                fixture.Application.Quit()
            End If
            ' TODO: set large fields to null
            disposedValue = True
        End If
    End Sub

    ' ' TODO: override finalizer only if 'Dispose(disposing As Boolean)' has code to free unmanaged resources
    ' Protected Overrides Sub Finalize()
    '     ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
    '     Dispose(disposing:=False)
    '     MyBase.Finalize()
    ' End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub

End Class