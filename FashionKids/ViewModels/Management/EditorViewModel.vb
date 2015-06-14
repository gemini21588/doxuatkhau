Public Class EditorViewModel

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

    Public Property Content As Content

#End Region

#Region "Methods"

    Public Sub GetContent(id As String)
        Me.Content = context.Contents.Find(id)
        If Me.Content Is Nothing Then
            Dim title As String = ConfigurationManager.AppSettings(id)
            Me.Content = New Content With {.Id = id, .Title = title, .Content1 = String.Empty}
            context.Entry(Me.Content).State = EntityState.Added
            context.SaveChanges()            
        End If
    End Sub

    Public Sub SaveContent()
        context.Contents.Attach(Me.Content)
        context.Entry(Me.Content).Property(Function(x) x.Content1).IsModified = True
        context.SaveChanges()
    End Sub

#End Region

End Class
