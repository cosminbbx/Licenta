#pragma checksum "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/Account/ServiceProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ba9f0c20e3db7b010b394e0ae51a027600720e04"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ServiceProfile), @"mvc.1.0.view", @"/Views/Account/ServiceProfile.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba9f0c20e3db7b010b394e0ae51a027600720e04", @"/Views/Account/ServiceProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9a0b353c39294cfce461987624b6e33695d1733", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_ServiceProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/Account/ServiceProfile.cshtml"
  
    ViewData["Title"] = "profile Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h3>Service Profile</h3>\n\n<img");
            BeginWriteAttribute("src", " src=\"", 76, "\"", 94, 1);
#nullable restore
#line 7 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/Account/ServiceProfile.cshtml"
WriteAttributeValue("", 82, ViewBag.Url, 82, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
