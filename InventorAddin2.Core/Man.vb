
Imports InventorAddin2.Core.Logger

Public Class Man
    Implements IPerson

    Private _name As String
    Private _age As Integer

    Public Sub New(name As String, age As Integer)
        _name = name
        _age = age
    End Sub

    Public Property Name As String Implements IPerson.Name
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Public ReadOnly Property Age As Integer Implements IPerson.Age
        Get
            Return _age
        End Get
    End Property

    Public Sub Hello(logger As ILogger) Implements IPerson.Hello
        logger.Log($"Hello, I am {Name} of {Age} years")
    End Sub

End Class
