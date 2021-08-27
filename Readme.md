<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128552085/14.1.8%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T191698)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/Controllers/HomeController.vb))
* [GridType.cs](./CS/Models/GridType.cs) (VB: [GridType.vb](./VB/Models/GridType.vb))
* [GridViewSettingsHelper.cs](./CS/Models/GridViewSettingsHelper.cs) (VB: [GridViewSettingsHelper.vb](./VB/Models/GridViewSettingsHelper.vb))
* [Invoice.cs](./CS/Models/Invoice.cs) (VB: [Invoice.vb](./VB/Models/Invoice.vb))
* [Product.cs](./CS/Models/Product.cs) (VB: [Product.vb](./VB/Models/Product.vb))
* [Details.cshtml](./CS/Views/Home/Details.cshtml)
* **[GridViewPartial.cshtml](./CS/Views/Home/GridViewPartial.cshtml)**
* [Index.cshtml](./CS/Views/Home/Index.cshtml)
<!-- default file list end -->
# Isolate extension settings into separate helper / a partial view for multiple extensions


This example is more specific to ASP.NET MVC platform rather than to our extensions. It illustrates two popular techniques which can be used with any extensions (we chose a <a href="https://documentation.devexpress.com/#AspNet/CustomDocument8998">GridView</a> extension for this example):<br><br>1) A separate helper class that holds extension settings. This technique might be useful in numerous scenarios. A couple of examples:<br><br><a href="https://www.devexpress.com/Support/Center/p/E3898">E3898 - How to export GridView data to different rich text formats</a> <br><a href="https://www.devexpress.com/Support/Center/p/E3997">E3997 - Scheduler - Lesson 3 - How to Use Scheduler in complex views</a> <br><br>In our example we define the most flexible form of extension method in the setting helper class:<br>


```cs
public static GridViewSettings CreateGridViewSettings(this WebViewPage view, GridType gridType)
```




```vb
<System.Runtime.CompilerServices.Extension> _
Public Function CreateGridViewSettings(ByVal view As WebViewPage, ByVal gridType As GridType) As GridViewSettings
```


Note that we use the <a href="http://msdn.microsoft.com/en-us/library/system.web.mvc.webviewpage.aspx">WebViewPage Class (System.Web.Mvc)</a> class as the first parameter here. This allow us to access all the APIs which are available in the regular MVC views. For instance, you can use "view.Html", "view.Url", "view.ViewData", etc. members to access HtmlHelper, UrlHelper (both of them are illustrated in the source code of this example), ViewData and other APIs in convenient manner.<br><br>2) A single partial view (GridViewPartial.cshtml / GridViewPartial.vbhtml) is used to display multiple extensions. We pass the "gridType" parameter to the corresponding action method to determine which extension should actually be rendered:<br>


```cs
@Html.Action("GridViewPartial", new { gridType = GridType.Invoices })
```




```vb
@Html.Action("GridViewPartial", New With {.gridType = GridType.Invoices})
```


This parameter value comes up to the extension method in the setting helper class (we use the <a href="http://www.codeproject.com/Articles/476967/WhatplusisplusViewData-cplusViewBagplusandplusTem">ViewData</a> dictionary to pass it to the partial view) and here we use it to render specific content.<br><br><strong>See Also:</strong><br><a href="http://msdn.microsoft.com/en-us//library/bb383977.aspx">Extension Methods (C# Programming Guide)</a>

<br/>


