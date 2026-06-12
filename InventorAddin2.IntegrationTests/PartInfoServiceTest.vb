Imports Inventor
Imports Xunit

Public Class PartInfoServiceTests


    <Fact>
    Public Sub Returns_Document_Name()

        Dim fixture As New InventorFixture()

        Dim doc =
            fixture.Application.Documents.Add(
                DocumentTypeEnum.kPartDocumentObject)

        Dim service As New PartInfoService()

        Dim name = service.GetDocumentName(doc)

        Assert.NotNull(name)

        doc.Close(True)

    End Sub

End Class