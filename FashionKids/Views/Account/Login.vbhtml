@ModelType ChoMayTinh.LoginModel

@Code
    Layout = Nothing
End Code

<html>
<head>
    <meta charset="utf-8" />
    <title>Đăng nhập</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <meta name="viewport" content="width=device-width" />

    @styles.Render("~/Content/bootstrap-css")
    @Styles.Render("~/Content/font-awesome/css/css")
    @Styles.Render("~/Content/Login")
</head>

<body>    
    <div id="container">
        @Using Html.BeginForm(New With {.ReturnUrl = ViewData("ReturnUrl")})
            @<h2 class="form-signin-heading">Đăng nhập</h2>
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(True)    
            @<div class="input-prepend">
                <span class="add-on"><i class="fa fa-user"></i></span>
                @Html.TextBoxFor(Function(m) m.UserName, New With {.id = "txtUserName", .class = "input-block-level", .placeholder = "Tên đăng nhập", .maxlength = "255", .autocomplete = "off"})
            </div>
            @Html.ValidationMessageFor(Function(m) m.UserName)            
            @<div class="input-prepend">
                <span class="add-on"><i class="fa fa-lock"></i></span>
                @Html.PasswordFor(Function(m) m.Password, New With {.class = "input-block-level", .placeholder = "Mật khẩu", .maxlength = "255"})
            </div>
            @Html.ValidationMessageFor(Function(m) m.Password)
            @<button class="btn btn-large btn-primary pull-right" type="submit"><i class="fa fa-sign-in"></i>&nbsp;Đăng nhập</button>
        End Using
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/jqueryval")
    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtUserName").focus();
        })
    </script>
</body>
</html>
