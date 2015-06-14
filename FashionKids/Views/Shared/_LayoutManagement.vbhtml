<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <meta name="viewport" content="width=device-width" />
    <title>@ViewData("Title")</title>    
    
    @Styles.Render("~/Content/font-awesome/css/css")    
    @Styles.Render("~/Content/bootstrap-css")    
    @Styles.Render("~/Content/Bootstrap-Select")
    @Styles.Render("~/Content/themes/base/css")
    @Styles.Render("~/Content/Management")
    @RenderSection("styles", required:=False)
    <script type="text/javascript">
        var baseUri = '@Url.Content("~")';
        var keepAliveInterval = parseInt(@Session.Timeout) * 60000 - 60000; 
    </script>
</head>
<body>
    <div>
        <div class="navbar navbar-fixed-top">
            <div class="navbar-inner">
                <a class="brand" href="@Url.Action("Index", "Management")"><i class="fa fa-home"></i>&nbsp;Management System</a>
                <ul class="nav">
                    <li><a href="@Url.Action("ProductList", "Management")">Sản phẩm</a></li>
                    <li class="dropdown">
                        <a href="javascript:void(0)" class="dropdown-toggle" data-toggle="dropdown">Menu <b class="caret"></b></a>
                        <ul class="dropdown-menu">
                          <li><a href="@Url.Action("MenuLevel", "Management", New With {.id = 1})">@ChoMayTinh.Constants.MenuLevelName.MenuLevel1</a></li>
                          <li><a href="@Url.Action("MenuLevel", "Management", New With {.id = 2})">@ChoMayTinh.Constants.MenuLevelName.MenuLevel2</a></li>                                                 
                        </ul>
                      </li>
                    <li><a href="@Url.Action("OrderList", "Management")">Quản lý đơn hàng</a></li>
                    <li class="dropdown">
                        <a href="javascript:void(0)" class="dropdown-toggle" data-toggle="dropdown">Quản lý tin tức <b class="caret"></b></a>
                        <ul class="dropdown-menu">
                          <li><a href="@Url.Action("News", "Management")">Tin tức</a></li>
                    <li><a href="@Url.Action("Promotion", "Management")">Tin khuyến mãi</a></li>
                        </ul>
                      </li>                    
                    <li class="dropdown">
                        <a href="javascript:void(0)" class="dropdown-toggle" data-toggle="dropdown">Soạn trang <b class="caret"></b></a>
                        <ul class="dropdown-menu">
                            <li><a href="@Url.Action("Editor", "Management", New With {.id = "lien-he"})">@ConfigurationManager.AppSettings("lien-he")</a></li>
                            <li><a href="@Url.Action("Editor", "Management", New With {.id = "gioi-thieu"})">@ConfigurationManager.AppSettings("gioi-thieu")</a></li>
                            <li><a href="@Url.Action("Editor", "Management", New With {.id = "qui-dinh-mua-hang"})">@ConfigurationManager.AppSettings("qui-dinh-mua-hang")</a></li>
                            <li><a href="@Url.Action("Editor", "Management", New With {.id = "phuong-thuc-thanh-toan"})">@ConfigurationManager.AppSettings("phuong-thuc-thanh-toan")</a></li>
                        </ul>
                      </li>
                    <li><a href="@Url.Action("Editor", "Management", New With {.id = "quang-cao"})">@ConfigurationManager.AppSettings("quang-cao")</a></li>
                </ul>
                <ul class="nav pull-right">
                    <li>
                        @Using Html.BeginForm("LogOff", "Account", Nothing, FormMethod.Post, New With {.id = "frmLogOff"})
                            @Html.AntiForgeryToken()
                        End Using
                    </li>
                    <li>                                                
                        <a href="javascript:void(0)" onclick="$('#frmLogOff').submit()">Thoát&nbsp;<i class="fa fa-sign-out"></i></a>
                    </li>
                </ul>
            </div>
        </div>

        <article>
        <div id="contentWrapper">            
            <div id="LeftColumn">
                @RenderSection("LeftColumn", required:=False)
            </div>
            <div id="RightColumn">
                @RenderBody()
            </div>
        </div>
    </article>
    </div>

    <div id="dlgAlert" class="modal hide fade">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h3 id="dlgAlertTitle">Cảnh báo</h3>
        </div>
        <div class="modal-body" style="color: red;">
            <i class="fa fa-exclamation-triangle" style="font-size:2em;"></i>&nbsp;&nbsp;<span id="dlgAlertMessage">One fine body…</span>
        </div>
        <div class="modal-footer">
            <a href="javascript:void(0)" class="btn btn-primary" id="dlgAlertOk">Ok</a>
            <a href="javascript:void(0)" class="btn" data-dismiss="modal" aria-hidden="true" id="dlgAlertCancel">Cancel</a>
        </div>
    </div>

    <div id="dlgConfirm" class="modal hide fade">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h3 id="dlgConfirmTitle">Xác nhận</h3>
        </div>
        <div class="modal-body">
            <span id="dlgConfirmMessage">One fine body…</span>
        </div>
        <div class="modal-footer">
            <a href="javascript:void(0)" class="btn btn-primary" id="dlgConfirmOk">Ok</a>
            <a href="javascript:void(0)" class="btn" data-dismiss="modal" aria-hidden="true" id="dlgConfirmCancel">Cancel</a>
        </div>
    </div>

    @Scripts.Render("~/bundles/jquery")    
    @Scripts.Render("~/bundles/jqueryui")    
    @Scripts.Render("~/bundles/jquery.maskedinput")
    @Scripts.Render("~/bundles/bootstrap-js")    
    @Scripts.Render("~/bundles/Bootstrap-Select")
    <script src="~/ckeditor/ckeditor.js"></script>
    <script src="~/ckeditor/adapters/jquery.js"></script>    
    @Scripts.Render("~/bundles/Management")
    @RenderSection("scripts", required:=False)
</body>
</html>
