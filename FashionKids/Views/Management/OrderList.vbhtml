@ModelType ChoMayTinh.OrderListViewModel

@Code
    ViewData("Title") = "Danh sách đơn hàng"
    Layout = "~/Views/Shared/_LayoutManagement.vbhtml"
    
    '' tổng số trang
    Dim NumbersOfPage As Integer
    If Model.OrderList IsNot Nothing Then
        NumbersOfPage = Math.Ceiling(Model.Total / Model.NumberItemPerPage)
    End If
    
    Dim rowIdx As Integer = 1
End Code

@If Model.OrderList Is Nothing Then
    Return
End If

@Section styles    
    <style type="text/css">
        thead td {
            font-weight: bold !important;
        }
    </style>
End Section

@Section LeftColumn
    <div>
        <div>
            <h3>Bộ lọc</h3>            
        </div>
        <div>
            @Using Html.BeginForm("OrderList", "Management", Nothing, FormMethod.Get)
                @<table>
                    <tr>
                        <td>Ngày order
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="input-prepend">
                                <span class="add-on"><i class="fa fa-calendar"></i></span>
                                <input name="orderDate" type="text" id="orderDate" style="vertical-align: baseline; text-align: center; width: 72%; cursor: text;" readonly="readonly" value="@Model.OrderDate.ToString("dd/MM/yyyy")" />
                            </div>                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <button type="submit" class="btn"><i class="fa fa-filter"></i>&nbsp;Hiển thị</button>
                            <a href="@Url.Action("OrderList", "Management")" class="btn btn-inverse"><i class="fa fa-times"></i>&nbsp;Reset</a>
                        </td>
                    </tr>
                </table>                    
            End Using
        </div>
    </div>
End Section

<h2>Danh sách đơn hàng</h2>

<div>
    @Html.Partial("_PaginationPartial", New ChoMayTinh.PaginationModel With {.Controller = "Management", .Action = "OrderList", 
                                                                              .CurrentPage = Model.CurrentPage, 
                                                                              .NumbersOfPage = NumbersOfPage})
</div>

<table id="tblMenuLevel" class="table table-striped">
    <colgroup>
        <col style="width: 330px" />
        <col style="width: 280px" />
        <col style="width: 150px" />
    </colgroup>

    <thead>
        <tr>
            <td><i class="fa fa-user"></i>&nbsp;Tên khách hàng</td>
            <td><i class="fa fa-phone"></i>&nbsp;Điện thoại</td>
            <td><i class="fa fa-calendar-o"></i>&nbsp;Ngày đặt hàng</td>
        </tr>
    </thead>
    <tbody>
        @For Each item In Model.OrderList
            @<tr>
                <td><a href="@Url.Action("OrderDetail", "Management", New With {.id = item.Guid})">@item.CustomerName</a></td>
                <td>@item.Tel</td>
                <td>@item.AdDate.ToString("dd/MM/yyyy hh:mm")</td>
            </tr>            
        Next
    </tbody>
</table>

@Section scripts    
    <script type="text/javascript">
        $(function () {
            $("#orderDate").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#orderDate").mask("99/99/9999");
        })
        $(".add-on").click(function () {
            $("#orderDate").focus();
        })
    </script>
End Section