Imports System.ComponentModel.DataAnnotations

<MetadataType(GetType(News.NewsMetadate))>
Partial Public Class News
    Public Class NewsMetadate
        <Required(ErrorMessage:="Tiêu đề không được rỗng")>        
        Public Property Title As String
    End Class
End Class
