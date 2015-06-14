Public Class ViewModel

#Region "Private members"

    Private context As siteEntities

#End Region

#Region "Properties"
    ''' <summary>
    ''' Description
    ''' </summary>    
    Public Property Description As String

    ''' <summary>
    ''' Keywords
    ''' </summary>    
    Public Property Keywords As String

    ''' <summary>
    ''' Robots
    ''' </summary>    
    Public Property Robots As String

    ''' <summary>
    ''' Menu
    ''' </summary>    
    Public Property Menu As List(Of GetMenu_Result)

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CartItemCount As Integer

    ''' <summary>
    ''' search keyword
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TextSearch As String

    ''' <summary>
    ''' Advertisement
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Advertisement As String

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TotalPrice As Double

    Public Property SlideShow As List(Of SlideShow)

    Public Property HotProducts As List(Of GetProductList_Result)

    Public Property NewProducts As List(Of GetProductList_Result)

    Public Property HotNews As List(Of News)
#End Region

#Region "Constructors"
    ''' <summary>
    ''' Default Constructor.
    ''' </summary>    
    Public Sub New(Optional isPostBack As Boolean = False)
        context = New siteEntities
        context.Configuration.LazyLoadingEnabled = False

        If Not isPostBack Then
            Me.LoadSetting()
        End If
    End Sub
#End Region

#Region "Methods"

    Protected Overridable Sub LoadSetting()
        Me.Description = ConfigurationManager.AppSettings(Constants.AppSetting.Description)
        Me.Keywords = ConfigurationManager.AppSettings(Constants.AppSetting.Keywords)
        Me.Robots = Constants.IndexFollow

        'Me.GetMenu()

        'Me.GetAdvertisement()

        Dim cart As List(Of CartModel) = HttpContext.Current.Session(SessionKeys.Cart)
        If cart IsNot Nothing Then
            CartItemCount = cart.Count
            TotalPrice = cart.Sum(Function(x) x.Price * x.Quantity)
        End If

        Me.GetSlideShow()
    End Sub

    Public Sub LoadHomePageSetting()
        'Me.GetSlideShow()

        Me.GetHotProducts()

        Me.GetNewProducts()

        Me.GetHotNews()
    End Sub

    ''' <summary>
    ''' Get danh sách menu.
    ''' </summary>    
    Private Sub GetMenu()
        Me.Menu = context.GetMenu().ToList()
    End Sub

    ''' <summary>
    ''' Get danh sách menu.
    ''' </summary>    
    Private Sub GetSlideShow()
        Me.SlideShow = context.SlideShows().ToList()
    End Sub

    Private Sub GetHotProducts()
        Me.HotProducts = New List(Of GetProductList_Result)
        Dim numberOfHotProduct As Integer = ConfigurationManager.AppSettings(ChoMayTinh.Constants.AppSetting.NumberOfHotProduct)
        Dim result = context.Products.Where(Function(x) x.OldPrice > 0).OrderByDescending(Function(x) x.UdDate).Take(numberOfHotProduct).ToList()
        For Each item In result
            Dim product As New GetProductList_Result With {
                .Id = item.Id,
                .Name = item.Name,
                .ProductLink = item.Link,
                .MakerLink = context.Makers.Where(Function(x) x.Id = item.MakerId).FirstOrDefault().Link.ToString(),
                .CategoryLink = context.Categories.Where(Function(x) x.Id = item.CategoryId).FirstOrDefault().Link.ToString(),
                .Image = item.Image,
                .NewPrice = item.NewPrice,
                .OldPrice = item.OldPrice
            }
            Me.HotProducts.Add(product)
        Next
    End Sub

    Private Sub GetNewProducts()
        Me.NewProducts = New List(Of GetProductList_Result)
        Dim numberOfNewProduct As Integer = ConfigurationManager.AppSettings(ChoMayTinh.Constants.AppSetting.NumberOfNewProduct)
        Dim result = context.Products.Where(Function(x) x.IsHomePage).OrderByDescending(Function(x) x.UdDate).Take(numberOfNewProduct).ToList()
        For Each item In result
            Dim product As New GetProductList_Result With {
                .Id = item.Id,
                .Name = item.Name,
                .ProductLink = item.Link,
                .MakerLink = context.Makers.Where(Function(x) x.Id = item.MakerId).FirstOrDefault().Link.ToString(),
                .CategoryLink = context.Categories.Where(Function(x) x.Id = item.CategoryId).FirstOrDefault().Link.ToString(),
                .Image = item.Image,
                .NewPrice = item.NewPrice,
                .OldPrice = item.OldPrice
            }
            Me.NewProducts.Add(product)
        Next
    End Sub

    Private Sub GetAdvertisement()
        Dim content As Content = context.Contents.Find(Constants.AppSetting.QuangCao)
        If content IsNot Nothing Then
            Me.Advertisement = content.Content1
        End If        
    End Sub

    Private Sub GetHotNews()
        Dim numberOfNewsInHomePage As Integer = ConfigurationManager.AppSettings(ChoMayTinh.Constants.AppSetting.NumberOfNewsInHomePage)
        Me.HotNews = context.News.OrderByDescending(Function(x) x.UdDate).Take(numberOfNewsInHomePage).ToList()
    End Sub

#End Region

End Class
