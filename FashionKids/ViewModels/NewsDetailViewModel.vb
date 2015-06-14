Imports System.ComponentModel.DataAnnotations

Public Class NewsDetailViewModel
    Inherits ViewModel

#Region "Constructors"

    Public Sub New()
    End Sub

#End Region

#Region "Properties"

    Public Property NewsDetail As News

#End Region

#Region "Methods"

    Public Sub GetNews(ByVal isNews As Boolean, ByVal link As String)
        Using context As New siteEntities
            context.Configuration.LazyLoadingEnabled = False
            Me.NewsDetail = context.News.Where(Function(x) x.IsNews = isNews And x.Link = link).FirstOrDefault()
            If Me.NewsDetail IsNot Nothing Then
                Me.Keywords = Me.NewsDetail.Title
            End If
        End Using
    End Sub

#End Region

End Class
