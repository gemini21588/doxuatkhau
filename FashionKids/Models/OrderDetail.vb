'------------------------------------------------------------------------------
' <auto-generated>
'    This code was generated from a template.
'
'    Manual changes to this file may cause unexpected behavior in your application.
'    Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class OrderDetail
    Public Property Guid As String
    Public Property Id As Integer
    Public Property ProductId As Nullable(Of Integer)
    Public Property Quantity As Nullable(Of Integer)

    Public Overridable Property Order As Order
    Public Overridable Property Product As Product

End Class
