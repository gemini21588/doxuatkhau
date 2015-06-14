<Authorize>
Public Class ManagementController
    Inherits System.Web.Mvc.Controller

    '
    ' GET: /Management

    Function Index() As ActionResult
        Return View()
    End Function

#Region "Category Maker"

    ''' <summary>
    ''' /Management/MenuLevel
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    ''' <remarks>Get</remarks>
    Function MenuLevel(id As Integer) As ActionResult
        Dim vm As New MenuLevelViewModel
        vm.GetMenuLevel(id)
        Return View(vm)
    End Function

    ''' <summary>
    ''' /Management/MenuLevel
    ''' </summary>
    ''' <param name="model"></param>
    ''' <returns></returns>
    ''' <remarks>Post</remarks>
    <HttpPost>
    <ValidateAntiForgeryToken>
    <ValidateInput(False)>
    Function MenuLevel(model As MenuLevelModel)
        Dim vm As New MenuLevelViewModel
        If Not model.IsDel Then
            vm.AddMenu(model)
        Else
            vm.DeleteMenuLevel(model)
        End If
        vm.GetMenuLevel(model.Level)
        Return View(vm)
    End Function
#End Region

#Region "Product"
    <ValidateInput(False)>
    Function ProductList(Optional mode As Integer = 0, Optional page As Integer = 1, Optional menuLevel1 As Integer = 0, Optional menuLevel2 As Integer = 0, Optional productName As String = "") As ActionResult
        Dim vm As New ManagementViewModel
        If mode = 0 Then
            vm.CurrentPage = page
            vm.GetProductList()
        Else
            If mode = 1 Then
                vm.Filter(menuLevel1, menuLevel2)
            Else
                vm.SearchProduct(productName)
            End If
        End If
        Return View(vm)
    End Function

    Function Product(Optional id As Integer = 0) As ActionResult
        Dim vm As New ProductDetailViewModel
        vm.Init(id)
        'If id <> vm.Product.Id Then
        '    Return RedirectToAction("ProductList")
        'End If
        Return View(vm)
    End Function

    <HttpPost>
    <ValidateAntiForgeryToken>
    <ValidateInput(False)>
    Function Product(model As ProductDetailViewModel) As ActionResult
        If model.Command = Constants.Command.Delete Then
            model.DeleteProduct()
        Else
            Dim hasError As Boolean = False
            If Not ModelState.IsValid Then
                If ModelState.IsValidField("Product.Name") Then
                    Dim errorMsg As String = model.CheckLink()
                    If errorMsg.Length > 0 Then
                        ModelState.AddModelError("Product.Name", errorMsg)
                    End If
                End If
                hasError = True
            Else
                Dim errorMsg As String = model.CheckLink()
                If errorMsg.Length > 0 Then
                    ModelState.AddModelError("Product.Name", errorMsg)
                    hasError = True
                End If
            End If
            If hasError Then
                model.InitForError()
                Return View(model)
            Else
                model.UpdateProduct()
            End If
        End If
        Return RedirectToAction("ProductList")
    End Function

#End Region

#Region "Cart"

    ''' <summary>
    ''' /Management/OrderList
    ''' </summary>
    ''' <param name="orderDate"></param>
    ''' <param name="page"></param>
    ''' <returns></returns>
    ''' <remarks>Get</remarks>
    <HttpGet>
    Function OrderList(Optional page As Integer = 1, Optional orderDate As String = "") As ActionResult
        Dim vm As New OrderListViewModel
        Dim dat As Date
        If orderDate <> String.Empty Then
            Dim ret = Date.TryParseExact(orderDate, "dd/MM/yyyy", Nothing, Nothing, dat)
            If ret Then
                vm.GetOrderList(dat)
            End If
        Else
            vm.CurrentPage = page
            vm.GetOrderList()
        End If
        Return View(vm)
    End Function

    ''' <summary>
    ''' /Management/OrderDetail
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    ''' <remarks>Get</remarks>
    Function OrderDetail(id As String)
        Dim vm As New OrderDetailViewModel
        vm.GetOrder(id)
        Return View(vm)
    End Function

#End Region

#Region "Slide Show"
    ''' <summary>
    ''' /Management/SlideShow
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>Get</remarks>
    Public Function SlideShow() As ActionResult
        Dim vm As New SlideShowViewModel()
        vm.GetSlideShow()
        Return View(vm)
    End Function

    ''' <summary>
    ''' /Management/SlideShow
    ''' </summary>
    ''' <param name="model"></param>
    ''' <param name="command"></param>
    ''' <returns></returns>
    ''' <remarks>Post</remarks>
    <HttpPost>
    <ValidateAntiForgeryToken>
    <ValidateInput(False)>
    Public Function SlideShow(model As SlideShow, Optional command As Constants.Command = Constants.Command.AddNew) As ActionResult
        Dim vm As New SlideShowViewModel
        vm.Update(model, command)
        vm.GetSlideShow()
        Return View(vm)
    End Function

#End Region

#Region "Editor"

    Function Editor(id As String) As ActionResult
        Dim vm As New EditorViewModel

        If ConfigurationManager.AppSettings(id) IsNot Nothing Then
            vm.GetContent(id)
        Else
            Return RedirectToAction("Index")
        End If

        Return View(vm)
    End Function

    <HttpPost>
    <ValidateInput(False)>
    <ValidateAntiForgeryToken>
    Function Editor(model As EditorViewModel) As ActionResult
        model.SaveContent()
        Return View(model)
    End Function

#End Region

#Region "News"

    Function News(Optional page As Integer = 1) As ActionResult
        Dim vm As New NewsViewModel()
        vm.CurrentPage = page
        vm.GetNewsList(True)
        ViewBag.IsNews = True
        Return View(vm)
    End Function

    Function NewsEdit(Optional id As String = "") As ActionResult
        Dim vm As New NewsViewModel
        vm.GetNews(id, True)
        'If vm.News.Id = 0 Then
        '    If id.Length > 0 Then
        '        Return RedirectToAction("News")
        '    End If
        'End If
        Return View(vm)
    End Function

    <HttpPost>
    <ValidateAntiForgeryToken>
    <ValidateInput(False)>
    Function NewsEdit(model As NewsViewModel, Optional command As Constants.Command = Constants.Command.AddNew) As ActionResult
        If command = Constants.Command.Delete Then
            model.DeleteNews()
        Else
            If ModelState.IsValid Then
                Dim errorMsg As String = model.CheckLink(True)
                If errorMsg.Length > 0 Then
                    ModelState.AddModelError("News.Title", errorMsg)
                    Return View(model)
                Else
                    model.SaveNews()
                End If
            Else
                Return View(model)
            End If
        End If
        Return RedirectToAction("News")
    End Function

#End Region

#Region "Promotion"

    Function Promotion(Optional page As Integer = 1) As ActionResult
        Dim vm As New NewsViewModel()
        vm.CurrentPage = page
        vm.GetNewsList(False)
        ViewBag.IsNews = False
        Return View("News", vm)
    End Function

    Function PromotionEdit(Optional id As String = "") As ActionResult
        Dim vm As New NewsViewModel
        vm.GetNews(id, False)
        If vm.News.Id = 0 Then
            If id.Length > 0 Then
                Return RedirectToAction("Promotion")
            End If
        End If
        Return View("NewsEdit", vm)
    End Function

    <HttpPost>
    <ValidateAntiForgeryToken>
    <ValidateInput(False)>
    Function PromotionEdit(model As NewsViewModel, Optional command As Constants.Command = Constants.Command.AddNew) As ActionResult
        If command = Constants.Command.Delete Then
            model.DeleteNews()
        Else
            If ModelState.IsValid Then
                Dim errorMsg As String = model.CheckLink(False)
                If errorMsg.Length > 0 Then
                    ModelState.AddModelError("News.Title", errorMsg)
                    Return View("NewsEdit", model)
                Else
                    model.SaveNews()
                End If
            Else
                Return View("NewsEdit", model)
            End If
        End If
        Return RedirectToAction("Promotion")
    End Function

#End Region

#Region "Keep Alive"

    Function KeepAlive(q As String) As ActionResult
        Return New EmptyResult
    End Function

#End Region
End Class