#pragma checksum "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/ServiceManage/ServiceDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "829bb2962bcbb8f8ded4c3d2a48d10da418638a6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ServiceManage_ServiceDetails), @"mvc.1.0.view", @"/Views/ServiceManage/ServiceDetails.cshtml")]
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
#line 1 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/ServiceManage/ServiceDetails.cshtml"
using DigitalEventPlaner.Web.Models.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"829bb2962bcbb8f8ded4c3d2a48d10da418638a6", @"/Views/ServiceManage/ServiceDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9a0b353c39294cfce461987624b6e33695d1733", @"/Views/_ViewImports.cshtml")]
    public class Views_ServiceManage_ServiceDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ServiceWrapperViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/ServiceManage/ServiceDetails.cshtml"
  
    ViewData["Title"] = "Home Page";
    Layout = "_ServiceLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"container container-inside\">\n    <div class=\"font-quicksand page-title\">SERVICE DETAILS</div>\n\n    <div style=\"display:flex\">\n        <div class=\"font-quicksand-bold-small\" style=\"margin-right:15px;\">Service name: ");
#nullable restore
#line 12 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/ServiceManage/ServiceDetails.cshtml"
                                                                                   Write(Model.Service.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n        ");
#nullable restore
#line 13 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/ServiceManage/ServiceDetails.cshtml"
   Write(Html.ActionLink("Edit", "EditService", "ServiceManage", new { Model.Service.Id }, new { @class = "btn btn-outline-primary btn-sm" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </div>\n\n    <div><textarea class=\"form-control description\" readonly>");
#nullable restore
#line 16 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/ServiceManage/ServiceDetails.cshtml"
                                                        Write(Model.Service.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</textarea></div>\n\n    <div style=\"display:flex;margin-bottom:20px;align-items: center;\">\n        <div class=\"font-quicksand\" style=\"margin-right:20px\">PACKAGES</div>\n        <div>");
#nullable restore
#line 20 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/ServiceManage/ServiceDetails.cshtml"
        Write(Html.ActionLink("Add Package", "AddServicePackage", "ServiceManage", new { Model.Service.Id }, new { @class = "btn btn-outline-primary btn-sm" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
    </div>
  
    <table class=""table package-details"">
        <thead>
            <tr class=""package-table-header"">
                <th scope=""col"">Description</th>
                <th scope=""col"" class=""small-column"" title=""Price per participant"">PPP</th>
                <th scope=""col"" class=""small-column"" title=""Maximum capacity"">MC</th>
                <th scope=""col""");
            BeginWriteAttribute("class", " class=\"", 1353, "\"", 1361, 0);
            EndWriteAttribute();
            WriteLiteral("></th>\n            </tr>\n        </thead>\n        <tbody>\n");
#nullable restore
#line 33 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/ServiceManage/ServiceDetails.cshtml"
             foreach (var package in Model.ServicePackages)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr class=\"package-table-body\">\n                    <td style=\"width: 2000px;\"><textarea class=\"form-control\" readonly>");
#nullable restore
#line 36 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/ServiceManage/ServiceDetails.cshtml"
                                                                                  Write(package.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</textarea></td>\n                    <td class=\"small-column\">");
#nullable restore
#line 37 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/ServiceManage/ServiceDetails.cshtml"
                                        Write(package.PricePerParticipant);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td class=\"small-column\">");
#nullable restore
#line 38 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/ServiceManage/ServiceDetails.cshtml"
                                        Write(package.MaxCapacity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td class=\"buttons-column\">\n                        ");
#nullable restore
#line 40 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/ServiceManage/ServiceDetails.cshtml"
                   Write(Html.ActionLink("Edit", "EditServicePackage", "ServiceManage", new { package.Id }, new { @class = "btn btn-outline-primary btn-sm" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        ");
#nullable restore
#line 41 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/ServiceManage/ServiceDetails.cshtml"
                   Write(Html.ActionLink("Delete", "DeleteServicePackage", "ServiceManage", new { package.Id }, new { @class = "btn btn-outline-primary btn-sm" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </td>\n                </tr>\n");
#nullable restore
#line 44 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/ServiceManage/ServiceDetails.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ServiceWrapperViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
