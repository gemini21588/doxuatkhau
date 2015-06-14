@Imports Chomaytinh
@ModelType ChoMayTinh.SearchViewModel

@Code
    ViewData("Title") = ChoMayTinh.SharedFunc.PageTitle(Model.TextSearch)
End Code

<div class="product-path">
    <span>Bạn đang tìm kiếm với từ khóa "@Model.TextSearch"</span>
</div>


@If Model.ProductList Is Nothing OrElse Model.ProductList.Count = 0 Then
    @<h4 style="text-align:center;">Không tìm thấy sản phẩm nào.</h4>
Else
    @<ul id="ProductList">
    @For Each item In Model.ProductList
        
            @<li>
                <a class="product-img" href="@Url.Content("~/" & item.CategoryLink & "/" & item.MakerLink & "/" & item.ProductLink & "/") ">
                    <img src="@item.Image" />
                </a>
                <div class="product-name">@item.Name</div>
                <div class="product-price">@SharedFunc.FormatVnd(item.NewPrice)<sup>đ</sup></div>
                <a class="btn pull-right" href="~/Home/AddToCart?productId=@item.Id"><i class="fa fa-shopping-cart"></i></a>
            </li>
        
    Next
    </ul>
End If