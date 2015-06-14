@ModelType ChoMayTinh.ViewModel

@Code
    ViewData("Title") = ChoMayTinh.SharedFunc.PageTitle("Trang chủ")
End Code

@*<div id="sliderFrame">
    <div id="slider">
        @For Each item In Model.SlideShow
            If item.Link IsNot Nothing AndAlso item.Link.Length > 0 Then
            @<a href="@Html.Raw(item.Link)" target="_blank">
                <img src="@item.Image" />
            </a>    
            Else
            @<img src="@item.Image" />
            End If
        Next
    </div>
</div>*@

@If Model.HotProducts IsNot Nothing AndAlso Model.HotProducts.Count > 0 Then
    @<div class="cmt-title margin-top margin-left clear margin-bottom" style="margin-top:5px !important;">
        SẢN PHẨM KHUYẾN MÃI
    </div>
    @<ul id="HotProducts">
    @For Each item In Model.HotProducts
        @<li>
            <a class="product-img" href="@Url.Content("~/" & item.CategoryLink & "/" & item.MakerLink & "/" & item.ProductLink & "/") ">
                <img src="@item.Image" />
            </a>
            <div class="product-name">@item.Name</div>
            <div class="product-price">
                @ChoMayTinh.SharedFunc.FormatVnd(item.NewPrice)<sup>đ</sup>
                @If item.OldPrice IsNot Nothing AndAlso item.OldPrice > 0 Then
                    @<span class="product-old-price">@ChoMayTinh.SharedFunc.FormatVnd(item.OldPrice)<sup>đ</sup></span>
                End If
            </div>
            <a class="btn pull-right" href="~/Home/AddToCart?productId=@item.Id"><i class="fa fa-shopping-cart"></i></a>
        </li>
    Next
    </ul>
End If

@If Model.NewProducts IsNot Nothing AndAlso Model.NewProducts.Count > 0 Then
    @<div class="cmt-title margin-top margin-left margin-bottom clear">
        SẢN PHẨM MỚI
    </div>
    @<ul id="NewProducts">
    @For Each item In Model.NewProducts
        @<li>
            <a class="product-img" href="@Url.Content("~/" & item.CategoryLink & "/" & item.MakerLink & "/" & item.ProductLink & "/") ">
                <img src="@item.Image" />
            </a>
            <div class="product-name">@item.Name</div>
            <div class="product-price">@ChoMayTinh.SharedFunc.FormatVnd(item.NewPrice)<sup>đ</sup></div>
            <a class="btn pull-right" href="~/Home/AddToCart?productId=@item.Id"><i class="fa fa-shopping-cart"></i></a>
        </li>
    Next
    </ul>
End if

@If Model.HotNews IsNot Nothing AndAlso Model.HotNews.Count > 0 Then
    @<div class="cmt-title margin-top margin-left margin-bottom clear">
        TIN MỚI NHẤT
    </div>
    @<ul id="HotNews">
    @For Each item In Model.HotNews
        @<li>
            <img class="news-img" src="@item.Image" alt="@item.Title" />
            <a class="news-title" href="@Url.Content("~/" & If(item.IsNews, ChoMayTinh.Constants.Route.TinTucRoute, ChoMayTinh.Constants.Route.KhuyenMaiRoute) & "/" & item.Link)">@item.Title</a>
            <div class="news-date">@item.UdDate</div>
        </li>
    Next
    </ul>
End if

