Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing

Public Module RouteConfig
    Public Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        routes.MapRoute(
            name:="CapturaIndex",
            url:="captura",
            defaults:=New With {.controller = "Captura", .action = "Index", .id = UrlParameter.Optional}
        )
        routes.MapRoute(
            name:="CapturaSave",
            url:="captura/save",
            defaults:=New With {.controller = "Captura", .action = "saveTxt", .id = UrlParameter.Optional}
        )
    End Sub
End Module