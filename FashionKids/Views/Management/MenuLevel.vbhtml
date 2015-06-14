@ModelType ChoMayTinh.MenuLevelViewModel

@Code
    ViewData("Title") = Model.MenuName
    Layout = "~/Views/Shared/_LayoutManagement.vbhtml"
    Dim i As Integer = 1
End Code

<h2>@Model.MenuName</h2>

@If Model.MenuLevelList Is Nothing Then
    Return
End If

@Section LeftColumn
    <div class="btn-function">
        <button id="btnAddMenu" class="btn" onclick="AddMenu();"><i class="fa fa-plus"></i>&nbsp;Thêm menu</button>
    </div>
End Section

<table id="tblMenuLevel" class="table table-striped">
    <colgroup>
        <col style="width: 40px" />
        <col style="width: 330px" />
        <col style="width: 330px" />
        <col style="width: 100px" />
    </colgroup>
    <thead>
        <tr>
            <th>#</th>
            <td>Tên menu</td>
            <td>Link</td>
            <td></td>
        </tr>
    </thead>
    <tbody>
        @For Each item In Model.MenuLevelList
            @<tr>
                <td>@i</td>
                <td><a href="javascript:void(0)" onclick="EditMenu(@item.Id, '@item.Name');">@item.Name</a></td>
                <td>@item.Link</td>
                <td>
                    @Using Html.BeginForm("MenuLevel", "Management", nothing, FormMethod.Post, New With {.id = "frmDeleteMenu" & item.Id})
                    @Html.AntiForgeryToken()
                    @<input type="hidden" name="Id" value ="@item.Id" />
                    @<input type="hidden" name="Level" value ="@Model.Level" />
                    @<input type="hidden" name="IsDel" value ="true" />
                    @<button type="button" class="btn btn-danger" onclick="DeleteMenu('@("#frmDeleteMenu" & item.Id)')"><i class="fa fa-times"></i>&nbsp;Xóa</button>
            End Using                    
                </td>                
            </tr>  
            @Code
            i = i + 1
            End Code
        Next
    </tbody>
</table>

<div id="dlgAddMenu" class="modal hide fade">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
        <h3 id="dlgAddMenuTitle">Thêm mới menu</h3>
    </div>
    <div class="modal-body">
        @Using Html.BeginForm("MenuLevel", "Management", Nothing, FormMethod.Post, New With {.id = "frmAddMenu"})
            @Html.AntiForgeryToken()
            @<input type="hidden" name="Level" value="@Model.Level" />
            @<input type="hidden" name="Id" id="hdnId" value="@Model.Id" />
            @If Model.ErrorMsg.Length = 0 Then
                @<input id="txtName" type="text" name="Name" maxlength="255" autocomplete = "off" />            
            Else
                @Html.TextBox("Name", Model.Name, New With {.id = "txtName", .maxlength = "255", .autocomplete = "off"})
            End If            
        End Using
        <span id="errorSpan" class="field-validation-error">@Model.ErrorMsg</span>
    </div>
    <div class="modal-footer">
        <a href="javascript:void(0)" class="btn btn-primary" id="btnAddMenuOk""><i class="fa fa-save"></i>&nbsp;Save</a>
        <a href="javascript:void(0)" class="btn" data-dismiss="modal" aria-hidden="true" id="dlgConfirmCancel">Cancel</a>
    </div>
</div>

@Section scripts    
    @If Model.ErrorMsg.Length > 0 Then
        @<script type="text/javascript">
             var title;
             @If Model.Id = 0 Then
             @<text>
             title = titleAddNew;
             </text>
        Else
             @<text>
             title = titleEdit;
             </text>
        End If
             ShowDialogAddMenu(title, 0, "", true, ErrorCheck);
         </script>
    End If
    @If Model.IsUsing Then
        @<script type="text/javascript">
             AlertDialog("Menu bạn muốn xóa hiện đang được sử dụng. Xin hãy kiểm tra lại!");
         </script>
    End If
End Section