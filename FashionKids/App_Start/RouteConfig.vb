Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing

Public Class RouteConfig
    Public Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        routes.MapRoute( _
            name:=Constants.Route.GioHang, _
            url:=Constants.Route.GioHangRoute, _
            defaults:=New With {.controller = "Home", .action = "CartList", .id = UrlParameter.Optional} _
        )

        routes.MapRoute( _
            name:=Constants.Route.ThongTinKhachHang, _
            url:=Constants.Route.ThongTinKhachHangRoute, _
            defaults:=New With {.controller = "Home", .action = "Order", .id = UrlParameter.Optional} _
        )

        routes.MapRoute( _
            name:=Constants.Route.LienHe, _
            url:=Constants.Route.LienHeRoute, _
            defaults:=New With {.controller = "Home", .action = "ContentPage", .link = Constants.Route.LienHeRoute} _
        )

        routes.MapRoute( _
            name:=Constants.Route.GioiThieu, _
            url:=Constants.Route.GioiThieuRoute, _
            defaults:=New With {.controller = "Home", .action = "ContentPage", .link = Constants.Route.GioiThieuRoute} _
        )

        routes.MapRoute( _
            name:=Constants.Route.HuongDanMuaHang, _
            url:=Constants.Route.HuongDanMuaHangRoute, _
            defaults:=New With {.controller = "Home", .action = "ContentPage", .link = Constants.Route.HuongDanMuaHangRoute} _
        )

        routes.MapRoute( _
            name:=Constants.Route.TaiKhoanNganHang, _
            url:=Constants.Route.TaiKhoanNganHangRoute, _
            defaults:=New With {.controller = "Home", .action = "ContentPage", .link = Constants.Route.TaiKhoanNganHangRoute} _
        )

        routes.MapRoute( _
            name:=Constants.Route.ChinhSachDoiTraHang, _
            url:=Constants.Route.ChinhSachDoiTraHangRoute, _
            defaults:=New With {.controller = "Home", .action = "ContentPage", .link = Constants.Route.ChinhSachDoiTraHangRoute} _
        )

        routes.MapRoute( _
            name:=Constants.Route.HopTacKinhDoanh, _
            url:=Constants.Route.HopTacKinhDoanhRoute, _
            defaults:=New With {.controller = "Home", .action = "ContentPage", .link = Constants.Route.HopTacKinhDoanhRoute} _
        )

        routes.MapRoute( _
            name:=Constants.Route.TimKiem, _
            url:=Constants.Route.TimKiemRoute & "/{q}", _
            defaults:=New With {.controller = "Home", .action = "SearchProduct", .q = UrlParameter.Optional} _
        )

        routes.MapRoute( _
            name:="Management", _
            url:="Management/{action}/{id}", _
            defaults:=New With {.controller = "Management", .action = "Index", .id = UrlParameter.Optional} _
        )

        routes.MapRoute( _
            name:=Constants.Route.DanhSachSanPham, _
            url:="{pCategory}/{pMaker}/{pCurrentPage}/", _
            defaults:=New With {.controller = "Home", .action = "ProductList", .pCurrentPage = UrlParameter.Optional}, _
            constraints:=New With {.pCurrentPage = "\d+"}
        )

        routes.MapRoute( _
            name:=Constants.Route.SanPham, _
            url:="{pCategory}/{pMaker}/{pProduct}/", _
            defaults:=New With {.controller = "Home", .action = "Product", .id = UrlParameter.Optional} _
        )

        routes.MapRoute( _
            name:=Constants.Route.DanhSachTinTuc, _
            url:=Constants.Route.TinTucRoute & "/{page}", _
            defaults:=New With {.controller = "Home", .action = "NewsList", .page = UrlParameter.Optional}, _
            constraints:=New With {.page = "\d+"}
        )

        routes.MapRoute( _
            name:=Constants.Route.TinTuc, _
            url:=Constants.Route.TinTucRoute & "/{link}", _
            defaults:=New With {.controller = "Home", .action = "NewsDetail"} _
        )

        routes.MapRoute( _
            name:=Constants.Route.DanhSachKhuyenmai, _
            url:=Constants.Route.KhuyenMaiRoute & "/{page}", _
            defaults:=New With {.controller = "Home", .action = "PromotionList", .page = UrlParameter.Optional}, _
            constraints:=New With {.page = "\d+"}
        )

        routes.MapRoute( _
            name:=Constants.Route.KhuyenMai, _
            url:=Constants.Route.KhuyenMaiRoute & "/{link}", _
            defaults:=New With {.controller = "Home", .action = "PromotionDetail"} _
        )

        routes.MapRoute( _
            name:="Default", _
            url:="{controller}/{action}/{id}", _
            defaults:=New With {.controller = "Home", .action = "Index", .id = UrlParameter.Optional} _
        )

        routes.MapRoute( _
            name:="CatchAll", _
            url:="{*catchall}", _
            defaults:=New With {.controller = "Home", .action = "Index", .id = UrlParameter.Optional} _
        )
    End Sub
End Class