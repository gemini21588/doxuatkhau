Imports System.ComponentModel.DataAnnotations

Public Class NewsListViewModel
    Inherits ViewModel

#Region "Constructors"

    Public Sub New()
    End Sub

#End Region

#Region "Properties"

    Public Property NewsList As List(Of News)

    Public Property CurrentPage As Integer = 1

    Public Property Total As Integer = 0

    Public Property NumberItemPerPage As Integer = 0

#End Region

#Region "Methods"

    Public Sub LoadNewsList(ByVal isNews As Boolean)
        Using context As New siteEntities
            context.Configuration.LazyLoadingEnabled = False
            Me.Total = context.News.Where(Function(x) x.IsNews = isNews).Count
            Me.NumberItemPerPage = CInt(ConfigurationManager.AppSettings(Constants.AppSetting.NewsPerPage))
            Me.NewsList = context.News.Where(Function(x) x.IsNews = isNews).OrderByDescending(Function(x) x.UdDate).Skip(NumberItemPerPage * (CurrentPage - 1)).Take(NumberItemPerPage).ToList()
        End Using
    End Sub

#End Region

End Class
