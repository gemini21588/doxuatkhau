Public Class ProductListViewModel
    Inherits ViewModel

#Region "Constructors"
    Public Sub New(ByVal pCategory As String, ByVal pMaker As String, ByVal pCurrentPage As Integer)
        Me.CategoryLink = pCategory
        Me.MakerLink = pMaker
        Me.CurrentPage = pCurrentPage        
        Me.LoadProductList()
    End Sub
#End Region

#Region "Properties"

    Public Property CurrentPage As Integer = 1

    Public Property Total As Integer = 0

    Public Property NumberItemPerPage As Integer = 0

    Public Property ProductList As List(Of GetProductList_Result)

    Public Property CategoryLink As String

    Public Property MakerLink As String

    Public Property CategoryName As String

    Public Property MakerName As String

#End Region

    Private Sub LoadProductList()
        Using context As New siteEntities
            context.Configuration.LazyLoadingEnabled = False

            Dim category As Category = context.Categories.Where(Function(x) x.Link = CategoryLink).FirstOrDefault()
            Dim maker As Maker = context.Makers.Where(Function(x) x.Link = MakerLink).FirstOrDefault()

            If category IsNot Nothing AndAlso maker IsNot Nothing Then
                Me.CategoryName = category.Name
                Me.MakerName = maker.Name

                Me.Keywords &= "," & Me.CategoryName & "," & maker.Name

                Me.NumberItemPerPage = CInt(ConfigurationManager.AppSettings(Constants.AppSetting.ProductPerPage))
                ProductList = context.GetProductList(Me.CategoryLink, Me.MakerLink, Me.CurrentPage, Me.NumberItemPerPage).ToList()
                Me.Total = context.Products.Where(Function(x) x.CategoryId = category.Id AndAlso x.MakerId = maker.Id).Count
            End If
        End Using
    End Sub

End Class
