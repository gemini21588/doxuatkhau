@imports ChoMayTinh
@ModelType ChoMayTinh.OrderViewModel

@Code
    ViewData("Title") = SharedFunc.PageTitle("Thông tin khác hàng")
End Code

<div id="customerInfo">
    <h3>Thông tin khác hàng</h3>

    <div id="validation-message-span">
    </div>


    @Using Html.BeginForm("Order", "Home", Nothing, FormMethod.Post, New With {.id = "frmOrder"})
        @Html.AntiForgeryToken()
        @<table id="tb-order">
            <colgroup>
                <col style="width: 140px" />
                <col />
            </colgroup>
            <tbody>
                <tr>
                    <td>
                        @Html.LabelFor(Function(x) x.CustomerName)<span style="color: red;">&nbsp;*</span>
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(x) x.CustomerName, New With {.maxlength = "255", .id = "txtCustomerName"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.LabelFor(Function(x) x.Tel)<span style="color: red;">&nbsp;*</span>
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(x) x.Tel, New With {.maxlength = 11, .id = "txtTel", .onkeypress = "numberValidate(event)", .onpaste="return false;"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.LabelFor(Function(x) x.Address)<span style="color: red;">&nbsp;*</span>
                    </td>
                    <td>
                        @Html.TextBoxFor(Function(x) x.Address, New With {.maxlength = "255", .id = "txtAddress"})
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.LabelFor(Function(x) x.Note)
                    </td>
                    <td>
                        @Html.TextAreaFor(Function(x) x.Note, 0, 0, New With {.maxlength = "255", .rows = "6"})
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td></td>
                    <td class="no-padding">
                        <a href="@Url.Content(ChoMayTinh.Constants.Route.GioHangRoute)" class="btn btn-primary pull-left" target="_blank"><i class="fa fa-angle-double-left"></i>&nbsp;Xem lại giỏ hàng</a>
                        <button id="btnSubmit" type="button" class="btn btn-primary pull-right"><i class="fa fa-shopping-cart"></i>&nbsp;Xác nhận</button>
                    </td>
                </tr>
            </tfoot>
        </table>
    End Using
</div>