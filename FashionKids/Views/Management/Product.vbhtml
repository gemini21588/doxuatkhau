@Imports Chomaytinh
@ModelType ChoMayTinh.ProductDetailViewModel

@Code
    ViewData("Title") = If(String.IsNullOrEmpty(model.Product.Name), "Sản phẩm mới", model.Product.Name)
    Layout = "~/Views/Shared/_LayoutManagement.vbhtml"
    
    Dim hasMenu As Boolean = True
    If Model.MenuLevel1List IsNot Nothing AndAlso Model.MenuLevel2List IsNot Nothing Then
        hasMenu = (Model.MenuLevel1List.Count > 0 AndAlso Model.MenuLevel2List.Count > 0)
    End If
End Code

@If Not hasMenu Then
    @<h3>Chưa thiết lập menu cấp 1 hoặc menu cấp 2.</h3>
    @<h3>Xin hãy kiểm tra lại.</h3>
    Return
End If

@If Model.Product.Id = 0 AndAlso Model.Command = Constants.Command.Update Then
    @<h3>Sản phẩm không tồn tại hoặc đã bị xóa. Xin hãy kiểm tra lại.</h3>
    Return
End If

@Section LeftColumn
    <div class="btn-function">                
        <button type="button" class="btn btn-success" onclick="BtnSaveClick('frmSaveProduct')"><i class="fa fa-save"></i>&nbsp;Save</button>
        @If Model.Command <> Constants.Command.AddNew Then
            @<button class="btn btn-danger" onclick="DeleteProduct('frmDelProduct');"><i class="fa fa-trash-o"></i>&nbsp;Delete</button>
            @<br/>
        End If        
        <button class="btn btn-inverse" onclick="BtnCancelClick()"><i class="fa fa-reply"></i>&nbsp;Cancel</button>
        <button class="btn" onclick="BtnClearClick()"><i class="fa fa-times"></i>&nbsp;Reset</button>
        @Using Html.BeginForm("Product", "Management", Nothing, FormMethod.Post, New With {.id = "frmDelProduct"})
            @Html.AntiForgeryToken()               
            @Html.HiddenFor(Function(model) model.Product.Id)
            @Html.Hidden(PropertyHelper(Of ProductDetailViewModel).GetName(Function(x) x.Command), ChoMayTinh.Constants.Command.Delete)
        End Using
    </div>
End Section

@Section styles
    <style type="text/css">
        #Product input.fill {
            width: 98%;
        }

        #Product td {
            vertical-align: baseline;
        }

        #Product tr td:first-child {
            text-align: right;
            font-weight: bold;
        }                
    </style>
End Section

<div class="product-detail-title">
    THÔNG TIN SẢN PHẨM
</div>

@Using Html.BeginForm("Product", "Management", Nothing, FormMethod.Post, New With {.id = "frmSaveProduct"})    
    @Html.AntiForgeryToken() 
    @Html.HiddenFor(Function(model) model.Product.Id)
    @Html.HiddenFor(Function(model) model.Command)
    @<table id="Product" style="width:100%;" class="table">
        <colgroup>
            <col style="width: 150px;" />
            <col />
        </colgroup>
        <tr>
            <td>Sản phẩm mới:</td>
            <td>
                @Html.CheckBoxFor(Function(model) model.Product.IsHomePage)
            </td>
        </tr>
        <tr>
            <td>Tên sản phẩm:</td>
            <td>@Html.TextBoxFor(Function(model) model.Product.Name, New With {.id = "txtName", .maxlength = 255, .class="fill", .autocomplete = "off"})
                @Html.ValidationMessageFor(Function(model) model.Product.Name)</td>
        </tr>
        <tr>
            <td>Menu cấp 1:</td>
            <td>@Html.DropDownListFor(Function(model) model.Product.CategoryId, Model.MenuLevel1List, New With {.class = "selectpicker", .id = "menuLevel1"})</td>
        </tr>
        <tr>
            <td>Menu cấp 2:</td>
            <td>@Html.DropDownListFor(Function(model) model.Product.MakerId, Model.MenuLevel2List, New With {.class = "selectpicker", .id="menuLevel2"})</td>
        </tr>
        <tr>
            <td>Hình ảnh:</td>
            <td>
                @Html.TextBoxFor(Function(model) model.Product.Image, New With {.class = "fill", .autocomplete = "off"})
                @Html.ValidationMessageFor(Function(model) model.Product.Image)
            </td>
        </tr>
        <tr>
            <td>Màu sắc:</td>
            <td>@Html.TextBoxFor(Function(model) model.Product.Color, New With {.maxlength = 255, .class="fill", .autocomplete = "off"})</td>
        </tr>
        <tr>
            <td>Size:</td>
            <td>@Html.TextBoxFor(Function(model) model.Product.Size, New With {.maxlength = 255, .class="fill", .autocomplete = "off"})</td>
        </tr>
        <tr>
            <td>Giá cũ:</td>
            <td>@Html.TextBoxFor(Function(model) model.Product.OldPrice, New With {.class = "number", .onkeypress = "numberValidate(event)", .onpaste = "return false;", .maxlength = 18, .style = "width: 30%;", .autocomplete = "off"})
                @Html.ValidationMessageFor(Function(model) model.Product.OldPrice)
            </td>
        </tr>
        <tr>
            <td>Giá mới:</td>
            <td>@Html.TextBoxFor(Function(model) model.Product.NewPrice, New With {.class="number",.onkeypress = "numberValidate(event)", .onpaste = "return false;", .maxlength = 18, .style="width: 30%;", .autocomplete = "off"})
                @Html.ValidationMessageFor(Function(model) model.Product.NewPrice)
            </td>
        </tr>
        <tr>
            <td>Tình Trạng:</td>
            <td>@Html.TextBoxFor(Function(model) model.Product.Condition, New With {.maxlength = 255, .class="fill", .autocomplete = "off"})</td>
        </tr>
        <tr>
            <td>Xuất xứ:</td>
            <td>@Html.TextBoxFor(Function(model) model.Product.Origin, New With {.maxlength = 255, .class="fill", .autocomplete = "off"})</td>
        </tr>
    </table>

    @<div class="product-detail-title">
        THÔNG TIN CHI TIẾT
    </div>

    @<div class="product-detail">
        @Html.TextAreaFor(Function(model) model.Product.Info, New With {.id = "txtInfo"})
    </div>
End Using
@Section scripts    
    <script type="text/javascript">
        $(function () {
            CKEDITOR.replace("txtInfo", { height: 800 });

            $('.selectpicker').selectpicker();

            $(window).on("beforeunload", function () {
                return "Bạn có chắc muốn rời khỏi trang?";
            });

            $("#txtName").focus();

            $(".number").focusout(function () {
                var val = $.trim($(this).val());
                if (val == "") {
                    $(this).val(0);
                }
            });
        })
    </script>
End Section
