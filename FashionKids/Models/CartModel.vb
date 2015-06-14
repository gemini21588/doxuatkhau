Public Class CartModel
    Public Property Id As Integer
    Public Property Link As String
    Public Property CategoryLink As String
    Public Property MakerLink As String
    Public Property Image As String
    Public Property Name As String
    Public Property Price As Double
    Public Property Quantity As Integer

    Public ReadOnly Property Total As Double
        Get
            Return (Price * Quantity)
        End Get        
    End Property
End Class
