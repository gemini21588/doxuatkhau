var deleteCartItemMsg = "Quý Khách có chắc chắn muốn bỏ sản phẩm này khỏi giỏ hàng?";

function DeleteCartItem(id) {
    AlertDialog(deleteCartItemMsg, function () {
        $(id).submit();
    })
}

function UpdateQuantity(id) {
    $(id).submit();
}

var oldValue;
$(".input-quantity").focusin(function () {
    oldValue = $(this).val();
});

$(".input-quantity").focusout(function () {
    var newValue = $(this).val();
    if (newValue == 0) {
        $(this).val(oldValue);
    }
});