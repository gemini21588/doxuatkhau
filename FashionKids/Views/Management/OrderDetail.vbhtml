@Imports Chomaytinh
@ModelType ChoMayTinh.OrderDetailViewModel

@Code    
    ViewData("Title") = "Thông tin đơn hàng"
    Layout = "~/Views/Shared/_LayoutManagement.vbhtml"
    
    Dim orderList As List(Of OrderDetail) = Model.OrderInfo.OrderDetails.Where(Function(x) x.Product IsNot Nothing).ToList()
End Code

@If Model.OrderInfo Is Nothing Then
    Return
End If

<h2>Thông tin đơn hàng</h2>

<div>
    <table id="orderInfo" class="table">
        <colgroup>
            <col style="width: 250px" />
            <col style="width: 500px" />
        </colgroup>
        <tr>
            <td>Tên khách hàng:</td>
            <td>@Model.OrderInfo.CustomerName</td>
        </tr>
        <tr>
            <td>Số điện thoại:</td>
            <td>@Model.OrderInfo.Tel</td>
        </tr>
        <tr>
            <td>Địa chỉ:</td>
            <td>@Model.OrderInfo.Address</td>
        </tr>
        <tr>
            <td>Ngày order:</td>
            <td>@Model.OrderInfo.AdDate.ToString("dd/MM/yyyy hh:mm")</td>
        </tr>
        <tr>
            <td>Ghi chú:</td>
            <td><pre>@Model.OrderInfo.Note</pre></td>
        </tr>
    </table>

    <h2>Danh sách sản phẩm</h2>

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
        @For Each item In orderList
            @<tr>
                <td class="cart-image">
                    <img src="@item.Product.Image" title="@item.Product.Name" alt="@item.Product.Name" />
                </td>
                <td class="cart-name">
                    <span>@item.Product.Name</span>
                </td>
                <td class="cart-quantity">
                    <span>@item.Quantity</span>
                </td>
                <td class="cart-price">
                    <span>@SharedFunc.FormatVnd(item.Product.NewPrice)</span>
                </td>
                <td class="cart-total">
                    <span>@SharedFunc.FormatVnd(item.Quantity * item.Product.NewPrice)</span>
                </td>
            </tr>
        Next
        <tfoot>
            <tr>
                <td colspan="4" style="text-align: right;">Tổng tiền (VNĐ)
                </td>
                <td>
                    <span>@SharedFunc.FormatVnd(orderList.Sum(Function(x) x.Quantity * x.Product.NewPrice))</span>
                </td>
            </tr>            
        </tfoot>
    </table>
</div>