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

Partial Public Class Order
    Public Property Guid As String
    Public Property CustomerName As String
    Public Property Tel As String
    Public Property Address As String
    Public Property Note As String
    Public Property IsProcessed As Nullable(Of Boolean)
    Public Property AdDate As Date
    Public Property UdDate As Date

    Public Overridable Property OrderDetails As ICollection(Of OrderDetail) = New HashSet(Of OrderDetail)

End Class
