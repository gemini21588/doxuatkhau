@ModelType ChoMayTinh.SlideShowViewModel

@Code
    ViewData("Title") = "Slide show"
    Layout = "~/Views/Shared/_LayoutManagement.vbhtml"
    
    Dim editModel As new ChoMayTinh.SlideShow
End Code

@Section LeftColumn
    <button type="button" class="btn" onclick="addImage();"><i class="fa fa-plus"></i>&nbsp;Thêm image</button>
End Section

<h2>Slide show</h2>

@For Each item In Model.SlideShow
    @<a href="javascript:void(0)" onclick="editImage(@item.Id, '@item.Image', '@item.Link')">
        <img src="@item.Image" style="width: 1000px; height: 320px;" />
     </a>
    @<br />
    @<br />
Next

<div id="edit-image" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-header">
    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
    <h3 id="myModalLabel">Edit</h3>
  </div>
  <div class="modal-body">
   @Using Html.BeginForm("SlideShow", "Management", Nothing, FormMethod.Post, New With {.id = "form-edit-image"})         
        @<table style="width: 100%;">
            <tbody>
                <tr>
                    <td>
                        @Html.AntiForgeryToken()
                        @Html.Hidden("Id", Nothing, New With {.id = "Id"})                        
                        @Html.Hidden("Command", "1", New With {.id = "Command"})
                        @Html.TextBox("Image", nothing, New With {.placeholder = "Image link", .style = "width: 95%;", .autocomplete = "off", .id = "Image"})
                        <span id="validator-span" style="display: none" class="field-validation-error">Image link không được rỗng.</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        @Html.TextBox("Link", Nothing, New With {.placeholder = "Link", .style = "width: 95%;", .autocomplete = "off", .id = "Link"})
                    </td>
                </tr>
            </tbody>
         </table>
    End Using
  </div>
  <div class="modal-footer">
    <button class="btn btn-danger pull-left" onclick="deleteConfirm();"><i class="fa fa-times"></i>&nbsp;Xóa</button>
    <button class="btn btn-primary" onclick="confirmedEditImage();"><i class="fa fa-save"></i>&nbsp;Save</button>
    <button class="btn" data-dismiss="modal" aria-hidden="true">Cancel</button>    
  </div>
</div>