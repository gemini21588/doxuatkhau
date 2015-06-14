Public Class Constants   
    Public Class Route
        ''' <summary>
        ''' Giỏ hàng route name
        ''' </summary>
        ''' <remarks></remarks>
        Public Const GioHang As String = "GioHang"

        ''' <summary>
        ''' Giỏ hàng route
        ''' </summary>
        ''' <remarks></remarks>
        Public Const GioHangRoute As String = "gio-hang"

        ''' <summary>
        ''' Thông tin khách hàng route name
        ''' </summary>
        ''' <remarks></remarks>
        Public Const ThongTinKhachHang As String = "ThongTinKhachHang"

        ''' <summary>
        ''' Thông tin khách hàng route
        ''' </summary>
        ''' <remarks></remarks>
        Public Const ThongTinKhachHangRoute As String = "thong-tin-khach-hang"

        Public Const DanhSachSanPham As String = "DanhSachSanPham"
        Public Const DanhSachSanPhamRoute As String = "danh-sach-san-pham"

        Public Const SanPham As String = "SanPham"
        Public Const SanPhamRoute As String = "san-pham"

        Public Const DanhSachTinTuc As String = "DanhSachTinTuc"
        Public Const DanhSachTinTucRoute As String = "danh-sach-tin-tuc"

        Public Const TinTuc As String = "TinTuc"
        Public Const TinTucRoute As String = "tin-tuc"

        Public Const DanhSachKhuyenmai As String = "DanhSachKhuyenMai"
        Public Const DanhSachKhuyenMaiRoute As String = "danh-sach-khuyen-mai"

        Public Const KhuyenMai As String = "KhuyenMai"
        Public Const KhuyenMaiRoute As String = "khuyen-mai"

        Public Const LienHe As String = "LienHe"
        Public Const LienHeRoute As String = "lien-he"

        Public Const GioiThieu As String = "GioiThieu"
        Public Const GioiThieuRoute As String = "gioi-thieu"

        Public Const TimKiem As String = "TimKiem"
        Public Const TimKiemRoute As String = "tim-kiem"

        Public Const HuongDanMuaHang As String = "HuongDanMuaHang"
        Public Const HuongDanMuaHangRoute As String = "huong-dan-mua-hang"

        Public Const TaiKhoanNganHang As String = "TaiKhanNganHang"
        Public Const TaiKhoanNganHangRoute As String = "tai-khoan-ngan-hang"

        Public Const ChinhSachDoiTraHang As String = "ChinhSachDoiTraHang"
        Public Const ChinhSachDoiTraHangRoute As String = "chinh-sach-doi-tra-hang"

        Public Const HopTacKinhDoanh As String = "HopTacKinhDoanh"
        Public Const HopTacKinhDoanhRoute As String = "hop-tac-kinh-doanh"
    End Class

    Public Enum MenuLevel
        Category = 1
        Maker
    End Enum

    Public Enum Command
        None = 0
        AddNew
        Update
        Delete
    End Enum

    Public Class MenuLevelName
        Public Const MenuLevel1 As String = "Menu cấp 1"
        Public Const MenuLevel2 As String = "Menu cấp 2"
    End Class

    Public Class AppSetting
        ''' <summary>
        ''' Domain
        ''' </summary>
        ''' <remarks></remarks>
        Public Const Domain As String = "Domain"

        ''' <summary>
        ''' Description
        ''' </summary>
        ''' <remarks></remarks>
        Public Const Description As String = "Description"

        ''' <summary>
        ''' Keywords
        ''' </summary>
        ''' <remarks></remarks>
        Public Const Keywords As String = "Keywords"

        ''' <summary>
        ''' Số sản phẩm mỗi trang
        ''' </summary>
        ''' <remarks></remarks>
        Public Const ProductPerPage As String = "ProductPerPage"

        ''' <summary>
        ''' ItemPerPage
        ''' </summary>
        ''' <remarks></remarks>
        Public Const ItemPerPage As String = "ItemPerPage"

        ''' <summary>
        ''' NumberOfHotProduct
        ''' </summary>
        ''' <remarks></remarks>
        Public Const NumberOfHotProduct As String = "NumberOfHotProduct"

        ''' <summary>
        ''' NumberOfNewProduct
        ''' </summary>
        ''' <remarks></remarks>
        Public Const NumberOfNewProduct As String = "NumberOfNewProduct"

        ''' <summary>
        ''' NumberOfNewsInHomePage
        ''' </summary>
        ''' <remarks></remarks>
        Public Const NumberOfNewsInHomePage As String = "NumberOfNewsInHomePage"

        ''' <summary>
        ''' NewsPerPage
        ''' </summary>
        ''' <remarks></remarks>
        Public Const NewsPerPage As String = "NewsPerPage"

        ''' <summary>
        ''' NumberOfProductSameType
        ''' </summary>
        ''' <remarks></remarks>
        Public Const NumberOfProductSameType As String = "NumberOfProductSameType"

        Public Const QuangCao As String = "quang-cao"
    End Class

    Public Const IndexFollow As String = "INDEX, FOLLOW"
    Public Const NoIndexNoFollow As String = "NOINDEX, NOFOLLOW"
End Class
