#pragma checksum "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/ServiceManage/DeletedServices.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "808b9cad2246fcfa86550ca7b51ab41dc97d5ecc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ServiceManage_DeletedServices), @"mvc.1.0.view", @"/Views/ServiceManage/DeletedServices.cshtml")]
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
#line 1 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/_ViewImports.cshtml"
using DigitalEventPlaner.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/_ViewImports.cshtml"
using DigitalEventPlaner.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/ServiceManage/DeletedServices.cshtml"
using DigitalEventPlaner.Web.Models.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"808b9cad2246fcfa86550ca7b51ab41dc97d5ecc", @"/Views/ServiceManage/DeletedServices.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9a0b353c39294cfce461987624b6e33695d1733", @"/Views/_ViewImports.cshtml")]
    public class Views_ServiceManage_DeletedServices : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ServiceViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/ServiceManage/DeletedServices.cshtml"
  
    ViewData["Title"] = "Home Page";
    Layout = "_ServiceLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container container-inside"">
    <div class=""font-quicksand page-title"">DELETED SERVICES</div>

    <table class=""table deleted-table"">
        <thead>
            <tr>
                <th scope=""col"">Name</th>
                <th scope=""col"">Type</th>
                <th scope=""col"">Events per day</th>
                <th scope=""col""></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 21 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/ServiceManage/DeletedServices.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\n                    <td>");
#nullable restore
#line 24 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/ServiceManage/DeletedServices.cshtml"
                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 25 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/ServiceManage/DeletedServices.cshtml"
                   Write(item.ServiceType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 26 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/ServiceManage/DeletedServices.cshtml"
                   Write(item.EventsPerDay);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 27 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/ServiceManage/DeletedServices.cshtml"
                   Write(Html.ActionLink("Undelete", "Undelete", "ServiceManage", new { item.Id }, new { @class = "btn btn-outline-primary btn-sm" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                </tr>\n");
#nullable restore
#line 29 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/ServiceManage/DeletedServices.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\n    </table>\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ServiceViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
