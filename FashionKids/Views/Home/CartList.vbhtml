@Imports Chomaytinh
@ModelType ChoMayTinh.CartListViewModel

@Code
    ViewData("Title") = SharedFunc.PageTitle("Giỏ hàng")
End Code

<div id="cartList">
    <h3><i class="fa fa-shopping-cart"></i>&nbsp;Giỏ hàng</h3>

    @If Model.CartList.Count = 0 Then
        @<h4 style="text-align: center;">Quý khách chưa có sản phẩm nào trong giỏ hàng.</h4>
        Return
    End If


    <table id="cart-list">
        <colgroup>
            <col style="width: 190px;" />
            <col style="width: 260px;" />
            <col style="width: 100px;" />
            <col style="width: 100px;" />
            <col style="width: 100px;" />
        </colgroup>
        <thead>
            <tr>
                <th>Hình ảnh</th>
                <th>Tên sản phẩm</th>
                <th>Số lượng</th>
                <th>Đơn giá (VNĐ)</th>
                <th>Tổng tiền (VNĐ)</th>
            </tr>
        </thead>
        @For Each item In Model.CartList
            @<tr>
                <td class="cart-image">
                    <a href="~/@item.CategoryLink/@item.MakerLink/@item.Link" title="@item.Name">
                        <img src="@item.Image" title="@item.Name" alt="@item.Name" />
                    </a>
                </td>
                <td class="cart-name">
                    <a href="~/@item.CategoryLink/@item.MakerLink/@item.Link" title="@item.Name">
                        <span>@item.Name</span><br />
                    </a>
                    <br />
                    @Using Html.BeginForm("DeleteCartItem", "Home", Nothing, FormMethod.Post, New With {.id = "frmDelCartItem" & item.Id})
                        @Html.AntiForgeryToken()
                        @<input name="id" value="@item.Id" type="hidden" />                    
            End Using
                    <button type="button" onclick="DeleteCartItem('@("#frmDelCartItem" & item.Id)');" class="btn btn-danger"><i class="fa fa-times"></i>&nbsp;Xóa</button>
                </td>
                <td class="cart-quantity">
                    @Using Html.BeginForm("UpdateQuantity", "Home", Nothing, FormMethod.Post, New With {.class = "form-update-quantity", .id = "frmUpdateQuantity" & item.Id})
                        @Html.AntiForgeryToken()
                        @<input name="Id" type="hidden" value="@item.Id" />
                        @<input name="Quantity" class="input-quantity" type="text" value="@item.Quantity" maxlength="2" onkeypress='numberValidate(event)' title="Số lượng" onpaste="return false;" autocomplete="off" />                       
                        @<button type="button" title="Cập nhật" class="btn" onclick="UpdateQuantity('@("#frmUpdateQuantity" & item.Id)');"><i class="fa fa-refresh"></i></button>
            End Using
                </td>
                <td class="cart-price">
                    <span>@SharedFunc.FormatVnd(item.Price)</span>
                </td>
                <td class="cart-total">
                    <span>@SharedFunc.FormatVnd(item.Total)</span>
                </td>
            </tr>
        Next
        <tfoot>
            <tr>
                <td colspan="4" class="align-right font-bold">Tổng tiền (VNĐ)
                </td>
                <td>
                    <span>@SharedFunc.FormatVnd(Model.CartList.Sum(Function(x) x.Total))</span>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <a href="@Url.RouteUrl(ChoMayTinh.Constants.Route.ThongTinKhachHang)" class="btn btn-primary pull-right">Xác nhận giỏ hàng&nbsp;<i class="fa fa-angle-double-right"></i></a>
                </td>
            </tr>
        </tfoot>
    </table>
</div>