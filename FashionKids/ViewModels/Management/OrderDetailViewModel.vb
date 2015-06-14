Imports System.Data.Entity

Public Class OrderDetailViewModel

#Region "Private members"

    ''' <summary>
    ''' entity instance
    ''' </summary>
    ''' <remarks></remarks>
    Private context As siteEntities

#End Region

#Region "Constructors"
    ''' <summary>
    ''' New
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        context = New siteEntities
        context.Configuration.LazyLoadingEnabled = False
    End Sub

#End Region

#Region "Properties"
    Public Property OrderInfo As Order
#End Region

#Region "Methods"

    ''' <summary>
    ''' Get thông tin order và danh sách order
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub GetOrder(guid As String)
        Me.OrderInfo = context.Orders.Where(Function(x) x.Guid = guid).Include(Function(x) x.OrderDetails.Select(Function(p) p.Product)).FirstOrDefault
    End Sub
#End Region

End Class
