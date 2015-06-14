@Imports Chomaytinh
@ModelType ChoMayTinh.NewsListViewModel

@Code
    
    Dim title As String
    If ViewBag.IsNews Then
        title = "Tin thời trang"
    Else
        title = "Tin khuyến mãi"
    End If
    
    ViewData("Title") = ChoMayTinh.SharedFunc.PageTitle(title)
    
    '' tổng số trang
    Dim NumbersOfPage As Integer
    If Model.NewsList IsNot Nothing Then
        NumbersOfPage = Math.Ceiling(Model.Total / Model.NumberItemPerPage)
    End If
End Code

@If Model.NewsList Is Nothing OrElse Model.NewsList.Count = 0 Then
    @<h4 style="text-align:center;">Không có tin tức.</h4>
Else
    For Each item In Model.NewsList
        @<ul id="NewsList">
            <li class="news-item">
                <img class="news-img" src="@item.Image" alt="@item.Title" />
                <div class="news-info">
                    <a class="news-title" href="@Url.Content("~/" & If(item.IsNews, ChoMayTinh.Constants.Route.TinTucRoute, ChoMayTinh.Constants.Route.KhuyenMaiRoute) & "/" & item.Link)/">@item.Title</a>
                    <p class="news-date">@item.UdDate</p>
                    <div class="news-summary">@item.Summary</div>
                </div>
            </li>
        </ul>
Next
    @<div style="clear:both;">
        @Html.Partial("_PaginationPartial", New ChoMayTinh.PaginationModel With {.Controller = "Home", .Action = If(ViewBag.IsNews, "NewsList", "PromotionList"),
                                                                              .CurrentPage = Model.CurrentPage,
                                                                              .NumbersOfPage = NumbersOfPage})

    </div>

End If