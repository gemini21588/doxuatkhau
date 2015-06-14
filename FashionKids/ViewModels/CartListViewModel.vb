Public Class CartListViewModel
    Inherits ViewModel

#Region "Constructors"

    Public Sub New(Optional isPostBack As Boolean = False)
        MyBase.New(isPostBack)
        Me.Robots = Constants.NoIndexNoFollow
        Me.GetCartList()
    End Sub

#End Region

#Region "Properties"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CartList As List(Of CartModel)

#End Region

#Region "Methods"

    ''' <summary>
    ''' GetCartList
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub GetCartList()
        '' get doi tuong cart tu session
        CartList = HttpContext.Current.Session(SessionKeys.Cart)

        '' truong hop cart chua ton tai thi tao moi
        If CartList Is Nothing Then
            CartList = New List(Of CartModel)
            HttpContext.Current.Session(SessionKeys.Cart) = CartList
        End If
    End Sub

    ''' <summary>
    ''' AddToCart
    ''' </summary>
    ''' <param name="productId"></param>
    ''' <remarks></remarks>
    Public Sub AddToCart(productId As Integer)

        '' kiem tra id san pham da ton tai trong cart hay chua
        Dim id = CartList.Where(Function(x) x.Id = productId)

        '' neu id san pham chua ton tai trong cart thi add san pham vao cart
        If id.Count = 0 Then
            Using context As New siteEntities
                context.Configuration.LazyLoadingEnabled = False
                Dim cartItem = context.Products.Where(Function(x) x.Id = productId).Select(Function(x) New CartModel With {
                                                                                .Id = x.Id,
                                                                                .Link = x.Link,
                                                                                .CategoryLink = x.Category.Link,
                                                                                .MakerLink = x.Maker.Link,
                                                                                .Image = x.Image,
                                                                                .Name = x.Name,
                                                                                .Price = x.NewPrice,
                                                                                .Quantity = 1
                                                                                }).FirstOrDefault()

                CartList.Add(cartItem)
            End Using
        End If
    End Sub

    ''' <summary>
    ''' UpdateQuantity
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="quantity"></param>
    ''' <remarks></remarks>
    Public Sub UpdateQuantity(id As Integer, quantity As Integer)
        Dim cartItem = CartList.Where(Function(x) x.Id = id).FirstOrDefault
        If cartItem Is Nothing Then
            Exit Sub
        End If

        If quantity = 0 Then
            CartList.Remove(cartItem)
        Else
            cartItem.Quantity = quantity
        End If
    End Sub

    ''' <summary>
    ''' DeleteCartItem
    ''' </summary>
    ''' <param name="id"></param>
    ''' <remarks></remarks>
    Public Sub DeleteCartItem(id As Integer)
        Dim cartItem = CartList.Where(Function(x) x.Id = id).FirstOrDefault
        CartList.Remove(cartItem)
    End Sub
#End Region

End Class
