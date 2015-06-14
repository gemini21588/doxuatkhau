var nameEmptyErrorMsg = "Tên không được phép rỗng."
var titleAddNew = "Thêm mới menu";
var titleEdit = "Chỉnh sửa menu";

function ShowDialogAddMenu(title, id, name, isError, btnOkCallBack) {
    $("#dlgAddMenuTitle").text(title);
        
    if (!isError) {
        $("#hdnId").val(id);
        $("#txtName").val(name);
    }

    $("#btnAddMenuOk").off("click");
    $("#btnAddMenuOk").on("click", btnOkCallBack);
        
    $("#dlgAddMenu").off("shown");
    $("#dlgAddMenu").on("shown", function () {
        $("#txtName").focus();
        $("#txtName").select();
    });
    $("#dlgAddMenu").modal("show");
}


function AddMenu() {
    $("#txtName").removeClass("input-validation-error");
    $("#errorSpan").text("");
    ShowDialogAddMenu(titleAddNew, "0", "", false, function () {
        ErrorCheck();
    });
}

function EditMenu(id, name) {
    $("#txtName").removeClass("input-validation-error");
    $("#errorSpan").text("");
    ShowDialogAddMenu(titleEdit, id, name, false, function () {
        ErrorCheck();
    });
}

function ErrorCheck() {
    var txtName = $.trim($("#txtName").val());
    if (txtName == "") {        
        $("#txtName").focus();
        $("#txtName").select();
        $("#txtName").addClass("input-validation-error");
        $("#errorSpan").text(nameEmptyErrorMsg);
    }
    else {
        $("#frmAddMenu").submit();
    }
}

function DeleteMenu(id) {
    AlertDialog(confirmDeleteMsg, function () {
        $(id).submit();
    })
}