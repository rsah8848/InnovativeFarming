#pragma checksum "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\GetAdminsList.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "749dd8d42bb658307d692be8f1b5c59a86dda62db197c008fd2726e5efe63a36"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_GetAdminsList), @"mvc.1.0.view", @"/Views/Admin/GetAdminsList.cshtml")]
namespace AspNetCore
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\_ViewImports.cshtml"
using KisaanSnehiWebApplication

#nullable disable
    ;
#nullable restore
#line 2 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\_ViewImports.cshtml"
using KisaanSnehiWebApplication.Models

#nullable disable
    ;
#nullable restore
#line 2 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\GetAdminsList.cshtml"
 using X.PagedList;

#nullable disable
#nullable restore
#line 3 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\GetAdminsList.cshtml"
 using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"749dd8d42bb658307d692be8f1b5c59a86dda62db197c008fd2726e5efe63a36", @"/Views/Admin/GetAdminsList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"836f88ad40f24e3399bee6693035cf27c7092749c88a5ae5db77dde5b7e5805d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_GetAdminsList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IPagedList<KisaanSnehiWebApplication.Models.RegistrationModel>>
    #nullable disable
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\GetAdminsList.cshtml"
  
    ViewData["Title"] = "GetAdminsList";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";


#line default
#line hidden
#nullable disable

            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "749dd8d42bb658307d692be8f1b5c59a86dda62db197c008fd2726e5efe63a364158", async() => {
                WriteLiteral(@"
    <style>

        /* The heart of the matter */

        .horizontal-scrollable > .row {
            white-space: nowrap;
        }

            .horizontal-scrollable > .row > .col-xs-4 {
                display: inline-block;
                float: none;
            }
    </style>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "749dd8d42bb658307d692be8f1b5c59a86dda62db197c008fd2726e5efe63a365447", async() => {
                WriteLiteral(@"


    <div style=""margin-left: 25%; margin-right: 2%; overflow: auto;"">
        <h1> Admins' List</h1>
        <table style=""overflow: auto;"" class=""table table-striped table-bordered table-sm"">
            <thead>
                <tr>

                    <th>
                        ");
                Write(
#nullable restore
#line 34 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\GetAdminsList.cshtml"
                         Html.DisplayNameFor(model => model.First().Name)

#line default
#line hidden
#nullable disable
                );
                WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
                Write(
#nullable restore
#line 37 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\GetAdminsList.cshtml"
                         Html.DisplayNameFor(model => model.First().EmailId)

#line default
#line hidden
#nullable disable
                );
                WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
                Write(
#nullable restore
#line 40 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\GetAdminsList.cshtml"
                         Html.DisplayNameFor(model => model.First().PhoneNo)

#line default
#line hidden
#nullable disable
                );
                WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
                Write(
#nullable restore
#line 43 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\GetAdminsList.cshtml"
                         Html.DisplayNameFor(model => model.First().Address)

#line default
#line hidden
#nullable disable
                );
                WriteLiteral("\r\n                    </th>\r\n\r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 50 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\GetAdminsList.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable

                WriteLiteral("                    <tr>\r\n\r\n                        <td>\r\n                            ");
                Write(
#nullable restore
#line 55 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\GetAdminsList.cshtml"
                             Html.DisplayFor(modelItem => item.Name)

#line default
#line hidden
#nullable disable
                );
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
                Write(
#nullable restore
#line 58 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\GetAdminsList.cshtml"
                             Html.DisplayFor(modelItem => item.EmailId)

#line default
#line hidden
#nullable disable
                );
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
                Write(
#nullable restore
#line 61 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\GetAdminsList.cshtml"
                             Html.DisplayFor(modelItem => item.PhoneNo)

#line default
#line hidden
#nullable disable
                );
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
                Write(
#nullable restore
#line 64 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\GetAdminsList.cshtml"
                             Html.DisplayFor(modelItem => item.Address)

#line default
#line hidden
#nullable disable
                );
                WriteLiteral("\r\n                        </td>\r\n\r\n                        <td>\r\n                            ");
                Write(
#nullable restore
#line 68 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\GetAdminsList.cshtml"
                             Html.ActionLink("Deactivate", "DeactivateAdmin", new { id = item.RegId })

#line default
#line hidden
#nullable disable
                );
                WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 71 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\GetAdminsList.cshtml"
                }

#line default
#line hidden
#nullable disable

                WriteLiteral("            </tbody>\r\n        </table>\r\n        ");
                Write(
#nullable restore
#line 74 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\GetAdminsList.cshtml"
         Html.PagedListPager((IPagedList)Model, page => Url.Action("GetAdminsList", "Admin", new { page= page }),
       new X.PagedList.Web.Common.PagedListRenderOptionsBase
       {
           DisplayItemSliceAndTotal = true,
           ContainerDivClasses = new[] { "navigation" },
           LiElementClasses = new[] { "page-item" },
           PageClasses = new[] { "page-link" },
       }
       )

#line default
#line hidden
#nullable disable
                );
                WriteLiteral("\r\n\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n \r\n    <script type=\"text/javascript\">\r\n        \r\n        $(document).ready(function () {\r\n            $(\'ul.pagination > li.disabled > a\').addClass(\'page-link\');\r\n        });\r\n    </script>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IPagedList<KisaanSnehiWebApplication.Models.RegistrationModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
