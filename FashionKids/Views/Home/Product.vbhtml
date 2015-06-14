@Imports Chomaytinh
@ModelType ChoMayTinh.ProductViewModel

@Code
    Dim title = Model.CategoryName & " - " & Model.MakerName & " - " & Model.Product.Name
    ViewData("Title") = ChoMayTinh.SharedFunc.PageTitle(title)
End Code

@If Model.Product Is Nothing Then
    Return
End If

<div class="product-path">
    <span>@Model.CategoryName</span> <i class="fa fa-angle-right"></i> <span>@Model.MakerName</span>
</div>

<h4 class="margin-left">
    @Model.Product.Name
</h4>

<ul id="Product">
    <li class="product-img">
        <img src="@Model.Product.Image" />
    </li>
    <li class="product-info">
        <div class="product-detail-title">
            THÔNG TIN SẢN PHẨM
        </div>
        <table class="table">
            <colgroup>
                <col style="width: 130px" />
                <col />
            </colgroup>
            <tr>
                <td>Màu sắc</td>
                <td>: @Model.Product.Color</td>
            </tr>
            <tr>
                <td>Size</td>
                <td>: @Model.Product.Size</td>
            </tr>
            <tr>
                <td>Tình trạng</td>
                <td>: @Model.Product.Condition</td>
            </tr>
            <tr>
                <td>Xuất xứ</td> 
                <td>: @Model.Product.Origin</td>
            </tr>
            <tr>
                <td>Giá</td>
                <td>: <span class="price">@SharedFunc.FormatVnd(Model.Product.NewPrice)<sup>đ</sup></span></td>
            </tr>
        </table>
        <div class="btn-add-to-cart">
            <a class="btn btn-primary btn-large pull-left" href='~/Home/AddToCart?productId=@Model.Product.Id'><i class="fa fa-shopping-cart"></i>&nbsp;Thêm vào giỏ hàng</a>
        </div>        
    </li>
</ul>
<div class="pull-right">
            @Html.Partial("~/Views/Shared/_SocialPartial.vbhtml")
        </div>
<div class="product-detail-title margin-left margin-top" style="clear:both;">
    THÔNG TIN CHI TIẾT
</div>

<div class="product-detail margin-left">
    @Html.Raw(Model.Product.Info)
</div>

@If Model.ProductListSameType IsNot Nothing AndAlso Model.ProductListSameType.Count > 0 Then
    @<div class="cmt-title margin-top margin-left clear margin-bottom">
        SẢN PHẨM CÙNG LOẠI
    </div>
    @<ul id="ProductListSameType">
    @For Each item In Model.ProductListSameType
        
            @<li>                                
                <a class="product-img" href="@Url.Content("~/" & Model.CategoryLink & "/" & Model.MakerLink & "/" & item.Link & "/") ">
                    <img src="@item.Image" />
                </a>                
                <div class="product-name">@item.Name</div>
                <div class="product-price">@SharedFunc.FormatVnd(item.NewPrice)<sup>đ</sup></div>
                <a class="btn pull-right" href="~/Home/AddToCart?productId=@item.Id"><i class="fa fa-shopping-cart"></i></a>
            </li>
        
    Next
    </ul>
End If