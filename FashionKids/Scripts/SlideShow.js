/* command enum */
var Command = {
    AddNew: 1,
    Update: 2,
    Delete: 3
}

/*Slide show*/
function addImage() {
    $("#validator-span").hide();
    $("#form-edit-image #Image").removeClass("input-validation-error");

    $("#form-edit-image #Id").val(0);
    $("#form-edit-image #Image").val("");
    $("#form-edit-image #Link").val("");    
    $("#form-edit-image #Command").val(Command.AddNew);
    $("#edit-image .btn-danger").hide();

    $("#edit-image").off("shown");
    $("#edit-image").on("shown", function () {
        $("#form-edit-image #Image").focus();
        $("#form-edit-image #Image").select();
    });

    $("#edit-image").modal("show");
}

function editImage(id, image, link) {
    $("#validator-span").hide();
    $("#form-edit-image #Image").removeClass("input-validation-error");

    $("#form-edit-image #Id").val(id);
    $("#form-edit-image #Image").val(image);
    $("#form-edit-image #Link").val(link);    
    $("#form-edit-image #Command").val(Command.Update);
    $("#edit-image .btn-danger").show();

    $("#edit-image").off("shown");
    $("#edit-image").on("shown", function () {
        $("#form-edit-image #Image").focus();
        $("#form-edit-image #Image").select();
    });

    $("#edit-image").modal("show");
}

function confirmedEditImage() {
    var imageLink = $.trim($("#Image").val());
    if (imageLink == "") {
        $("#validator-span").show();
        $("#form-edit-image #Image").addClass("input-validation-error");
        $("#form-edit-image #Image").focus();
        $("#form-edit-image #Image").select();
        return;
    } else {
        $("#validator-span").hide();
        $("#form-edit-image #Image").removeClass("input-validation-error");
    }
    $("#form-edit-image").submit();
}

function deleteConfirm() {
    $("#edit-image").modal("hide");
    AlertDialog(confirmDeleteMsg,
        function () {
            deleteImage(true);
        },
        function () {
            deleteImage(false);
        });
}

function deleteImage(isDelete) {
    if (isDelete) {
        $("#form-edit-image #Command").val(Command.Delete);
        $("#form-edit-image").submit();
    } else {
        $("#edit-image").modal("show");
    }
}