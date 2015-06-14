@ModelType ChoMayTinh.EditorViewModel

@Code
    ViewData("Title") = Model.Content.Title
    Layout = "~/Views/Shared/_LayoutManagement.vbhtml"
    
    Dim IsPromotion As Boolean = (Model.Content.Id = "quang-cao")
End Code

@If Model.Content Is Nothing Then
    Return
End If

<h2>@Model.Content.Title</h2>

@Section LeftColumn
    <div class="btn-function">
        <button class="btn btn-success" type="button" onclick="Save()"><i class="fa fa-save"></i>&nbsp;Save</button><br/>
    </div>    
End Section

<div style="@(If(IsPromotion, "width:220px;", ""))">
@Using Html.BeginForm("Editor", "Management", Nothing, FormMethod.Post, New With {.id = "frmEditor"})
    @Html.AntiForgeryToken()
    @Html.HiddenFor(Function(x) x.Content.Id)
    @Html.TextAreaFor(Function(x) x.Content.Content1, New With {.id = "txtContent"})
End Using
</div>

@Section scripts    
    <script type="text/javascript">
        $(function () {
            @If IsPromotion Then
                @<text>
                var config = {
                    height: "800",                    
                    toolbar_Full: [
                    { name: 'insert', items: ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak', 'Iframe', 'Youtube', 'MediaEmbed', 'Link', 'Unlink'] }
                    ]
                };
                CKEDITOR.replace("txtContent", config);
            </text>
            Else
                @<text>
                CKEDITOR.replace("txtContent", { height: 800 });
                </text>
            End If            

            $(window).on("beforeunload", function () {
                return "Bạn có chắc muốn rời khỏi trang?";
            });
        })
        function Save() {
            ConfirmDialog("Bạn có muốn save các thay đổi?", function () {
                $(window).off("beforeunload");
                $("#frmEditor").submit();
            });
        }
     </script>
End Section