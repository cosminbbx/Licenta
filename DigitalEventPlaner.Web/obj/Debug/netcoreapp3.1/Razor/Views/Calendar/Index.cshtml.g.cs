#pragma checksum "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/Calendar/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13819f6b1c5d597348d6aa241084a21318093ac7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Calendar_Index), @"mvc.1.0.view", @"/Views/Calendar/Index.cshtml")]
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
#line 1 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/_ViewImports.cshtml"
using DigitalEventPlaner.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/_ViewImports.cshtml"
using DigitalEventPlaner.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/Calendar/Index.cshtml"
using DigitalEventPlaner.Web.Models.MyEvents;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13819f6b1c5d597348d6aa241084a21318093ac7", @"/Views/Calendar/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9a0b353c39294cfce461987624b6e33695d1733", @"/Views/_ViewImports.cshtml")]
    public class Views_Calendar_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<EventRequestViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/Calendar/Index.cshtml"
  
    ViewData["Title"] = "Profile Page";
    Layout = "_ServiceLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"container container-inside\">\n    <div class=\"font-quicksand page-title\">CALENDAR</div>\n\n");
#nullable restore
#line 11 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/Calendar/Index.cshtml"
     if (Model.Count() > 0)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/Calendar/Index.cshtml"
         foreach (var request in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""planning-service-info"" style=""display:flex"">
                <div class=""user-info"">
                    <div class=""info-header"">
                        <div class=""profile-wrapper"">
                            <div class=""profile-middle"">
                                <div class=""profile-box"">
                                    <img");
            BeginWriteAttribute("src", " src=\"", 706, "\"", 735, 1);
#nullable restore
#line 21 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/Calendar/Index.cshtml"
WriteAttributeValue("", 712, request.ProfilePicture, 712, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""profile-image"" />
                                </div>
                            </div>
                        </div>

                        <div class=""user-name"">
                            <div class=""font-quicksand-bold-small"" style=""margin-top: 5px;"">");
#nullable restore
#line 27 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/Calendar/Index.cshtml"
                                                                                       Write(request.User.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n                        </div>\n                    </div>\n\n                    <div>\n                        <div class=\"font-quicksand-bold-small\" style=\"float:left;margin-right:5px;\">Event date:</div><div class=\"font-quicksand-small\"> ");
#nullable restore
#line 32 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/Calendar/Index.cshtml"
                                                                                                                                                   Write(request.EventDate.ToString("dd.MM.yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n                    </div>\n                    <div>\n                        <div class=\"font-quicksand-bold-small\" style=\"float:left;margin-right:5px;\">Event type:</div><div class=\"font-quicksand-small\"> ");
#nullable restore
#line 35 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/Calendar/Index.cshtml"
                                                                                                                                                   Write(request.EventType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n                    </div>\n                    <div>\n                        <div class=\"font-quicksand-bold-small\" style=\"float:left;margin-right:5px;\">Address:</div><div class=\"font-quicksand-small\"> ");
#nullable restore
#line 38 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/Calendar/Index.cshtml"
                                                                                                                                                Write(request.User.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n                    </div>\n                    <div>\n                        <div class=\"font-quicksand-bold-small\" style=\"float:left;margin-right:5px;\">Email:</div><div class=\"font-quicksand-small\"> ");
#nullable restore
#line 41 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/Calendar/Index.cshtml"
                                                                                                                                              Write(request.User.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n                    </div>\n                    <div>\n                        <div class=\"font-quicksand-bold-small\" style=\"float:left;margin-right:5px;\">Phone:</div><div class=\"font-quicksand-small\"> ");
#nullable restore
#line 44 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/Calendar/Index.cshtml"
                                                                                                                                              Write(request.User.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n                    </div>\n\n\n                </div>\n                <div class=\"service-wrapper\">\n                    <div class=\"service-container\">\n                        <div class=\"font-quicksand-bold-small\">");
#nullable restore
#line 51 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/Calendar/Index.cshtml"
                                                          Write(request.ServiceWrapper.Service.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n                    </div>\n");
#nullable restore
#line 53 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/Calendar/Index.cshtml"
                     if (request.ServiceWrapper.ServicePackages.Count() > 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"list-group\">\n\n");
#nullable restore
#line 57 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/Calendar/Index.cshtml"
                             foreach (var package in request.ServiceWrapper.ServicePackages)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"sublist-item\">\n                                    <div style=\"display: flex;align-items: center;width:100%;\">\n                                        <textarea class=\"form-control\" readonly>");
#nullable restore
#line 61 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/Calendar/Index.cshtml"
                                                                           Write(package.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</textarea>\n                                    </div>\n                                </div>\n");
#nullable restore
#line 64 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/Calendar/Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </div>\n");
#nullable restore
#line 67 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/Calendar/Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\n            </div>\n");
#nullable restore
#line 70 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/Calendar/Index.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/Calendar/Index.cshtml"
         
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"font-quicksand page-title\">No events comming.</div>\n");
#nullable restore
#line 75 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/Calendar/Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n");
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
