Imports System.Web
Imports System.Web.Optimization

Public Class BundleConfig
    ' For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
    Public Shared Sub RegisterBundles(ByVal bundles As BundleCollection)
        bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
                   "~/Scripts/jquery-{version}.js"))

        bundles.Add(New ScriptBundle("~/bundles/jqueryui").Include(
                    "~/Scripts/jquery-ui-1.10.3.custom.js"))

        bundles.Add(New ScriptBundle("~/bundles/jqueryval").Include(
                    "~/Scripts/jquery.unobtrusive*",
                    "~/Scripts/jquery.validate*"))

        '' jquery masked input plugin
        bundles.Add(New ScriptBundle("~/bundles/jquery.maskedinput").Include(
                    "~/Scripts/jquery.maskedinput.js"))

        '' jquery cookie
        bundles.Add(New ScriptBundle("~/bundles/jquery.cookie").Include(
                    "~/Scripts/jquery.cookie.js"))

        ' Use the development version of Modernizr to develop with and learn from. Then, when you're
        ' ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-*"))

        bundles.Add(New StyleBundle("~/Content/themes/base/css").Include(
                    "~/Content/themes/base/jquery.ui.core.css",
                    "~/Content/themes/base/jquery.ui.resizable.css",
                    "~/Content/themes/base/jquery.ui.selectable.css",
                    "~/Content/themes/base/jquery.ui.accordion.css",
                    "~/Content/themes/base/jquery.ui.autocomplete.css",
                    "~/Content/themes/base/jquery.ui.button.css",
                    "~/Content/themes/base/jquery.ui.dialog.css",
                    "~/Content/themes/base/jquery.ui.slider.css",
                    "~/Content/themes/base/jquery.ui.tabs.css",
                    "~/Content/themes/base/jquery.ui.datepicker.css",
                    "~/Content/themes/base/jquery.ui.progressbar.css",
                    "~/Content/themes/base/jquery.ui.theme.css"))

        '' Site CSS
        bundles.Add(New StyleBundle("~/Content/css").Include(
                    "~/Content/site.css",
                    "~/Content/CartList.css",
                    "~/Content/Order.css",
                    "~/Content/ProductList.css",
                    "~/Content/Product.css",
                    "~/Content/NewsList.css",
                    "~/Content/NewsDetail.css"))

        '' Site script
        bundles.Add(New ScriptBundle("~/bundles/script").Include(
                    "~/Scripts/javascript.js",
                    "~/Scripts/CartList.js",
                    "~/Scripts/Order.js"))

        '' Management Style
        bundles.Add(New StyleBundle("~/Content/Management").Include(
                    "~/Content/Management.css",
                    "~/Content/MenuLevel.css",
                    "~/Content/OrderDetail.css"))

        '' Management script
        bundles.Add(New ScriptBundle("~/bundles/Management").Include(
                    "~/Scripts/Management.js",
                    "~/Scripts/ProductList.js",
                    "~/Scripts/Product.js",
                    "~/Scripts/MenuLevel.js",
                    "~/Scripts/SlideShow.js"))

        '' Font
        bundles.Add(New StyleBundle("~/Content/font-awesome/css/css").Include(
                    "~/Content/font-awesome/css/font-awesome.css"))

        '' bootstrap library
        bundles.Add(New StyleBundle("~/Content/bootstrap-css").Include("~/Content/bootstrap/css/bootstrap*"))
        bundles.Add(New ScriptBundle("~/bundles/bootstrap-js").Include("~/Scripts/bootstrap*"))

        '' Custom jquery ui
        bundles.Add(New StyleBundle("~/Content/css-custom").Include("~/Content/jquery-ui-1.10.3.custom.css"))        

        ''ImageSlider
        bundles.Add(New ScriptBundle("~/bundles/imageslider").Include("~/ImageSlider/js-image-slider.js"))
        bundles.Add(New StyleBundle("~/Content/imageslider").Include(
                    "~/ImageSlider/js-image-slider.css",
                    "~/ImageSlider/generic.css"))

        '' ckeditor
        bundles.Add(New ScriptBundle("~/bundles/ckeditor").Include("~/ckeditor/ckeditor.js"))
        bundles.Add(New ScriptBundle("~/bundles/adapters/jquery").Include("~/ckeditor/adapters/jquery.js"))

        '' Login
        bundles.Add(New StyleBundle("~/Content/Login").Include("~/Content/Login.css"))

        '' Bootstrap select
        bundles.Add(New StyleBundle("~/Content/Bootstrap-Select").Include("~/bootstrap-select/bootstrap-select.css"))
        bundles.Add(New ScriptBundle("~/bundles/Bootstrap-Select").Include("~/bootstrap-select/bootstrap-select.js"))
    End Sub
End Class