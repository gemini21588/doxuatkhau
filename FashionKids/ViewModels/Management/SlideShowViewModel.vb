Public Class SlideShowViewModel

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

    Public Property SlideShow As List(Of SlideShow)

    Public Property SlideShowItem As SlideShow

#End Region

#Region "Methods"

    Public Sub GetSlideShow()
        Me.SlideShow = context.SlideShows.ToList()
    End Sub

    Public Sub Update(model As SlideShow, command As Constants.Command)
        Select Case command
            Case Constants.Command.AddNew
                context.Entry(model).State = EntityState.Added
            Case Constants.Command.Update
                Dim item = context.SlideShows.Find(model.Id)
                If item Is Nothing AndAlso model.Id <> 0 Then
                    context.Entry(model).State = EntityState.Added
                Else
                    context.Entry(item).CurrentValues.SetValues(model)
                End If
            Case Constants.Command.Delete
                Dim item = context.SlideShows.Find(model.Id)
                If item IsNot Nothing Then
                    context.Entry(item).State = EntityState.Deleted
                End If                
        End Select

        context.SaveChanges()
    End Sub

#End Region

End Class
