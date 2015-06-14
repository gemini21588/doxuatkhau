Public Class OrderListViewModel

    Private context As siteEntities

#Region "Constructors"

    Public Sub New()
        context = New siteEntities
        context.Configuration.LazyLoadingEnabled = False
    End Sub

#End Region

#Region "Properties"

    Public Property OrderList As List(Of Order)

    Public Property CurrentPage As Integer = 1

    Public Property Total As Integer = 0

    Public Property NumberItemPerPage As Integer = 0

    Public Property OrderDate As Date = Date.Now

#End Region

#Region "Methods"

    Public Sub GetOrderList(Optional orderDate As Date = Nothing)
        If orderDate = Nothing Then
            Me.Total = context.Orders.Count
            Me.NumberItemPerPage = CInt(ConfigurationManager.AppSettings(Constants.AppSetting.ItemPerPage))
            Me.OrderList = context.Orders.OrderByDescending(Function(x) x.AdDate).Skip(NumberItemPerPage * (CurrentPage - 1)).Take(NumberItemPerPage).ToList()
        Else
            Dim startDate As Date = DateSerial(orderDate.Year, orderDate.Month, orderDate.Day)
            Dim endDate As Date = startDate.AddDays(1)

            Me.OrderList = context.Orders.Where(Function(x) x.AdDate >= startDate AndAlso x.AdDate < endDate).OrderByDescending(Function(x) x.AdDate).ToList()
            Me.NumberItemPerPage = 1
            Me.OrderDate = orderDate
        End If
    End Sub

#End Region

End Class