#pragma checksum "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a326913c8f521d26c72921edcc0cfe14d3ec3b2c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_EventPlanning_Step2), @"mvc.1.0.view", @"/Views/EventPlanning/Step2.cshtml")]
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
#line 1 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
using DigitalEventPlaner.Web.Models.EventPlanning;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a326913c8f521d26c72921edcc0cfe14d3ec3b2c", @"/Views/EventPlanning/Step2.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9a0b353c39294cfce461987624b6e33695d1733", @"/Views/_ViewImports.cshtml")]
    public class Views_EventPlanning_Step2 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EventPlanningStep2ViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
  
    ViewData["Title"] = "Profile Page";
    Layout = "~/Views/Shared/_CustomerLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h3>");
#nullable restore
#line 8 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
Write(Model.Step1.Estimation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EventPlanningStep2ViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
