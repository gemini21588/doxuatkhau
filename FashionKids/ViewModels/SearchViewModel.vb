Public Class SearchViewModel
    Inherits ViewModel

#Region "Constructors"
    Public Sub New(ByVal pTextSearch As String)
        Me.TextSearch = pTextSearch        
    End Sub
#End Region

#Region "Properties"
    Public Property ProductList As List(Of GetProductList_Result)
#End Region

#Region "Method"
    Public Sub SearchProduct()
        Using context As New siteEntities
            context.Configuration.LazyLoadingEnabled = False

            Me.ProductList = context.SearchProduct(Me.TextSearch).ToList()
        End Using
    End Sub
#End Region
    

End Class
