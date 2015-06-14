var confirmDeleteMsg = "Bạn có chắc chắn muốn xóa?"

$(function () {
    //setInterval(function () {
    //    $.get(baseUri + "Home/KeepAlive?q=" + Math.random());
    //}, keepAliveInterval);
});

function ConfirmDialog(message, okFunction, cancelFunc) {
    $("#dlgConfirmMessage").html(message);

    $("#dlgConfirmOk").off("click");
    $("#dlgConfirmOk").on("click", okFunction);

    if (cancelFunc != undefined) {
        $("#dlgConfirmCancel").off("click");
        $("#dlgConfirmCancel").on("click", cancelFunc);
    }

    $("#dlgConfirm").modal("show");
}

function AlertDialog(message, okFunction, cancelFunc) {
    $("#dlgAlertMessage").html(message);

    $("#dlgAlertOk").off("click");
    $("#dlgAlertOk").on("click", okFunction);

    if (cancelFunc != undefined) {
        $("#dlgAlertCancel").off("click");
        $("#dlgAlertCancel").on("click", cancelFunc);
    }

    $("#dlgAlert").modal("show");
}

function numberValidate(evt) {
    var theEvent = evt || window.event;
    var key = theEvent.keyCode || theEvent.which;
    key = String.fromCharCode(key);
    var regex = /[0-9]/;
    if (!regex.test(key)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }
}

/*******Product List*******/
var deleteProductMsg = "Bạn có chắc chắn muốn bỏ sản phẩm này không?";

function DeleteProduct(id) {
    AlertDialog(deleteProductMsg, function () {
        $(window).off("beforeunload");
        document.getElementById(id).submit();
    })
}
function EditProduct(id) {
    document.getElementById(id).submit();
}
function AddProduct() {
    window.location = "product?id=0";
}
/**************************/

/*******Product*******/
var saveProductMsg = "Bạn có chắc chắn muốn lưu sản phẩm này?"
var cancelProductMsg = "Bạn có chắc chắn muốn hủy bỏ các thay đổi?"

function BtnSaveClick(id) {
    ConfirmDialog(saveProductMsg, function () {
        $(window).off("beforeunload");
        document.getElementById(id).submit();
    });
}
function BtnDeleteClick() {
    window.location = "productlist";
}
function BtnCancelClick() {
    AlertDialog(cancelProductMsg, function () {
        $(window).off("beforeunload");
        window.location = baseUri + "Management/ProductList";
    });
}
function BtnClearClick() {
    AlertDialog(cancelProductMsg, function () {
        $(window).off("beforeunload");
        window.location = window.location
    });
}
/*********************/