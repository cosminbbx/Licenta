#pragma checksum "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/RequestManager/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "25328fe9d19c99770694243110ad06a93cc528d6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RequestManager_Index), @"mvc.1.0.view", @"/Views/RequestManager/Index.cshtml")]
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
#line 1 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/RequestManager/Index.cshtml"
using DigitalEventPlaner.Web.Models.MyEvents;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"25328fe9d19c99770694243110ad06a93cc528d6", @"/Views/RequestManager/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9a0b353c39294cfce461987624b6e33695d1733", @"/Views/_ViewImports.cshtml")]
    public class Views_RequestManager_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<EventRequestViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/RequestManager/Index.cshtml"
  
    ViewData["Title"] = "Profile Page";
    Layout = "_ServiceLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h3>Manage requests</h3>\n\n");
#nullable restore
#line 10 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/RequestManager/Index.cshtml"
 foreach (var request in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"event-container\">\n    <h5>EventType: ");
#nullable restore
#line 13 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/RequestManager/Index.cshtml"
              Write(request.EventType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n    <h5>First name: ");
#nullable restore
#line 14 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/RequestManager/Index.cshtml"
               Write(request.UserFirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n    <h5>Last name: ");
#nullable restore
#line 15 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/RequestManager/Index.cshtml"
              Write(request.UserLastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n    <h5>Phone: ");
#nullable restore
#line 16 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/RequestManager/Index.cshtml"
          Write(request.UserPhone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n\n    <div class=\"list-group-item service-container\">\n        <div> ");
#nullable restore
#line 19 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/RequestManager/Index.cshtml"
         Write(request.ServiceWrapper.Service.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n    </div>\n    <div class=\"list-group\">\n");
#nullable restore
#line 22 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/RequestManager/Index.cshtml"
         foreach (var package in request.ServiceWrapper.ServicePackages)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"list-group-item sublist-item\">\n            <div>");
#nullable restore
#line 25 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/RequestManager/Index.cshtml"
            Write(package.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n            <div>");
#nullable restore
#line 26 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/RequestManager/Index.cshtml"
            Write(request.ServiceWrapper.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n");
#nullable restore
#line 27 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/RequestManager/Index.cshtml"
             if (@request.ServiceWrapper.Status == DataLayer.Enumerations.RequestStatus.Requested)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/RequestManager/Index.cshtml"
           Write(Html.ActionLink("Accept", "Accept", "RequestManager", new { eventServiceId = request.EventService.Id }, new { @class = "btn btn-outline-primary btn-sm" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/RequestManager/Index.cshtml"
           Write(Html.ActionLink("Decline", "Decline", "RequestManager", new { eventServiceId = request.EventService.Id }, new { @class = "btn btn-outline-primary btn-sm" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/RequestManager/Index.cshtml"
                                                                                                                                                                             
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\n");
#nullable restore
#line 33 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/RequestManager/Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\n</div>\n");
#nullable restore
#line 36 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/RequestManager/Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<EventRequestViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
