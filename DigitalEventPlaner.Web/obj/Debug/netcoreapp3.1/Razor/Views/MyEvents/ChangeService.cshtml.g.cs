#pragma checksum "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/MyEvents/ChangeService.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "efc6e6a90f18ccf2eb3d94f4122de173da880780"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MyEvents_ChangeService), @"mvc.1.0.view", @"/Views/MyEvents/ChangeService.cshtml")]
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
#line 1 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/MyEvents/ChangeService.cshtml"
using DigitalEventPlaner.Web.Models.MyEvents;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"efc6e6a90f18ccf2eb3d94f4122de173da880780", @"/Views/MyEvents/ChangeService.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9a0b353c39294cfce461987624b6e33695d1733", @"/Views/_ViewImports.cshtml")]
    public class Views_MyEvents_ChangeService : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ChangeServiceViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/MyEvents/ChangeService.cshtml"
  
    ViewData["Title"] = "Profile Page";
    Layout = "~/Views/Shared/_CustomerLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h3>");
#nullable restore
#line 8 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/MyEvents/ChangeService.cshtml"
Write(Model.ServiceType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "efc6e6a90f18ccf2eb3d94f4122de173da8807805187", async() => {
                WriteLiteral("\n    <input type=\"hidden\" name=\"ServiceType\"");
                BeginWriteAttribute("value", " value=\"", 298, "\"", 324, 1);
#nullable restore
#line 10 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/MyEvents/ChangeService.cshtml"
WriteAttributeValue("", 306, Model.ServiceType, 306, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\n    <div class=\"list-group manage-service-container\">\n");
#nullable restore
#line 12 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/MyEvents/ChangeService.cshtml"
         foreach (var item in Model.ServiceWrappers)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"list-group-item service-container\">\n                <div> <a");
                BeginWriteAttribute("href", " href=\"", 530, "\"", 608, 1);
#nullable restore
#line 15 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/MyEvents/ChangeService.cshtml"
WriteAttributeValue("", 537, Url.Action("ServiceDetails", "ServiceManage", new { item.Service.Id }), 537, 71, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 15 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/MyEvents/ChangeService.cshtml"
                                                                                                   Write(item.Service.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a></div>\n                <div>\n                    ");
#nullable restore
#line 17 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/MyEvents/ChangeService.cshtml"
               Write(Html.ActionLink("AddPackage", "AddServicePackage", "ServiceManage", new { item.Service.Id }, new { @class = "btn btn-outline-primary btn-sm" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                    ");
#nullable restore
#line 18 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/MyEvents/ChangeService.cshtml"
               Write(Html.ActionLink("Edit", "EditService", "ServiceManage", new { item.Service.Id }, new { @class = "btn btn-outline-primary btn-sm" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                    ");
#nullable restore
#line 19 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/MyEvents/ChangeService.cshtml"
               Write(Html.ActionLink("Delete", "DeleteService", "ServiceManage", new { item.Service.Id }, new { @class = "btn btn-outline-primary btn-sm" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                </div>\n            </div>\n            <div class=\"list-group\">\n");
#nullable restore
#line 23 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/MyEvents/ChangeService.cshtml"
                 foreach (var package in item.ServicePackages)
                {


#line default
#line hidden
#nullable disable
                WriteLiteral("                    <div class=\"list-group-item sublist-item\">\n                        <input name=\"ServicePackageSelected\" type=\"checkbox\"");
                BeginWriteAttribute("value", " value=\"", 1436, "\"", 1455, 1);
#nullable restore
#line 27 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/MyEvents/ChangeService.cshtml"
WriteAttributeValue("", 1444, package.Id, 1444, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\n                        <div>");
#nullable restore
#line 28 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/MyEvents/ChangeService.cshtml"
                        Write(package.Description);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\n                        <div>\n                            ");
#nullable restore
#line 30 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/MyEvents/ChangeService.cshtml"
                       Write(Html.ActionLink("Edit", "EditServicePackage", "ServiceManage", new { package.Id }, new { @class = "btn btn-outline-primary btn-sm" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                            ");
#nullable restore
#line 31 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/MyEvents/ChangeService.cshtml"
                       Write(Html.ActionLink("Delete", "DeleteServicePackage", "ServiceManage", new { package.Id }, new { @class = "btn btn-outline-primary btn-sm" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                        </div>\n                    </div>\n");
#nullable restore
#line 34 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/MyEvents/ChangeService.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </div>\n");
#nullable restore
#line 36 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/MyEvents/ChangeService.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "efc6e6a90f18ccf2eb3d94f4122de173da88078010911", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 37 "/Users/virgacosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/MyEvents/ChangeService.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ServicePackageSelected);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n    </div>\n\n    <button class=\"btn btn-outline-primary\">Submit</button>\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ChangeServiceViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
