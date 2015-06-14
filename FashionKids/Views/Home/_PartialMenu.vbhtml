@modeltype List(Of ChoMayTinh.GetMenu_Result)

<div id="MenuProductList">
    @Code
        Dim menuList As List(Of ChoMayTinh.GetMenu_Result) = Model
        Dim current As String = String.Empty
        Dim i As Integer = 0
    End Code
    @While i < menuList.Count
        If menuList(i).CategoryLink <> current Then
        @Code
            current = menuList(i).CategoryLink
        End Code                            
        @<h3>@menuList(i).CategoryName</h3>                            
        End If
        @<ul>
            @While i < menuList.Count AndAlso menuList(i).CategoryLink = current
                @<li><a href="@Url.RouteUrl(ChoMayTinh.Constants.Route.DanhSachSanPham,
                                                            New With {.pCategory = menuList(i).CategoryLink,
                                                                      .pMaker = menuList(i).MakerLink,
                                                                      .pCurrentPage = 1})"><i class="fa fa-angle-right"></i>&nbsp;@menuList(i).MakerName</a></li>
                @Code
            i = i + 1
                End Code
        End While
        </ul>
    End While
</div>
