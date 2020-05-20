#pragma checksum "/Users/macbook1/Projects/Licenta/DigitalEventPlaner.Web/Views/CustomerProfile/Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "034367e370f22e4c08b05f52d18373a91dc84f13"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CustomerProfile_Profile), @"mvc.1.0.view", @"/Views/CustomerProfile/Profile.cshtml")]
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
#line 1 "/Users/macbook1/Projects/Licenta/DigitalEventPlaner.Web/Views/_ViewImports.cshtml"
using DigitalEventPlaner.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/macbook1/Projects/Licenta/DigitalEventPlaner.Web/Views/_ViewImports.cshtml"
using DigitalEventPlaner.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "/Users/macbook1/Projects/Licenta/DigitalEventPlaner.Web/Views/CustomerProfile/Profile.cshtml"
using DigitalEventPlaner.Web.Models.User;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"034367e370f22e4c08b05f52d18373a91dc84f13", @"/Views/CustomerProfile/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9a0b353c39294cfce461987624b6e33695d1733", @"/Views/_ViewImports.cshtml")]
    public class Views_CustomerProfile_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProfileViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "CustomerProfile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Upload", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "/Users/macbook1/Projects/Licenta/DigitalEventPlaner.Web/Views/CustomerProfile/Profile.cshtml"
  
    ViewData["Title"] = "Profile Page";
    Layout = "~/Views/Shared/_CustomerLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3>Customer Profile</h3>\r\n\r\n<div class=\"profile-info-container\">\r\n");
#nullable restore
#line 11 "/Users/macbook1/Projects/Licenta/DigitalEventPlaner.Web/Views/CustomerProfile/Profile.cshtml"
     foreach (var uri in Model.ProfilePictureUrl)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"profile-image-container\">\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 361, "\"", 371, 1);
#nullable restore
#line 14 "/Users/macbook1/Projects/Licenta/DigitalEventPlaner.Web/Views/CustomerProfile/Profile.cshtml"
WriteAttributeValue("", 367, uri, 367, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"profile-image\" />\r\n        </div>\r\n");
#nullable restore
#line 16 "/Users/macbook1/Projects/Licenta/DigitalEventPlaner.Web/Views/CustomerProfile/Profile.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"profile-info\">\r\n        <div>Username: ");
#nullable restore
#line 19 "/Users/macbook1/Projects/Licenta/DigitalEventPlaner.Web/Views/CustomerProfile/Profile.cshtml"
                  Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        <div>FirstName: ");
#nullable restore
#line 20 "/Users/macbook1/Projects/Licenta/DigitalEventPlaner.Web/Views/CustomerProfile/Profile.cshtml"
                   Write(Model.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        <div>LastName: ");
#nullable restore
#line 21 "/Users/macbook1/Projects/Licenta/DigitalEventPlaner.Web/Views/CustomerProfile/Profile.cshtml"
                  Write(Model.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        <div>Email: ");
#nullable restore
#line 22 "/Users/macbook1/Projects/Licenta/DigitalEventPlaner.Web/Views/CustomerProfile/Profile.cshtml"
               Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        <div>Phone: ");
#nullable restore
#line 23 "/Users/macbook1/Projects/Licenta/DigitalEventPlaner.Web/Views/CustomerProfile/Profile.cshtml"
               Write(Model.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        <div>Address: ");
#nullable restore
#line 24 "/Users/macbook1/Projects/Licenta/DigitalEventPlaner.Web/Views/CustomerProfile/Profile.cshtml"
                 Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "034367e370f22e4c08b05f52d18373a91dc84f137687", async() => {
                WriteLiteral(@"
    <div class=""form-group"">
        <div class=""col-md-10"">
            <p>Upload one or more files using this form:</p>
            <input type=""file"" name=""imagelist"" accept=""image/x-png,image/gif,image/jpeg, image/jpg"" multiple />
        </div>
    </div>
    <div class=""form-group"">
        <input type=""submit"" value=""Create"" class=""btn btn-default"" />
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 40 "/Users/macbook1/Projects/Licenta/DigitalEventPlaner.Web/Views/CustomerProfile/Profile.cshtml"
 if (ViewData["SmartRate"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Smart rate test ");
#nullable restore
#line 42 "/Users/macbook1/Projects/Licenta/DigitalEventPlaner.Web/Views/CustomerProfile/Profile.cshtml"
                  Write(ViewData["SmartRate"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 43 "/Users/macbook1/Projects/Licenta/DigitalEventPlaner.Web/Views/CustomerProfile/Profile.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProfileViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
