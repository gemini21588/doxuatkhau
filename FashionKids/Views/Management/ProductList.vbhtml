@Imports Chomaytinh
@ModelType ChoMayTinh.ManagementViewModel

@Code
    ViewData("Title") = "Danh sách sản phẩm"
    Layout = "~/Views/Shared/_LayoutManagement.vbhtml"
    
    '' tổng số trang
    Dim NumbersOfPage As Integer
    If Model.ProductList IsNot Nothing andalso Model.NumberItemPerPage > 0 Then
        NumbersOfPage = Math.Ceiling(Model.Total / Model.NumberItemPerPage)
    End If
    
    Dim idx As Integer = 1
End Code

@Section styles
    <style type="text/css">
        /* Start bootstrap override */
        .bootstrap-select > .btn {
            width: 77% !important;
        }
        /* End bootstrap override */
    </style>
End Section

@Section LeftColumn        
    <button class="btn" type="button" onclick="window.location.href='@Url.Action("Product", "Management")'"><i class="fa fa-plus"></i>&nbsp;Thêm sản phẩm</button>   
    <div>
        <div>
            <h3>Bộ lọc</h3>
        </div>
        <div>
            @Using Html.BeginForm("ProductList", "Management", Nothing, FormMethod.Get, New With {.id = "frmSearch1"})
                @<input type="hidden" name="mode" value="1" />
                @<table>
                    <tr>
                        <td>
                            Menu cấp 1:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            @Html.DropDownList("menuLevel1", Model.MenuLevel1, New With {.style = "width: 80%;", .class = "selectpicker"})
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Menu cấp 2:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            @Html.DropDownList("menuLevel2", Model.MenuLevel2, New With {.style = "width: 100%;", .class = "selectpicker"})
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <button type="submit" class="btn"><i class="fa fa-filter" onclick="$('#hdnMode').val(1)"></i>&nbsp;Hiển thị</button>
                            <a href="@Url.Action("ProductList", "Management")" class="btn btn-inverse"><i class="fa fa-times"></i>&nbsp;Reset</a>
                        </td>
                    </tr>                                       
                </table>                    
            End Using    
            <br />
            @Using Html.BeginForm("ProductList", "Management", Nothing, FormMethod.Get, New With {.id = "frmSearch2"})
                @<input type="hidden" name="mode" value="2" />
                @<table>                    
                    <tr>
                        <td>
                            Tên sản phẩm:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            @Html.TextBox("productName", Model.Keyword, New With {.style = "width: 92%;", .placeholder = "Tên sản phẩm..."})
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <button type="submit" class="btn"><i class="fa fa-filter"></i>&nbsp;Hiển thị</button>
                            <a href="@Url.Action("ProductList", "Management")" class="btn btn-inverse"><i class="fa fa-times"></i>&nbsp;Reset</a>
                        </td>
                    </tr>                    
                </table>
            End Using 
        </div>
    </div>   
End Section

@If Model.ProductList Is Nothing Then
    Return
End If

<h2>Danh sách sản phẩm</h2>

<div>
    @Html.Partial("_PaginationPartial", New ChoMayTinh.PaginationModel With {.Controller = "Management", .Action = "ProductList", 
                                                                              .CurrentPage = Model.CurrentPage, 
                                                                              .NumbersOfPage = NumbersOfPage})
</div>

<table id="ProductList" style="width:100%;" class="table table-striped">
    <colgroup>
        <col style="width: 40px" />
        <col style="width: 100px" />
        <col style="width: 400px" />
        <col style="width: 140px" />
        <col style="width: 80px" />
    </colgroup>
    <thead>
        <tr>
            <th>#</th>
            <th>Hình ảnh</th>
            <th>Tên sản phầm</th>
            <th>Ngày cập nhật</th>            
            <th></th>
        </tr>
    </thead>
    <tbody>
        @For Each item In Model.ProductList
             @<tr>
                <td>@idx</td>
                <td><img class="product-img" src="@item.Image" alt="@item.Name" /></td>
                <td>                    
                    <a href="@Url.Action("Product", "Management", New With {.id = item.Id})">@item.Name</a>
                </td>
                <td>@item.UdDate.ToString("dd/MM/yyy hh:mm")</td>                
                <td>
                    @Using Html.BeginForm("Product", "Management", Nothing, FormMethod.Post, New With {.id = "frmDelProduct" & item.Id})
                        @Html.AntiForgeryToken()
                        @Html.Hidden("Product.Id", item.Id)
                        @Html.Hidden("command", ChoMayTinh.Constants.Command.Delete)
                        @<button type="button" onclick="DeleteProduct('@("frmDelProduct" & item.Id)');" class="btn btn-danger btn-small"><i class="fa fa-times"></i>&nbsp;Xóa</button>
                    End Using
                    
                </td>
            </tr>
            @Code
            idx = idx + 1
            End Code
        Next
    </tbody>
</table>

@Section scripts
    <script type="text/javascript">
        $(function () {
            $('.selectpicker').selectpicker();
        })
    </script>
End Section