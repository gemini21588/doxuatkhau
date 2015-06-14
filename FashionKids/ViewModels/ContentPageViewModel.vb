Public Class ContentPageViewModel
    Inherits ViewModel

#Region "Private members"

    Private context As siteEntities

#End Region

#Region "Constructors"

    Public Sub New()
        MyBase.New()
        context = New siteEntities
        context.Configuration.LazyLoadingEnabled = False
    End Sub

#End Region

#Region "Properties"

    Public Property Content As Content

#End Region

#Region "Methods"

    Public Sub GetContent(link As String)

        Content = context.Contents.Find(link)

    End Sub

#End Region

End Class
