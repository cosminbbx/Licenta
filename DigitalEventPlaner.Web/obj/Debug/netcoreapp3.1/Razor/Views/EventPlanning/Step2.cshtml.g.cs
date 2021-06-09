#pragma checksum "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ec84bc5fc4847203ea6c7660e73c375640c3f169"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec84bc5fc4847203ea6c7660e73c375640c3f169", @"/Views/EventPlanning/Step2.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9a0b353c39294cfce461987624b6e33695d1733", @"/Views/_ViewImports.cshtml")]
    public class Views_EventPlanning_Step2 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EventPlanningStep2ViewModel>
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
#line 3 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
  
    ViewData["Title"] = "Profile Page";
    Layout = "~/Views/Shared/_CustomerLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"container container-inside\">\n    <div class=\"font-quicksand page-title\">STEP 2</div>\n    <div class=\"font-quicksand-small\">Service type to choose: ");
#nullable restore
#line 10 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
                                                         Write(Model.ServiceType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n    <div class=\"font-quicksand-small\">Buget estimation: ");
#nullable restore
#line 11 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
                                                   Write(Model.Step1.Estimation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n    <div class=\"font-quicksand-small\">Buget needed: ");
#nullable restore
#line 12 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
                                               Write(Model.BugetNeeded);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec84bc5fc4847203ea6c7660e73c375640c3f1696054", async() => {
                WriteLiteral("\n        <input type=\"hidden\" name=\"ServiceSelectedIndex\"");
                BeginWriteAttribute("value", " value=\"", 645, "\"", 680, 1);
#nullable restore
#line 15 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
WriteAttributeValue("", 653, Model.ServiceSelectedIndex, 653, 27, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\n        <input type=\"hidden\" name=\"ServiceType\"");
                BeginWriteAttribute("value", " value=\"", 732, "\"", 758, 1);
#nullable restore
#line 16 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
WriteAttributeValue("", 740, Model.ServiceType, 740, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\n        <input type=\"hidden\" name=\"BugetNeeded\"");
                BeginWriteAttribute("value", " value=\"", 810, "\"", 836, 1);
#nullable restore
#line 17 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
WriteAttributeValue("", 818, Model.BugetNeeded, 818, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\n        <div class=\"list-group manage-service-container\">\n");
#nullable restore
#line 19 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
             foreach (var item in Model.ServiceWrappers)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                <div class=""planning-service-info"" style=""display:flex"">
                    <div class=""user-info"">
                        <div class=""info-header"">
                            <div class=""profile-wrapper"">
                                <div class=""profile-middle"">
                                    <div class=""profile-box"">
                                        <img");
                BeginWriteAttribute("src", " src=\"", 1362, "\"", 1391, 1);
#nullable restore
#line 27 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
WriteAttributeValue("", 1368, item.ProfilePictureUri, 1368, 23, false);

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
#line 33 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
                                                                                           Write(item.User.UserName);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</div>
                            </div>
                        </div>

                        <div>
                            <div class=""font-quicksand-bold-small"" style=""float:left;margin-right:5px;"">Address:</div><div class=""font-quicksand-small""> ");
#nullable restore
#line 38 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
                                                                                                                                                    Write(item.User.Address);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\n                        </div>\n                        <div>\n                            <div class=\"font-quicksand-bold-small\" style=\"float:left;margin-right:5px;\">Email:</div><div class=\"font-quicksand-small\"> ");
#nullable restore
#line 41 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
                                                                                                                                                  Write(item.User.Email);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\n                        </div>\n                        <div>\n                            <div class=\"font-quicksand-bold-small\" style=\"float:left;margin-right:5px;\">Phone:</div><div class=\"font-quicksand-small\"> ");
#nullable restore
#line 44 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
                                                                                                                                                  Write(item.User.Phone);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\n                        </div>\n\n\n                    </div>\n                    <div class=\"service-wrapper\">\n                        <div class=\"service-container\">\n                            <div class=\"font-quicksand-bold-small\"> <a");
                BeginWriteAttribute("href", " href=\"", 2691, "\"", 2769, 1);
#nullable restore
#line 51 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
WriteAttributeValue("", 2698, Url.Action("ServiceDetails", "EventPlanning", new { item.Service.Id }), 2698, 71, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 51 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
                                                                                                                                                 Write(item.Service.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a></div>\n");
#nullable restore
#line 52 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
                             if (item.Service.NumberOfRatings > 0)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <div style=\"display:flex;\">\n                                    <div class=\"font-quicksand-bold-small\" style=\"margin-right:5px;\">Rating:</div><div class=\"font-quicksand-small\">");
#nullable restore
#line 55 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
                                                                                                                                               Write(Math.Round(item.Service.SmartRate * 5 / item.Service.NumberOfRatings, 1, MidpointRounding.ToEven));

#line default
#line hidden
#nullable disable
                WriteLiteral("/5</div>\n                                </div>\n");
#nullable restore
#line 57 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <div style=\"display:flex;\">\n                                    <div class=\"font-quicksand-small\">No rating</div>\n                                </div>\n");
#nullable restore
#line 63 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </div>\n");
#nullable restore
#line 65 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
                         if (item.ServicePackages.Count() > 0)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <div class=\"list-group\">\n\n");
#nullable restore
#line 69 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
                                 foreach (var package in item.ServicePackages)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                    <div class=""sublist-item"">
                                        <div style=""display: flex;align-items: center;width:60%;"">
                                            <input name=""ServicePackageSelected"" type=""checkbox""");
                BeginWriteAttribute("value", " value=\"", 4104, "\"", 4123, 1);
#nullable restore
#line 73 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
WriteAttributeValue("", 4112, package.Id, 4112, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"margin-right:10px;\"/>\n                                            <textarea class=\"form-control\" readonly>");
#nullable restore
#line 74 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
                                                                               Write(package.Description);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</textarea>
                                        </div>
                                        
                                        <div class=""font-quicksand-bold-small"">
                                            <div style=""display:flex;flex-direction:column"">
                                                <div>PPP: ");
#nullable restore
#line 79 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
                                                     Write(package.PricePerParticipant);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\n                                                <div>MC: ");
#nullable restore
#line 80 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
                                                    Write(package.MaxCapacity);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\n                                            </div>\n\n                                        </div>\n                                    </div>\n");
#nullable restore
#line 85 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                            </div>\n");
#nullable restore
#line 88 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </div>\n                </div>\n");
#nullable restore
#line 91 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"

            }

#line default
#line hidden
#nullable disable
                WriteLiteral("            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec84bc5fc4847203ea6c7660e73c375640c3f16917773", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 93 "/Users/cosmin/Documents/GitHub/Licenta/DigitalEventPlaner.Web/Views/EventPlanning/Step2.cshtml"
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
                WriteLiteral("\n        </div>\n\n        <button class=\"btn btn-outline-primary\">Submit</button>\n    ");
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
            WriteLiteral("\n\n</div>\n");
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
