Imports System.Linq.Expressions

Public NotInheritable Class PropertyHelper(Of TInstance)    
    Private Sub New()
    End Sub

    Public Shared Function GetName(Of TMember)(ByVal propertyExpression As Expression(Of Func(Of TInstance, TMember))) As String
        Return DirectCast(propertyExpression.Body, MemberExpression).Member.Name
    End Function

End Class