var confirmOrderMessage = "Quý khách có muốn xác nhận giỏ hàng?<br />Chúng tôi sẽ liên hệ với quý khách trong thời gian sớm nhất.";

$("#btnSubmit").click(function () {
    var txtCustomerName = $.trim($("#txtCustomerName").val());
    var txtTel = $.trim($("#txtTel").val());
    var txtAddress = $.trim($("#txtAddress").val());
    var hasError = false;

    $("#validation-message-span").html("");
    $("#tb-order input").removeClass("input-error");

    if (txtCustomerName == 0) {
        var msg = $("#txtCustomerName").attr("data-val-required");
        $("#validation-message-span").append("<div>*" + msg + "</div>");
        $("#txtCustomerName").addClass("input-error");
        $("#txtCustomerName").focus();
        hasError = true;
    }

    if (txtTel == 0) {
        var msg = $("#txtTel").attr("data-val-required");
        $("#validation-message-span").append("<div>*" + msg + "</div>");
        $("#txtTel").addClass("input-error");
        if (!hasError)
            $("#txtTel").focus();
        hasError = true;
    }

    if (txtAddress == 0) {
        var msg = $("#txtAddress").attr("data-val-required");
        $("#validation-message-span").append("<div>*" + msg + "</div>");
        $("#txtAddress").addClass("input-error");
        if (!hasError)
            $("#txtAddress").focus();
        hasError = true;
    }

    if (!hasError) {
        ConfirmDialog(confirmOrderMessage, function () {
            $("#frmOrder").submit();
        });
    }    
})