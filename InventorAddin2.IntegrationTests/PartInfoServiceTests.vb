Imports Inventor
Imports Xunit

Public Class PartInfoServiceTests
    Implements IDisposable

    Sub New()
        fixture = New InventorFixture()
    End Sub

    Private ReadOnly fixture As InventorFixture


    <Fact>
    Public Sub Returns_Document_Name()

        Dim doc =
            fixture.Application.Documents.Add(
                DocumentTypeEnum.kPartDocumentObject)

        Dim service As New PartInfoService()

        Dim name = service.GetDocumentName(doc)

        Assert.NotNull(name)

        doc.Close(True)

    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose

        If fixture IsNot Nothing AndAlso fixture.Application IsNot Nothing Then
            fixture.Application.Quit()
        End If

        GC.WaitForPendingFinalizers()
        GC.Collect()


    End Sub
End Class