Namespace Logger
    Public Class DebugLogger
        Implements ILogger

        Public Sub Log(msg As String) Implements ILogger.Log
            Debug.WriteLine(msg)
        End Sub
    End Class

End Namespace
