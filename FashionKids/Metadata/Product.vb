Imports System.ComponentModel.DataAnnotations

<MetadataType(GetType(Product.ProductMetadata))>
Partial Public Class Product
    Public Class ProductMetadata
        <Required(ErrorMessage:="Tên sản phẩm không được rỗng.")>        
        Public Property Name As String

        <Required(ErrorMessage:="Hình ảnh không được rỗng.")>
        Public Property Image As String
    End Class
End Class
