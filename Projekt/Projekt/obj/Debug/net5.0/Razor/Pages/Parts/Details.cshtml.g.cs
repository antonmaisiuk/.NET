#pragma checksum "D:\Develop\.NET\Projekt\Projekt\Pages\Parts\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5e4aebafb419835efd519ffaa343d21af294e66f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Projekt.Pages.Parts.Pages_Parts_Details), @"mvc.1.0.razor-page", @"/Pages/Parts/Details.cshtml")]
namespace Projekt.Pages.Parts
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
#line 1 "D:\Develop\.NET\Projekt\Projekt\Pages\_ViewImports.cshtml"
using Projekt;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e4aebafb419835efd519ffaa343d21af294e66f", @"/Pages/Parts/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5f6ec2ebf285b221feb0b48af9dcd9f8ba57cd87", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Parts_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Develop\.NET\Projekt\Projekt\Pages\Parts\Details.cshtml"
  
    ViewData["Title"] = "Szczeg????y";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Szczeg????y</h1>\r\n\r\n<div class=\"details-div d-flex\">\r\n    <div class=\"details-img\">\r\n        <img");
            BeginWriteAttribute("src", " src=\"", 196, "\"", 221, 2);
#nullable restore
#line 12 "D:\Develop\.NET\Projekt\Projekt\Pages\Parts\Details.cshtml"
WriteAttributeValue("", 202, Model.Part.imgUrl, 202, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 220, "}", 220, 1, true);
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 222, "\"", 254, 2);
            WriteAttributeValue("", 228, "Photo", 228, 5, true);
#nullable restore
#line 12 "D:\Develop\.NET\Projekt\Projekt\Pages\Parts\Details.cshtml"
WriteAttributeValue(" ", 233, Model.Part.partName, 234, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"100%\" />\r\n    </div>\r\n    <div class=\"details-content\">\r\n        <h4>");
#nullable restore
#line 15 "D:\Develop\.NET\Projekt\Projekt\Pages\Parts\Details.cshtml"
       Write(Html.DisplayFor(model => model.Part.partName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n        <hr />\r\n        <dl class=\"row\">            \r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 19 "D:\Develop\.NET\Projekt\Projekt\Pages\Parts\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Part.descript));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 22 "D:\Develop\.NET\Projekt\Projekt\Pages\Parts\Details.cshtml"
           Write(Html.DisplayFor(model => model.Part.descript));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 25 "D:\Develop\.NET\Projekt\Projekt\Pages\Parts\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Part.price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 28 "D:\Develop\.NET\Projekt\Projekt\Pages\Parts\Details.cshtml"
           Write(Html.DisplayFor(model => model.Part.price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 31 "D:\Develop\.NET\Projekt\Projekt\Pages\Parts\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Part.imgUrl));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 34 "D:\Develop\.NET\Projekt\Projekt\Pages\Parts\Details.cshtml"
           Write(Html.DisplayFor(model => model.Part.imgUrl));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 37 "D:\Develop\.NET\Projekt\Projekt\Pages\Parts\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Part.Category));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 40 "D:\Develop\.NET\Projekt\Projekt\Pages\Parts\Details.cshtml"
           Write(Html.DisplayFor(model => model.Part.Category.brandName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n        </dl>\r\n    </div>\r\n</div>\r\n<div>\r\n    \r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5e4aebafb419835efd519ffaa343d21af294e66f7630", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Projekt.Pages.Parts.DetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Projekt.Pages.Parts.DetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Projekt.Pages.Parts.DetailsModel>)PageContext?.ViewData;
        public Projekt.Pages.Parts.DetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
