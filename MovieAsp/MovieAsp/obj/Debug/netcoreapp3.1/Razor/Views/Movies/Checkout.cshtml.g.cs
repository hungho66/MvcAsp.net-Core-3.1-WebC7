#pragma checksum "/Users/apple/Projects/MovieAsp/MovieAsp/Views/Movies/Checkout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "499fef7049147f4e168ac76d3b414632ed0fe8ab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movies_Checkout), @"mvc.1.0.view", @"/Views/Movies/Checkout.cshtml")]
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
#line 1 "/Users/apple/Projects/MovieAsp/MovieAsp/Views/_ViewImports.cshtml"
using MovieAsp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/apple/Projects/MovieAsp/MovieAsp/Views/_ViewImports.cshtml"
using MovieAsp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"499fef7049147f4e168ac76d3b414632ed0fe8ab", @"/Views/Movies/Checkout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84a444dea7136a141bf4785b1bdd4d0365ab0910", @"/Views/_ViewImports.cshtml")]
    public class Views_Movies_Checkout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MovieAsp.Models.ShippingDetail>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/apple/Projects/MovieAsp/MovieAsp/Views/Movies/Checkout.cshtml"
  
    ViewBag.Title = "Checkout";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>Checkout</h2>\n");
#nullable restore
#line 6 "/Users/apple/Projects/MovieAsp/MovieAsp/Views/Movies/Checkout.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/apple/Projects/MovieAsp/MovieAsp/Views/Movies/Checkout.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-horizontal\">\n        <hr />\n        ");
#nullable restore
#line 11 "/Users/apple/Projects/MovieAsp/MovieAsp/Views/Movies/Checkout.cshtml"
   Write(Html.ValidationSummary(true, "", new
        {
        @class = "text-danger"
        }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        <div class=\"form-group\">\n            ");
#nullable restore
#line 16 "/Users/apple/Projects/MovieAsp/MovieAsp/Views/Movies/Checkout.cshtml"
       Write(Html.LabelFor(model => model.Name,
            htmlAttributes: new { @class = "control-label colmd-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <div class=\"col-md-10\">\n                ");
#nullable restore
#line 19 "/Users/apple/Projects/MovieAsp/MovieAsp/Views/Movies/Checkout.cshtml"
           Write(Html.EditorFor(model => model.Name,
                new { htmlAttributes = new { @class = "formcontrol" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                ");
#nullable restore
#line 21 "/Users/apple/Projects/MovieAsp/MovieAsp/Views/Movies/Checkout.cshtml"
           Write(Html.ValidationMessageFor(model =>
                model.Name, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n        </div>\n        <div class=\"form-group\">\n            ");
#nullable restore
#line 26 "/Users/apple/Projects/MovieAsp/MovieAsp/Views/Movies/Checkout.cshtml"
       Write(Html.LabelFor(model => model.Address,
            htmlAttributes: new { @class = "control-label col-md2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <div class=\"col-md-10\">\n                ");
#nullable restore
#line 29 "/Users/apple/Projects/MovieAsp/MovieAsp/Views/Movies/Checkout.cshtml"
           Write(Html.EditorFor(model => model.Address,
                new
                {
                    htmlAttributes = new
                    {
                        @class = "form-control"
                    }
                }));

#line default
#line hidden
#nullable disable
            WriteLiteral("}\n                ");
#nullable restore
#line 37 "/Users/apple/Projects/MovieAsp/MovieAsp/Views/Movies/Checkout.cshtml"
           Write(Html.ValidationMessageFor(model =>
                model.Address, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n        </div>\n        <div class=\"form-group\">\n            ");
#nullable restore
#line 42 "/Users/apple/Projects/MovieAsp/MovieAsp/Views/Movies/Checkout.cshtml"
       Write(Html.LabelFor(model =>
            model.ReleaseDate, htmlAttributes: new
            {
                @class =
            "control-label col-md-2"
            }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <div class=\"col-md-10\">\n                ");
#nullable restore
#line 49 "/Users/apple/Projects/MovieAsp/MovieAsp/Views/Movies/Checkout.cshtml"
           Write(Html.EditorFor(model =>
                model.ReleaseDate, new
                {
                    htmlAttributes = new
                    {
                @class = "form-control"
                    }
                }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                ");
#nullable restore
#line 57 "/Users/apple/Projects/MovieAsp/MovieAsp/Views/Movies/Checkout.cshtml"
           Write(Html.ValidationMessageFor(model =>
                model.ReleaseDate, "", new
                {
                    @class = "text-danger"
                }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
        </div>
        <div class=""form-group"">
            <div class=""col-md-offset-2 col-md-10"">
                <input type=""submit"" value=""Hoàn thành""
                       class=""btn btn-default"" />
            </div>
        </div>
    </div>
");
#nullable restore
#line 71 "/Users/apple/Projects/MovieAsp/MovieAsp/Views/Movies/Checkout.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MovieAsp.Models.ShippingDetail> Html { get; private set; }
    }
}
#pragma warning restore 1591