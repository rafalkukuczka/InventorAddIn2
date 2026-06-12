Imports Inventor
Imports System.Runtime.InteropServices

Public Class InventorFixture

    Public ReadOnly Property Application As Inventor.Application

    Public Sub New()

        Try

            Application =
                CType(Marshal2.GetActiveObject("Inventor.Application"),
                Inventor.Application)

        Catch

            Dim inventorType =
                Type.GetTypeFromProgID("Inventor.Application")

            Application =
                CType(Activator.CreateInstance(inventorType),
                Inventor.Application)

            Application.Visible = True

        End Try

    End Sub

End Class