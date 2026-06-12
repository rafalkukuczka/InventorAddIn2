

Imports InventorAddin2.Core.Logger

Public Interface IPerson
    Property Name As String
    ReadOnly Property Age As Integer

    Sub Hello(logger As ILogger)

End Interface
