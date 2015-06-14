@Imports Chomaytinh
@ModelType ChoMayTinh.NewsDetailViewModel

@Code
    ViewData("Title") = ChoMayTinh.SharedFunc.PageTitle(Model.NewsDetail.Title)
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<div id="NewsDetail">
    <h3>@Model.NewsDetail.Title</h3>
    <p class="news-date">@Model.NewsDetail.UdDate</p>
    <div class="news-content">
        @Html.Raw(Model.NewsDetail.Content)
    </div>
</div>

<div class="pull-right">
    @Html.Partial("~/Views/Shared/_SocialPartial.vbhtml")
</div>