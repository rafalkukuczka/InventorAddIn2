Imports System.Runtime.InteropServices
Imports System.Runtime.Versioning

Public NotInheritable Class Marshal2

    Private Sub New()
    End Sub

    <DllImport("oleaut32.dll", PreserveSig:=False)>
    Private Shared Function GetActiveObject(
        <MarshalAs(UnmanagedType.LPWStr)> progId As String,
        reserved As IntPtr
    ) As <MarshalAs(UnmanagedType.IDispatch)> Object
    End Function

    <SupportedOSPlatform("windows")>
    Public Shared Function GetActiveObject(progId As String) As Object
        Return GetActiveObject(progId, IntPtr.Zero)
    End Function

End Class