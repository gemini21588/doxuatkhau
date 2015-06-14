Public Class ProductViewModel
    Inherits ViewModel

    Private _productLink As String

#Region "Constructors"
    Public Sub New(ByVal pCategory As String, ByVal pMaker As String, ByVal pProduct As String)    
        Me.CategoryLink = pCategory
        Me.MakerLink = pMaker
        Me._productLink = pProduct        
        Me.LoadProduct()
    End Sub
#End Region

#Region "Properties"
    Public Property Product As GetProduct_Result

    Public Property CategoryName As String

    Public Property MakerName As String

    Public Property ProductListSameType As List(Of Product)

    Public Property CategoryLink As String

    Public Property MakerLink As String
#End Region

    Private Sub LoadProduct()
        Using context As New siteEntities
            context.Configuration.LazyLoadingEnabled = False
            Product = context.GetProduct(Me.CategoryLink, Me.MakerLink, Me._productLink).FirstOrDefault()
            If Product IsNot Nothing Then
                Me.CategoryName = Product.CategoryName
                Me.MakerName = Product.MakerName

                Me.Keywords &= "," & Me.CategoryName & "," & MakerName & "," & Product.Name

                Dim numberOfProductSameType As Integer = ConfigurationManager.AppSettings(ChoMayTinh.Constants.AppSetting.NumberOfProductSameType)
                Me.ProductListSameType = context.Products.Where(Function(x) x.Category.Link = CategoryLink And x.Maker.Link = MakerLink And x.Id <> Me.Product.Id).Take(numberOfProductSameType).ToList()
            End If
        End Using
    End Sub

End Class
