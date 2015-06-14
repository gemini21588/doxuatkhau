Public Class NewsViewModel
#Region "Private members"

    Private context As siteEntities

#End Region

#Region "Constructors"

    Public Sub New()
        context = New siteEntities
        context.Configuration.LazyLoadingEnabled = False
    End Sub

#End Region

#Region "Properties"

    Public Property NewsList As List(Of News)

    Public Property News As News

    Public Property CurrentPage As Integer = 1

    Public Property Total As Integer = 0

    Public Property NumberItemPerPage As Integer = 0

    Public Property Link As String = String.Empty

#End Region

#Region "Methods"

    Public Sub GetNewsList(isNew As Boolean)
        Me.Total = context.News.Where(Function(x) x.IsNews = isNew).Count
        Me.NumberItemPerPage = CInt(ConfigurationManager.AppSettings(Constants.AppSetting.ItemPerPage))
        Me.NewsList = context.News.Where(Function(x) x.IsNews = isNew).OrderByDescending(Function(x) x.UdDate).Skip(NumberItemPerPage * (CurrentPage - 1)).Take(NumberItemPerPage).ToList()
    End Sub

    Public Sub GetNews(link As String, isNews As Boolean)
        Me.Link = link
        Me.News = context.News.Where(Function(x) x.Link = link AndAlso x.IsNews = isNews).FirstOrDefault
        If Me.News Is Nothing Then
            Me.News = New News
            Me.News.Id = 0
            Me.News.IsNews = isNews
        End If
    End Sub

    Public Sub SaveNews()
        Dim dat As Date = Date.Now

        Me.News.UdDate = dat
        Me.News.Link = SharedFunc.CreateLink(Me.News.Title)

        If Me.News.Id = 0 Then
            Me.News.AdDate = dat            
            context.Entry(Me.News).State = EntityState.Added
        Else            
            Dim item = context.News.Find(Me.News.Id)
            If item Is Nothing Then
                context.News.Add(Me.News)
            Else
                context.Entry(item).CurrentValues.SetValues(Me.News)
            End If
        End If
        context.SaveChanges()
    End Sub

    Public Sub DeleteNews()
        Dim item = context.News.Find(Me.News.Id)
        If item IsNot Nothing Then
            context.News.Remove(item)
            context.SaveChanges()
        End If        
    End Sub

    Public Function CheckLink(isNews As Boolean) As String
        Dim errorMsg As String = String.Empty
        Dim link As String = SharedFunc.CreateLink(Me.News.Title)
        If link <> String.Empty Then
            Dim item As News = context.News.Where(Function(x) x.Link = link AndAlso x.IsNews = isNews).FirstOrDefault
            If item IsNot Nothing Then
                If item.Id <> Me.News.Id Then
                    errorMsg = "Tên bạn nhập đã tồn tại. Vui lòng nhập tên khác."
                End If
                context.Entry(item).State = EntityState.Detached
            End If
        Else
            errorMsg = "Tên bạn nhập không hợp lệ. Vui lòng nhập tên khác."
        End If

        Return errorMsg
    End Function

#End Region
End Class
