@Imports Chomaytinh
@ModelType ChoMayTinh.ProductListViewModel

@Code
    ViewData("Title") = ChoMayTinh.SharedFunc.PageTitle(Model.CategoryName & " - " & Model.MakerName)
    
    '' tổng số trang
    Dim NumbersOfPage As Integer
    If Model.ProductList IsNot Nothing Then
        NumbersOfPage = Math.Ceiling(Model.Total / Model.NumberItemPerPage)
    End If
End Code

<div class="product-path">
    <span>@Model.CategoryName</span> <i class="fa fa-angle-right"></i> <span>@Model.MakerName</span>
</div>


@If Model.ProductList Is Nothing OrElse Model.ProductList.Count = 0 Then
    @<h4 style="text-align:center;">Không có sản phẩm</h4>
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
    @<div style="clear:both;">
        @Html.Partial("_PaginationPartial", New ChoMayTinh.PaginationModel With {.IsUseURI = True, .PageURI = Url.Content("~/" & Model.CategoryLink & "/" & Model.MakerLink),
                                                                              .CurrentPage = Model.CurrentPage,
                                                                              .NumbersOfPage = NumbersOfPage})

    </div>

End If