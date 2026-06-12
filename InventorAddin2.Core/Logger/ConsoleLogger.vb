Namespace Logger

    Public Class ConsoleLogger
        Implements ILogger

        Public Sub Log(msg As String) Implements ILogger.Log
            Console.WriteLine(msg)
        End Sub
    End Class

End Namespace
