' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
' visit http://go.microsoft.com/?LinkId=9394802
Imports System.Web.Http
Imports System.Web.Optimization
Imports System.Net
Imports System.Threading

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Shared keepAliveThread As Thread = New Thread(AddressOf KeepAlive)

    Sub Application_Start()
        AreaRegistration.RegisterAllAreas()

        WebApiConfig.Register(GlobalConfiguration.Configuration)
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
        AuthConfig.RegisterAuth()

        keepAliveThread.Start()
    End Sub

    Sub Application_End()

        keepAliveThread.Abort()

    End Sub

    Shared Sub KeepAlive()

        'While True
        '    Dim rnd As New Random
        '    Dim intRand As Integer = rnd.Next()

        '    Dim req As WebRequest = WebRequest.Create("http://fashionkids.com.vn/Home/KeepAlive?q=" & intRand.ToString())
        '    req.GetResponse()
        '    Try
        '        Thread.Sleep(240000)
        '    Catch ex As ThreadAbortException
        '    End Try
        'End While
    End Sub
End Class
