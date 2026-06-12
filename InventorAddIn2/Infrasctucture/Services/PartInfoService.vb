Public Class PartInfoService

    Public Function GetDocumentName(
        doc As Inventor.Document) As String

        Return doc.DisplayName

    End Function

End Class
