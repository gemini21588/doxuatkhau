Imports System.ComponentModel.DataAnnotations

Public Class ManagementViewModel

#Region "Private members"

    Private context As siteEntities

#End Region

    Public Sub New()
        context = New siteEntities
        context.Configuration.LazyLoadingEnabled = False
    End Sub

#Region "Properties"

    Public Property CurrentPage As Integer

    Public Property Total As Integer

    Public Property NumberItemPerPage As Integer

    Public Property ProductList As List(Of Product)

    Public Property Product As Product

    Public Property MenuLevel1 As SelectList

    Public Property MenuLevel2 As SelectList

    Public Property Keyword As String

    Public Property SelectedMenuLevel1 As Integer = 0

    Public Property SelectedMenuLevel2 As Integer = 0

#End Region

#Region "Method"

    Public Sub GetProductList()
        Me.Total = context.Products.Count
        Me.NumberItemPerPage = CInt(ConfigurationManager.AppSettings(Constants.AppSetting.ItemPerPage))
        Me.ProductList = context.Products.OrderByDescending(Function(x) x.UdDate).Skip(NumberItemPerPage * (CurrentPage - 1)).Take(NumberItemPerPage).ToList()
        Me.InitMenuLevel()
    End Sub

    Public Sub Filter(menuLevel1 As Integer, menuLevel2 As Integer)
        Me.SelectedMenuLevel1 = menuLevel1
        Me.SelectedMenuLevel2 = menuLevel2
        ProductList = Me.context.Products.Where(Function(x) x.CategoryId = menuLevel1 AndAlso x.MakerId = menuLevel2).OrderByDescending(Function(x) x.UdDate).ToList
        Me.InitMenuLevel()
    End Sub

    Public Sub SearchProduct(productName As String)
        If Not String.IsNullOrEmpty(productName.Trim) Then
            Me.ProductList = context.Products.Where(Function(x) x.Name.Contains(productName)).OrderByDescending(Function(x) x.UdDate).ToList
            Me.Keyword = productName
        Else
            Me.ProductList = New List(Of Product)
        End If
        Me.InitMenuLevel()
    End Sub

    Private Sub InitMenuLevel()
        Me.MenuLevel1 = New SelectList(context.Categories, "Id", "Name", SelectedMenuLevel1)
        Me.MenuLevel2 = New SelectList(context.Makers, "Id", "Name", SelectedMenuLevel1)
    End Sub

#End Region

End Class
