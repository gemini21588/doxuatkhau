<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>@ViewData("Title")</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <meta name="viewport" content="width=device-width" />

    <meta http-equiv="Content-Language" content="vi">
    <meta name="robots" content="@Model.Robots">
    <meta id="Keywords" name="keywords" content="@Model.Keywords">
    <meta id="Description" name="description" content="@Model.Description">

    @Styles.Render("~/Content/css")
    @Styles.Render("~/Content/font-awesome/css/css")
    @RenderSection("styles", required:=False)
    @Styles.Render("~/Content/css-custom")
    @Styles.Render("~/Content/bootstrap-css")
    @Styles.Render("~/Content/imageslider")
    @Scripts.Render("~/bundles/modernizr")
    <script type="text/javascript">
        var baseUri = '@Url.Content("~")';
        var keepAliveInterval = parseInt(@Session.Timeout) * 60000 - 60000; 
    </script>
</head>
<body>
    <header>
        <div class="content-wrapper">
            <ul id="menu">
                <li><a href="@Url.Content("~")">Trang chủ</a></li>
                <li><a href="@Url.RouteUrl(ChoMayTinh.Constants.Route.GioiThieu)/">Giới thiệu</a></li>
                <li><a href="@Url.Content("~/" & ChoMayTinh.Constants.Route.KhuyenMaiRoute & "/1")">Khuyến mãi</a></li>
                <li><a href="@Url.Content("~/" & ChoMayTinh.Constants.Route.TinTucRoute & "/1")">Tin tức thời trang</a></li>
                <li><a href="@Url.RouteUrl(ChoMayTinh.Constants.Route.LienHe)/">Liên hệ</a></li>
                <li style="float: right; padding: 3px;">
                    <form action="@Url.RouteUrl(ChoMayTinh.Constants.Route.TimKiem)" method="get" id="frmSearch">
                        <div class="input-append">
                            <input name="q" id="q" maxlength="255" type="text" class="span2" placeholder="Tên sản phẩm..." value="@Model.TextSearch" />
                            <button class="btn" type="submit">
                                <i class="fa fa-search"></i>
                            </button>
                        </div>
                    </form>
                </li>
            </ul>
        </div>
    </header>
    <div style="height:5px;background-color:#C2272D">

    </div>
    <article>
        <div class="content-wrapper">
            @***************************************** LOGO IMAGE SLIDER ************************************@
            <div id="ImageSlider">
                @* <img src="~/Content/Images/baner1.png" alt="HT-SHOP" />*@
                <table>
                    <tr>
                        @*<td>
                            <a href="~/" title="BT-SHOP">
                                <img style="margin-top:10px;margin-left:10px"src="~/Content/Images/logodoxuatkhau3.png" alt="BT-SHOP" />
                            </a>
                        </td>*@
                        <td>
                            @*<img src="~/Content/Images/baner.gif" />*@
                            @*<embed src="~/Content/Images/flash baner.swf" quality="high" type="application/x-shockwave-flash" wmode="transparent" width="740" height="130" pluginspage="http://www.macromedia.com/go/getflashplayer" allowScriptAccess="always"></embed>*@
                            <embed src="~/Content/Images/flash baner 1.swf" quality="high" type="application/x-shockwave-flash" wmode="transparent" width="958" height="130" pluginspage="http://www.macromedia.com/go/getflashplayer" allowScriptAccess="always"></embed>
                        </td>
                    </tr>
                </table>
            </div>
            @********************************************* GIO HANG *****************************************@
            <div id="ShoppingCart">
                <i class="fa fa-shopping-cart"></i>&nbsp;Bạn đang có <span>@Model.CartItemCount.ToString("00") sản phẩm</span> trong giỏ hàng. Tổng tiền <span>@ChoMayTinh.SharedFunc.FormatVnd(Model.TotalPrice)<sup>đ</sup>&nbsp;&nbsp;|&nbsp;&nbsp;<a href="@Url.RouteUrl(ChoMayTinh.Constants.Route.GioHang)/" title="Xem giỏ hàng">Xem giỏ hàng</a></span><span style="float: right; margin-right: 5px; color: white; font-weight: bold;"><i class="fa fa-phone"></i>&nbsp;Hotline : 0937.03.16.18</span>
            </div>
            <div id="sliderFrame">
                <div id="slider">
                    @For Each item In Model.SlideShow
                        If item.Link IsNot Nothing AndAlso item.Link.Length > 0 Then
                        @<a href="@Html.Raw(item.Link)" target="_blank">
                            <img src="@item.Image" />
                        </a>    
                        Else
                        @<img src="@item.Image" />
                        End If
                    Next
                </div>
            </div>
            <div id="LeftColumn">
                @********** DANH MUC SAN PHAM *********@
                <div class="cmt-title">
                    <i class="fa fa-list"></i>&nbsp;Danh mục sản phẩm
                </div>
                @Html.Action("Menu", "Home")
                @********** HO TRO TRUC TUYEN *********@
                <div class="cmt-title margin-top">
                    <i class="fa fa-comments"></i>&nbsp;Hỗ trợ trực tuyến
                </div>
                <ul id="SupportOnline" class="cmt-border">
                    <li>
                        <a href="ymsgr:sendIM?thangquynho012001">
                            <img style="height: 90px" src="http://opi.yahoo.com/online?u=thangquynho012001&amp;m=g&amp;t=14&amp;l=us" /><br />
                            KD1 : 0937.031.618
                        </a>
                    </li>
                    <li>
                        <a href="ymsgr:sendIM?timbuontimhoada">
                            <img style="height: 90px" src="http://opi.yahoo.com/online?u=timbuontimhoada&amp;m=g&amp;t=14&amp;l=us" /><br />
                            KD2 : 0164.78.78.764
                        </a>
                    </li>
                </ul>
                @********** facebook*********@
                <div class="fb-like-box item" id="facebook" style="margin-top: 15px" data-href="https://www.facebook.com/doxuatkhau" data-width="200" data-height="385" data-show-faces="true" data-header="true" data-stream="false" data-show-border="true"></div>
                @*<div style="margin-top: 5px">
                    <object width="200" height="350">
                        <embed src="~/Content/images/flash.swf" width="200" height="350" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" menu="false" wmode="transparent">
                        </embed>
                    </object>
                </div>*@
                @********** THONG TIN MUA BAN *********@
                <div class="cmt-title margin-top">
                    <i class="fa fa-info-circle"></i>&nbsp;Thông tin mua bán
                </div>
                <ul id="TradeInformation" class="cmt-border">
                    <li><a href="@Url.RouteUrl(ChoMayTinh.Constants.Route.HuongDanMuaHang)/"><i class="fa fa-minus"></i>&nbsp;@ConfigurationManager.AppSettings(ChoMayTinh.Constants.Route.HuongDanMuaHangRoute)</a></li>
                    <li><a href="@Url.RouteUrl(ChoMayTinh.Constants.Route.TaiKhoanNganHang)/"><i class="fa fa-minus"></i>&nbsp;@ConfigurationManager.AppSettings(ChoMayTinh.Constants.Route.TaiKhoanNganHangRoute)</a></li>
                    <li><a href="@Url.RouteUrl(ChoMayTinh.Constants.Route.ChinhSachDoiTraHang)/"><i class="fa fa-minus"></i>&nbsp;@ConfigurationManager.AppSettings(ChoMayTinh.Constants.Route.ChinhSachDoiTraHangRoute)</a></li>
                    <li><a href="@Url.RouteUrl(ChoMayTinh.Constants.Route.HopTacKinhDoanh)/"><i class="fa fa-minus"></i>&nbsp;@ConfigurationManager.AppSettings(ChoMayTinh.Constants.Route.HopTacKinhDoanhRoute)</a></li>
                </ul>

                @********** THONG TIN CAN BIET *********@
                <div class="cmt-title margin-top">
                    <i class="fa fa-info"></i>&nbsp;Thông tin cần biết
                </div>
                <ul id="NeccessaryInformation" class="cmt-border">
                    <li><a target="_blank" href="http://www.vietcombank.com.vn/exchangerates/Default.aspx"><i class="fa fa-usd"></i>&nbsp;Tỉ giá ngoại tệ</a></li>
                    <li><a target="_blank" href="http://www.giavang.net/"><i class="fa fa-money"></i>&nbsp;Giá vàng</a></li>
                    <li><a target="_blank" href="http://chungkhoan.24h.com.vn/"><i class="fa fa-info-circle"></i>&nbsp;Thông tin chứng khoán</a></li>
                </ul>

                @********** THONG KE TRUY CAP *********@
                <div class="cmt-title margin-top">
                    <i class="fa fa-signal"></i>&nbsp;Thống kê truy cập
                </div>
                <div style="text-align: center; padding: 10px;" class="cmt-border">
                    <!-- Histats.com  START  (standard)-->
                    <script type="text/javascript">document.write(unescape("%3Cscript src=%27http://s10.histats.com/js15.js%27 type=%27text/javascript%27%3E%3C/script%3E"));</script>
                    <a href="http://www.histats.com" target="_blank" title="site stats">
                        <script type="text/javascript">
                        try {
                            Histats.start(1, 3079263, 4, 422, 112, 75, "00011111");
                            Histats.track_hits();
                        } catch (err) { };
                        </script>
                    </a>
                    <noscript><a href="http://www.histats.com" target="_blank"><img src="http://sstatic1.histats.com/0.gif?3079263&101" alt="site stats" border="0"></a></noscript>
                    <!-- Histats.com  END  -->
                </div>
                @********** Quảng Cáo *********@
                @Html.Action("Advertisement", "Home")
            </div>
            <div id="RightColumn">
                @RenderBody()
            </div>
        </div>
    </article>
    <footer>
        <div style="height:5px;background-color:#C2272D"></div>
        <div class="content-wrapper">
            <div id="footer-left">
                <br />
                <span class="tile-footer">BT SHOP</span><br />
                <br />
                <span style="font-size: 0.9em">Chuyên cung cấp sỉ lẻ thời trang thời trang xuất khẩu, thời trang trẻ em cao cấp với rất nhiều sản phẩm đẹp chất lượng, mẫu mã đa dạng hợp thờ trang thích hợp cho cho bạn và gia đình đi chơi hay dự tiệc.<br />
                    <br />
                    DC : 38/2 QL20 Gia Yên,Gia Kiệm - Thống Nhất - Đồng Nai<br />
                    DT:  0937.031.618 Email: <a>info@doxuatkhau.net</a></span><br />
                <br />
                <span style="font-size: 0.8em"><a style="color: #fff" href="http://chomaytinh.com.vn/">Designed by CMT Co., Ltd</a></span>
            </div>
        </div>
        <div class="content-wrapper">
            <div id="footer-center">
                <br />
                <span class="tile-footer">SẢN PHẨM</span><br />
                <br />
                <a class="footer-a" target="_blank" href="#"><i class="icon-star icon-white funtion-footer"></i>Thời trang cho bé trai</a><br />
                <a class="footer-a" target="_blank" href="#"><i class="icon-star icon-white funtion-footer"></i>Thời trang cho bé gái</a><br />
                <a class="footer-a" target="_blank" href="#"><i class="icon-star icon-white funtion-footer"></i>Các sản phẩm bán chạy</a><br />
                <a class="footer-a" target="_blank" href="#"><i class="icon-star icon-white funtion-footer"></i>Sản Phẩm khuyến mãi</a><br />
                <a class="footer-a" target="_blank" href="#"><i class="icon-star icon-white funtion-footer"></i>Hàng mới về</a><br />
            </div>
        </div>
        <div id="footer-right">
            <br />
            <span class="tile-footer">THÔNG TIN MUA BÁN</span><br />
            <br />
            <a class="footer-a" target="_blank" href="#"><i class="icon-minus icon-white funtion-footer"></i>Chuyên cung cấp sỉ thời trang trẻ em</a><br />
            <a class="footer-a" target="_blank" href="#"><i class="icon-minus icon-white funtion-footer"></i>Đặt hàng trực tuyến</a><br />
            <a class="footer-a" target="_blank" href="#"><i class="icon-minus icon-white funtion-footer"></i>Chính sách đổi trả hàng</a><br />
            <a class="footer-a" target="_blank" href="#"><i class="icon-minus icon-white funtion-footer"></i>Đặt áo số lượng lớn</a><br />
        </div>
        @*<div class="content-wrapper">
            <span>Copy right by CMT</span>
        </div>*@
    </footer>

    <div id="dlgAlert" class="modal hide fade">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h3 id="dlgAlertTitle">Cảnh báo</h3>
        </div>
        <div class="modal-body" style="color: red;">
            <i class="fa fa-exclamation-triangle" style="font-size: 2em;"></i>&nbsp;&nbsp;<span id="dlgAlertMessage">One fine body…</span>
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

    <!-- AddThis Button BEGIN -->
    <div class="addthis_toolbox addthis_floating_style addthis_32x32_style" style="left: 0px; top: 30%; background-color: #444444; border-radius: 0px;">
        <a class="addthis_button_preferred_1"></a>
        <a class="addthis_button_preferred_2"></a>
        <a class="addthis_button_preferred_3"></a>
        <a class="addthis_button_preferred_4"></a>
        <a class="addthis_button_compact"></a>
    </div>
    <script type="text/javascript" src="//s7.addthis.com/js/300/addthis_widget.js#pubid=ra-533c15b271ac96c4"></script>
    <!-- AddThis Button END -->

    <div id="divAdRight" style="DISPLAY: none; POSITION: absolute; TOP: 0px;">      
<a href="@Url.Content("~")"><img src="@Url.Content("~/Content/images/adright.png")" width="150" /></a> 
</div>      
<div id="divAdLeft" style="DISPLAY: none; POSITION: absolute; TOP: 0px;">       
</div>       
<script>
    function FloatTopDiv() {
        startLX = ((document.body.clientWidth - MainContentW) / 2) - LeftBannerW - LeftAdjust, startLY = TopAdjust + 80;
        startRX = ((document.body.clientWidth - MainContentW) / 2) + MainContentW + RightAdjust, startRY = TopAdjust + 80;
        var d = document;
        function ml(id) {
            var el = d.getElementById ? d.getElementById(id) : d.all ? d.all[id] : d.layers[id];
            el.sP = function (x, y) { this.style.left = x + 'px'; this.style.top = y + 'px'; };
            el.x = startRX;
            el.y = startRY;
            return el;
        }
        function m2(id) {
            var e2 = d.getElementById ? d.getElementById(id) : d.all ? d.all[id] : d.layers[id];
            e2.sP = function (x, y) { this.style.left = x + 'px'; this.style.top = y + 'px'; };
            e2.x = startLX;
            e2.y = startLY;
            return e2;
        }
        window.stayTopLeft = function () {
            if (document.documentElement && document.documentElement.scrollTop)
                var pY = document.documentElement.scrollTop;
            else if (document.body)
                var pY = document.body.scrollTop;
            if (document.body.scrollTop > 30) { startLY = 3; startRY = 3; } else { startLY = TopAdjust; startRY = TopAdjust; };
            ftlObj.y += (pY + startRY - ftlObj.y) / 16;
            ftlObj.sP(ftlObj.x, ftlObj.y);
            ftlObj2.y += (pY + startLY - ftlObj2.y) / 16;
            ftlObj2.sP(ftlObj2.x, ftlObj2.y);
            setTimeout("stayTopLeft()", 1);
        }
        ftlObj = ml("divAdRight");
        //stayTopLeft();      
        ftlObj2 = m2("divAdLeft");
        stayTopLeft();
    }
    function ShowAdDiv() {
        var objAdDivRight = document.getElementById("divAdRight");
        var objAdDivLeft = document.getElementById("divAdLeft");
        if (document.body.clientWidth < 1000) {
            objAdDivRight.style.display = "none";
            objAdDivLeft.style.display = "none";
        }
        else {
            objAdDivRight.style.display = "block";
            objAdDivLeft.style.display = "block";
            FloatTopDiv();
        }
    }
</script>       
<script>
    document.write("<script type='text/javascript' language='javascript'>MainContentW = 1000;LeftBannerW = 125;RightBannerW = 125;LeftAdjust = 5;RightAdjust = 5;TopAdjust = 80;ShowAdDiv();window.onresize=ShowAdDiv;;<\/script>");
</script>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/jquery.cookie")
    @Scripts.Render("~/bundles/jqueryui")
    @Scripts.Render("~/bundles/bootstrap-js")
    @Scripts.Render("~/bundles/imageslider")
    @Scripts.Render("~/bundles/script")
    @RenderSection("scripts", required:=False)
</body>
</html>





