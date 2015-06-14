$(function () {
    var menuId = -1000;
    if ($.cookie("menuid") != null) {
        menuId = parseInt($.cookie("menuid"));
    }

    $("#MenuProductList").accordion({
        heightStyle: "content",
        collapsible: true,
        active: menuId
    });

    $("#MenuProductList > h3").click(function () {
        var index = $("#MenuProductList").accordion("option", "active");
        $.cookie("menuid", index, { expires: 1, path: "/" });
    });

    $("#frmSearch").on("submit", function (e) {
        var q = $.trim($("#q").val());
        if (q == "") {
            e.preventDefault();
            alert("Quý khách chưa nhập từ khóa tìm kiếm.");
            $("#q").focus();
            $("#q").select();
        }
    });

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

(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/vi_VN/all.js#xfbml=1";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));