@ModelType ChoMayTinh.NewsViewModel

@Code
    Dim title As String
    If Model.News.IsNews Then
        title = "Soạn tin"
    Else
        title = "Soạn tin khuyến mãi"
    End If
    ViewData("Title") = title
    Layout = "~/Views/Shared/_LayoutManagement.vbhtml"
End Code

@If Model.news.Id = 0 AndAlso Model.link.Length > 0 Then
    @<h3>Tin không tồn tại hoặc đã bị xóa. Xin hãy kiểm tra lại.</h3>
    Return
End If

<h2>@title</h2>

@Section styles
    <style type="text/css">
        .align-right {
            text-align: right;
        }

        #tableNews tr td:first-child {
            font-weight: bold;
        }

        #tableNews td {
            vertical-align: baseline;
        }

        #tableNews input[type=text] {
            width: 98%;
        }

        #tableNews textarea {
            width: 98%;
        }
    </style>
End Section

@Section LeftColumn
    <div class="btn-function">
        <button class="btn btn-success" type="button" onclick="Save()"><i class="fa fa-save"></i>&nbsp;Save</button><br />
        @If Model.News.Id <> 0 Then
            @<button class="btn btn-danger" type="button" onclick="Delete()"><i class="fa fa-trash-o"></i>&nbsp;Delete</button>
            @Using Html.BeginForm(If(Model.News.IsNews, "NewsEdit", "PromotionEdit"), "Management", New With {.command = ChoMayTinh.Constants.Command.Delete}, FormMethod.Post, New With {.id = "frmDelete"})
                @Html.AntiForgeryToken()
                @Html.HiddenFor(Function(x) x.News.Id)
            End Using                        
        End If
    </div>
End Section

@Using Html.BeginForm(If(Model.News.IsNews, "NewsEdit", "PromotionEdit"), "Management", Nothing, FormMethod.Post, New With {.id = "frmNews"})
    @Html.AntiForgeryToken()
    @Html.HiddenFor(Function(x) x.News.Id)
    @Html.HiddenFor(Function(x) x.News.IsNews)
    @<input type="hidden" id="command" name="command" />
    @<table id="tableNews" class="table">
        <colgroup>
            <col style="width: 100px" />
            <col style="width: 660px" />
        </colgroup>
        <tbody>
            <tr>
                <td style="text-align: right;">Tiêu đề:
                </td>
                <td>
                    @Html.TextBoxFor(Function(x) x.News.Title, New With {.id = "txtTitle", .maxlength = 255, .autocomplete = "off"})
                    @Html.ValidationMessageFor(Function(x) x.News.Title)
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">Hình ảnh:
                </td>
                <td>
                    @Html.TextBoxFor(Function(x) x.News.Image, New With {.id = "txtImage", .autocomplete = "off"})
                </td>
            </tr>            
            <tr>
                <td colspan="2">
                    Tóm tắt:<br />
                    @Html.TextAreaFor(Function(x) x.News.Summary, New With {.id = "txtSummary", .rows = "6"})
                </td>
            </tr>            
        </tbody>
    </table>    
    
    @<div class="product-detail-title">
        Nội dung
    </div>
    @<div class="product-detail">
        @Html.TextAreaFor(Function(x) x.News.Content, 0, 0, New With {.id = "txtContent"})
    </div>
End Using


@Section scripts    
    <script type="text/javascript">
        $(function () {
            CKEDITOR.replace("txtContent", { height: 800 });

            $(window).on("beforeunload", function () {
                return "Bạn có chắc muốn rời khỏi trang?";
            });

            $("#txtTitle").focus();
        })
        function Save() {
            ConfirmDialog("Bạn có muốn save các thay đổi?", function () {
                $(window).off("beforeunload");
                $("#frmNews").submit();
            });
        }

        function Delete() {
            AlertDialog(confirmDeleteMsg, function () {
                $(window).off("beforeunload");
                $("#frmDelete").submit();
            });
        }
    </script>
End Section