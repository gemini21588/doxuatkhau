'<OutputCache(NoStore:=True, Duration:=0, VaryByParam:="*")>
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Dim vm As New ViewModel()
        vm.LoadHomePageSetting()
        Return View(vm)
    End Function

    <ChildActionOnly>
    <OutputCache(Duration:=120)>
    Function Menu() As ActionResult
        Dim context As New siteEntities
        Dim menuList As List(Of GetMenu_Result)
        menuList = context.GetMenu().ToList()
        Return PartialView("~/Views/Home/_PartialMenu.vbhtml", menuList)
    End Function

    <ChildActionOnly>
    <OutputCache(Duration:=120)>
    Function Advertisement() As ActionResult
        Dim context As New siteEntities
        Dim content As Content = context.Contents.Find(Constants.AppSetting.QuangCao)
        Dim model As String = String.Empty
        If content IsNot Nothing Then
            model = content.Content1
        End If
        Return PartialView("~/Views/Home/_PartialAdvertisement.vbhtml", model)
    End Function

    Function ContentPage(link As String) As ActionResult
        Dim vm As New ContentPageViewModel
        vm.GetContent(link)
        Return View(vm)
    End Function

    Function ProductList(ByVal pCategory As String, ByVal pMaker As String, Optional pCurrentPage As Integer = 1) As ActionResult
        Dim model As New ProductListViewModel(pCategory, pMaker, pCurrentPage)
        If model.ProductList Is Nothing Then
            Throw New HttpException(404, "")
        End If
        Return View(model)
    End Function

    Function SearchProduct(ByVal q As String) As ActionResult
        Dim model As New SearchViewModel(q)
        If q.Length > 0 Then
            model.SearchProduct()
        End If
        Return View(model)
    End Function

    Function Product(ByVal pCategory As String, ByVal pMaker As String, ByVal pProduct As String)
        Dim model As New ProductViewModel(pCategory, pMaker, pProduct)
        If model.Product Is Nothing Then
            Throw New HttpException(404, "")
        End If
        Return View(model)
    End Function

    Function NewsList(Optional page As Integer = 1) As ActionResult
        Dim model As New NewsListViewModel()
        model.CurrentPage = page
        model.LoadNewsList(True)
        ViewBag.IsNews = True
        If model.NewsList Is Nothing Then
            Throw New HttpException(404, "")
        End If
        Return View(model)
    End Function

    Function PromotionList(Optional page As Integer = 1) As ActionResult
        Dim model As New NewsListViewModel()
        model.CurrentPage = page
        model.LoadNewsList(False)
        ViewBag.IsNews = False
        If model.NewsList Is Nothing Then
            Throw New HttpException(404, "")
        End If
        Return View("NewsList", model)
    End Function

    Function NewsDetail(ByVal link As String) As ActionResult
        Dim model As New NewsDetailViewModel()
        model.GetNews(True, link)
        ViewBag.IsNews = True
        If model.NewsDetail Is Nothing Then
            Throw New HttpException(404, "")
        End If
        Return View(model)
    End Function

    Function PromotionDetail(ByVal link As String) As ActionResult
        Dim model As New NewsDetailViewModel()
        model.GetNews(False, link)
        ViewBag.IsNews = False
        If model.NewsDetail Is Nothing Then
            Throw New HttpException(404, "")
        End If
        Return View("NewsDetail", model)
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your app description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function

#Region "Shopping cart"
    ''' <summary>
    ''' Home/AddToCart
    ''' </summary>
    ''' <param name="productId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AddToCart(productId As Integer) As ActionResult
        Dim vm As New CartListViewModel(True)
        vm.AddToCart(productId)
        Return RedirectToRoute(Constants.Route.GioHang)
    End Function

    ''' <summary>
    ''' Home/CartList
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CartList() As ActionResult
        Dim vm As New CartListViewModel
        Return View(vm)
    End Function

    ''' <summary>
    ''' Home/UpdateQuantity
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="quantity"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <HttpPost>
    <ValidateAntiForgeryToken>
    Function UpdateQuantity(id As Integer, quantity As Integer) As ActionResult
        Dim vm As New CartListViewModel(True)
        vm.UpdateQuantity(id, quantity)
        Return RedirectToRoute(Constants.Route.GioHang)
    End Function

    ''' <summary>
    ''' Home/DeleteCartItem
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <HttpPost>
    <ValidateAntiForgeryToken>
    Function DeleteCartItem(id As Integer) As ActionResult
        Dim vm As New CartListViewModel(True)
        vm.DeleteCartItem(id)
        Return RedirectToRoute(Constants.Route.GioHang)
    End Function

    ''' <summary>
    ''' Home/Order
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Order() As ActionResult
        If SharedFunc.GetCartItemCount() > 0 Then
            Dim vm As New OrderViewModel
            Return View(vm)
        Else
            Return RedirectToRoute(Constants.Route.GioHang)
        End If
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <HttpPost>
    <ValidateAntiForgeryToken>
    <ValidateInput(False)>
    Function Order(model As Order) As ActionResult
        Dim count As Integer = 0
        If Session(SessionKeys.Cart) IsNot Nothing Then
            count = DirectCast(Session(SessionKeys.Cart), List(Of CartModel)).Count
        End If
        If count > 0 Then
            Dim vm As New OrderViewModel(True)
            vm.AddOrder(model)
        End If
        Return RedirectToAction("Index")
    End Function
#End Region

#Region "Keep Alive"

    Function KeepAlive(q As String) As ActionResult
        Return New EmptyResult
    End Function

#End Region
End Class
