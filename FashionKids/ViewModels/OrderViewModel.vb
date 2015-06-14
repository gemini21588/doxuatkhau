Imports System.ComponentModel.DataAnnotations

Public Class OrderViewModel
    Inherits ViewModel

#Region "Constructors"

    Public Sub New(Optional isPostBack As Boolean = False)
        MyBase.New(isPostBack)
        Me.Robots = Constants.NoIndexNoFollow
    End Sub

#End Region

#Region "Properties"
    <Display(Name:="Họ tên")>
    <Required(ErrorMessage:="Họ tên không được phép rỗng")>
    Public Property CustomerName As String

    <Display(Name:="Số điện thoại")>
    <Required(ErrorMessage:="Số điện thoại không được phép rỗng")>
    Public Property Tel As String

    <Display(Name:="Địa chỉ")>
    <Required(ErrorMessage:="Địa chỉ không được phép rỗng")>
    Public Property Address As String

    <Display(Name:="Ghi chú")>
    Public Property Note As String

#End Region

#Region "Methods"

    Public Sub AddOrder(model As Order)
        Using context As New siteEntities
            context.Configuration.LazyLoadingEnabled = False

            model.Guid = SharedFunc.NewGuid
            model.IsProcessed = False
            model.AdDate = Date.Now()
            model.UdDate = model.AdDate

            context.Orders.Add(model)

            Dim cartList As List(Of CartModel) = HttpContext.Current.Session(SessionKeys.Cart)

            Dim idx As Integer = 1
            For Each item In cartList
                Dim orderItem As New OrderDetail With {
                    .Guid = model.Guid,
                    .Id = idx,
                    .ProductId = item.Id,
                    .Quantity = item.Quantity
                    }
                context.OrderDetails.Add(orderItem)
                idx = idx + 1
            Next

            context.SaveChanges()

            cartList = Nothing
            HttpContext.Current.Session(SessionKeys.Cart) = Nothing

        End Using
    End Sub

#End Region

End Class
