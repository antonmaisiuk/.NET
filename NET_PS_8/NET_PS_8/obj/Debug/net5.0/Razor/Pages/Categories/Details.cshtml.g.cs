#pragma checksum "D:\Develop\.NET\NET_PS_8 — kopia\NET_PS_8\NET_PS_8\Pages\Categories\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6c861ce736cb4bf590428e76d8f48d665394e7bf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(NET_PS_8.Pages.Categories.Pages_Categories_Details), @"mvc.1.0.razor-page", @"/Pages/Categories/Details.cshtml")]
namespace NET_PS_8.Pages.Categories
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
#line 1 "D:\Develop\.NET\NET_PS_8 — kopia\NET_PS_8\NET_PS_8\Pages\_ViewImports.cshtml"
using NET_PS_8;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6c861ce736cb4bf590428e76d8f48d665394e7bf", @"/Pages/Categories/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2cc49d75e0b179f1912fc86fe5f3a4241503aa3a", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Categories_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "D:\Develop\.NET\NET_PS_8 — kopia\NET_PS_8\NET_PS_8\Pages\Categories\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div");
            BeginWriteAttribute("class", " class=\"", 125, "\"", 133, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n    <div>\r\n        <h4>Category</h4>\r\n\r\n        <table class=\"table tableProd w-50\">\r\n            <thead>\r\n                <tr>\r\n                    <th class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 18 "D:\Develop\.NET\NET_PS_8 — kopia\NET_PS_8\NET_PS_8\Pages\Categories\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Category.id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 21 "D:\Develop\.NET\NET_PS_8 — kopia\NET_PS_8\NET_PS_8\Pages\Categories\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Category.shortName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 24 "D:\Develop\.NET\NET_PS_8 — kopia\NET_PS_8\NET_PS_8\Pages\Categories\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Category.longName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 31 "D:\Develop\.NET\NET_PS_8 — kopia\NET_PS_8\NET_PS_8\Pages\Categories\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Category.id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 34 "D:\Develop\.NET\NET_PS_8 — kopia\NET_PS_8\NET_PS_8\Pages\Categories\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Category.shortName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 37 "D:\Develop\.NET\NET_PS_8 — kopia\NET_PS_8\NET_PS_8\Pages\Categories\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Category.longName));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </td>
                </tr>
            </tbody>
        </table>
    </div>

    <br />
    <br />
    <div>
        <h4>Products with this category</h4>

        <table class=""table tableProd w-50"">
            <thead>
                <tr>
                    <th class=""col-sm-2"">
                        ");
#nullable restore
#line 53 "D:\Develop\.NET\NET_PS_8 — kopia\NET_PS_8\NET_PS_8\Pages\Categories\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Product.id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 56 "D:\Develop\.NET\NET_PS_8 — kopia\NET_PS_8\NET_PS_8\Pages\Categories\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Product.name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 59 "D:\Develop\.NET\NET_PS_8 — kopia\NET_PS_8\NET_PS_8\Pages\Categories\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Product.price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 64 "D:\Develop\.NET\NET_PS_8 — kopia\NET_PS_8\NET_PS_8\Pages\Categories\Details.cshtml"
                 foreach (var p in Model.productList)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 68 "D:\Develop\.NET\NET_PS_8 — kopia\NET_PS_8\NET_PS_8\Pages\Categories\Details.cshtml"
                       Write(Html.DisplayFor(m => p.id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 71 "D:\Develop\.NET\NET_PS_8 — kopia\NET_PS_8\NET_PS_8\Pages\Categories\Details.cshtml"
                       Write(Html.DisplayFor(m => p.name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 74 "D:\Develop\.NET\NET_PS_8 — kopia\NET_PS_8\NET_PS_8\Pages\Categories\Details.cshtml"
                       Write(Html.DisplayFor(m => p.price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 77 "D:\Develop\.NET\NET_PS_8 — kopia\NET_PS_8\NET_PS_8\Pages\Categories\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6c861ce736cb4bf590428e76d8f48d665394e7bf9518", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 84 "D:\Develop\.NET\NET_PS_8 — kopia\NET_PS_8\NET_PS_8\Pages\Categories\Details.cshtml"
                           WriteLiteral(Model.Category.id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6c861ce736cb4bf590428e76d8f48d665394e7bf11670", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NET_PS_8.Pages.Categories.DetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<NET_PS_8.Pages.Categories.DetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<NET_PS_8.Pages.Categories.DetailsModel>)PageContext?.ViewData;
        public NET_PS_8.Pages.Categories.DetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591