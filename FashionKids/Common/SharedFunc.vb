Public Class SharedFunc
    Public Shared Function PageTitle(title As String) As String
        Return title & " - " & ConfigurationManager.AppSettings(Constants.AppSetting.Domain)
    End Function

    Public Shared Function FormatVnd(pNum As Decimal) As String
        Return Replace(Format(pNum, "#,##0"), ",", ".")
    End Function

    Public Shared Function NewGuid() As String
        Dim guid As Guid = guid.NewGuid
        Return guid.ToString.ToUpper.Replace("-", "")
    End Function

    Public Shared Function GetCartItemCount() As Integer
        Dim count As Integer = 0
        If HttpContext.Current.Session(SessionKeys.Cart) IsNot Nothing Then
            count = DirectCast(HttpContext.Current.Session(SessionKeys.Cart), List(Of CartModel)).Count
        End If

        Return count
    End Function

    ''' <summary>
    ''' Bỏ dấu tiếng việt
    ''' </summary>
    ''' <param name="pString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function TrimAccentedString(pString As String) As String
        Dim v_reg_regex As New Regex("\p{IsCombiningDiacriticalMarks}+")
        Dim v_str_FormD As String = pString.Normalize(NormalizationForm.FormD)
        Return v_reg_regex.Replace(v_str_FormD, [String].Empty).Replace("đ"c, "d"c).Replace("Đ"c, "D"c)
    End Function

    ''' <summary>
    ''' Thay thế các khoảng trắng liên tiếp thành 1 khoảng trắng
    ''' </summary>
    ''' <param name="pString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function TrimMultiWhiteSpace(pString As String) As String
        Dim regex As New Regex("\s+")
        Return regex.Replace(pString, " ")
    End Function

    ''' <summary>
    ''' Bỏ các ký tự đặc biệt
    ''' </summary>
    ''' <param name="pString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function TrimNonAlphaNumeric(pString As String) As String
        Dim regex As New Regex("[^a-zA-Z0-9 ]")
        Return regex.Replace(pString, "")
    End Function

    ''' <summary>
    ''' Tạo link
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateLink(name As String) As String
        Dim xProductName = name.Trim()
        Dim xLinkName = TrimAccentedString(xProductName)
        xLinkName = TrimNonAlphaNumeric(xLinkName)
        xLinkName = TrimMultiWhiteSpace(xLinkName)
        xLinkName = xLinkName.Trim().ToLower()
        xLinkName = xLinkName.Replace(" ", "-")

        Return xLinkName
    End Function
End Class
