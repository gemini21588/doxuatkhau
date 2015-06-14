@ModelType ChoMayTinh.NewsViewModel

@Code
    Dim title As String
    If ViewBag.IsNews Then
        title = "Danh sách tin tức"
    Else
        title = "Danh sách tin khuyến mãi"
    End If
    
    ViewData("Title") = title
    Layout = "~/Views/Shared/_LayoutManagement.vbhtml"
    
    '' tổng số trang
    Dim NumbersOfPage As Integer
    If Model.NewsList IsNot Nothing AndAlso Model.NumberItemPerPage > 0 Then
        NumbersOfPage = Math.Ceiling(Model.Total / Model.NumberItemPerPage)
    End If
    
    Dim idx As Integer = 1
End Code

<h2>@title</h2>

@If Model Is Nothing Then
    Return
End If

@Section LeftColumn
    <div class="btn-function">        
        <button class="btn" type="button" onclick="window.location.href='@Url.Action(If(ViewBag.IsNews, "NewsEdit", "PromotionEdit"), "Management")'"><i class="fa fa-plus"></i>&nbsp;Soạn tin mới</button>      
    </div>
End Section

<div>
    @Html.Partial("_PaginationPartial", New ChoMayTinh.PaginationModel With {.Controller = "Management", .Action = If(ViewBag.IsNews, "News", "Promotion"), 
                                                                              .CurrentPage = Model.CurrentPage, 
                                                                              .NumbersOfPage = NumbersOfPage})
</div>

<table class="table table-striped">
    <colgroup>
        <col style="width: 40px" />
        <col style="width: 560px" />    
    </colgroup>

    <thead>
        <tr>
            <td>#</td>
            <td>Tiêu đề</td>
            <td>Ngày đăng</td>
        </tr>
    </thead>
    <tbody>
        @For Each item In Model.NewsList
            @<tr>
                <td>@idx</td>
                <td><a href="@Url.Action(if(item.IsNews, "NewsEdit", "PromotionEdit"), "Management", New With {.id = item.Link})">@item.Title</a></td>
                <td>@item.AdDate</td>
             </tr>
            @code
            idx = idx + 1
            End Code
        Next
    </tbody>
</table>