#pragma checksum "C:\Users\deepa\Desktop\mfpe\MFPE-master\EcommercePortalClient\Views\Product\GetProductByName.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7c28319443484283a5e0b88773569c20b631700d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_GetProductByName), @"mvc.1.0.view", @"/Views/Product/GetProductByName.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\deepa\Desktop\mfpe\MFPE-master\EcommercePortalClient\Views\_ViewImports.cshtml"
using EcommercePortalClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\deepa\Desktop\mfpe\MFPE-master\EcommercePortalClient\Views\_ViewImports.cshtml"
using EcommercePortalClient.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c28319443484283a5e0b88773569c20b631700d", @"/Views/Product/GetProductByName.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54efc102f830d4495d20e975969a23ce1481d099", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_GetProductByName : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EcommercePortalClient.Models.Product>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\deepa\Desktop\mfpe\MFPE-master\EcommercePortalClient\Views\Product\GetProductByName.cshtml"
  
    ViewData["Title"] = "GetProductByName";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>Requested Product</h1>\n\n<div>\n    <hr />\n    <dl class=\"row\">\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 13 "C:\Users\deepa\Desktop\mfpe\MFPE-master\EcommercePortalClient\Views\Product\GetProductByName.cshtml"
       Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 16 "C:\Users\deepa\Desktop\mfpe\MFPE-master\EcommercePortalClient\Views\Product\GetProductByName.cshtml"
       Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 19 "C:\Users\deepa\Desktop\mfpe\MFPE-master\EcommercePortalClient\Views\Product\GetProductByName.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 22 "C:\Users\deepa\Desktop\mfpe\MFPE-master\EcommercePortalClient\Views\Product\GetProductByName.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 25 "C:\Users\deepa\Desktop\mfpe\MFPE-master\EcommercePortalClient\Views\Product\GetProductByName.cshtml"
       Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 28 "C:\Users\deepa\Desktop\mfpe\MFPE-master\EcommercePortalClient\Views\Product\GetProductByName.cshtml"
       Write(Html.DisplayFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 31 "C:\Users\deepa\Desktop\mfpe\MFPE-master\EcommercePortalClient\Views\Product\GetProductByName.cshtml"
       Write(Html.DisplayNameFor(model => model.Image_Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 34 "C:\Users\deepa\Desktop\mfpe\MFPE-master\EcommercePortalClient\Views\Product\GetProductByName.cshtml"
       Write(Html.DisplayFor(model => model.Image_Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 37 "C:\Users\deepa\Desktop\mfpe\MFPE-master\EcommercePortalClient\Views\Product\GetProductByName.cshtml"
       Write(Html.DisplayNameFor(model => model.Rating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 40 "C:\Users\deepa\Desktop\mfpe\MFPE-master\EcommercePortalClient\Views\Product\GetProductByName.cshtml"
       Write(Html.DisplayFor(model => model.Rating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n    </dl>\n    <a class=\"btn btn-success\"");
            BeginWriteAttribute("href", " href=\"", 1192, "\"", 1238, 1);
#nullable restore
#line 43 "C:\Users\deepa\Desktop\mfpe\MFPE-master\EcommercePortalClient\Views\Product\GetProductByName.cshtml"
WriteAttributeValue("", 1199, Url.Action("AddToCart","ProceedToBuy"), 1199, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">AddToCart</a>\n</div>\n<div>\n    \n</div>\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EcommercePortalClient.Models.Product> Html { get; private set; }
    }
}
#pragma warning restore 1591