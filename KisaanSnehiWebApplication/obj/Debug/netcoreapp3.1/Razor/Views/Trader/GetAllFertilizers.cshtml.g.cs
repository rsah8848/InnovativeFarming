#pragma checksum "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Trader\GetAllFertilizers.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "771f986a619ccc3f16a7a471322cbe0660e85ab80805cdd6389703a6d268bcb9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Trader_GetAllFertilizers), @"mvc.1.0.view", @"/Views/Trader/GetAllFertilizers.cshtml")]
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
#line 1 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Trader\GetAllFertilizers.cshtml"
 using X.PagedList.Mvc.Core

#nullable disable
    ;
#nullable restore
#line 2 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Trader\GetAllFertilizers.cshtml"
 using X.PagedList

#line default
#line hidden
#nullable disable
    ;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"771f986a619ccc3f16a7a471322cbe0660e85ab80805cdd6389703a6d268bcb9", @"/Views/Trader/GetAllFertilizers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"836f88ad40f24e3399bee6693035cf27c7092749c88a5ae5db77dde5b7e5805d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Trader_GetAllFertilizers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<X.PagedList.IPagedList<KisaanSnehiWebApplication.Models.FertilizerModel>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:200px; height:170px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 6 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Trader\GetAllFertilizers.cshtml"
  
    ViewData["Title"] = "GetAllFertilizers";
    Layout = "~/Views/Shared/_TraderLayout.cshtml";

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "771f986a619ccc3f16a7a471322cbe0660e85ab80805cdd6389703a6d268bcb95894", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "771f986a619ccc3f16a7a471322cbe0660e85ab80805cdd6389703a6d268bcb96180", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

    <script type=""text/javascript"">


        $(function () {
            var PlaceHolderElement = $('#PlaceHolderHere')
            $('button[data-toggle=""ajax-modal""]').click(function (event) {
                
                var url = $(this).data('url');
                var decodedUrl = decodeURIComponent(url);
                $.get(decodedUrl).done(function (data) {
                    PlaceHolderElement.html(data);
                    PlaceHolderElement.find('.modal').modal('show');
                })
            })

            PlaceHolderElement.on('click', '[data-dismiss=""modal""]', function (event) {

                PlaceHolderElement.find('.modal').modal('hide');

            })

        })

    </script>
    
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
            WriteLiteral("\r\n<section id=\"GetAllFertilizers\" class=\"d-flex flex-column justify-content-center align-items-center\" style=\"margin-left:320px\">\r\n    <p style=\"text-align:center\">\r\n\r\n        <div id=\"PlaceHolderHere\"></div>\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 48 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Trader\GetAllFertilizers.cshtml"
         using (Html.BeginForm("GetAllFertilizers", "Trader", FormMethod.Get))
        {

#line default
#line hidden
#nullable disable

            WriteLiteral("            <button type=\"button\" class=\"btn btn-primary\" data-toggle=\"ajax-modal\"\r\n                    data-target=\"#AddFertilizer\" data-url=\"");
            Write(
#nullable restore
#line 51 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Trader\GetAllFertilizers.cshtml"
                                                            Url.Action($"AddFertilizer")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\" style=\"background-color:forestgreen\">\r\n                Add Fertilizer\r\n            </button>\r\n");
            Write(
#nullable restore
#line 54 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Trader\GetAllFertilizers.cshtml"
             Html.TextBox("searchName", null, new { style = "height:36px; ", placeholder = "Search name..." })

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("            <button type=\"submit\" class=\"btn btn-primary\" style=\"background-color:forestgreen;color:white;\">\r\n            <i class=\"icofont icofont-search-2\"></i>\r\n            </button>\r\n");
#nullable restore
#line 58 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Trader\GetAllFertilizers.cshtml"
        }

#line default
#line hidden
#nullable disable

            WriteLiteral("    </p>\r\n    <br />\r\n\r\n\r\n    <table class=\"table\">\r\n        <thead></thead>\r\n");
#nullable restore
#line 65 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Trader\GetAllFertilizers.cshtml"
          
            int i = 5;
            if (Model.Count() == 0)
            {

#line default
#line hidden
#nullable disable

            WriteLiteral("                ");
            WriteLiteral("<tr>\r\n                    ");
            WriteLiteral("<td colspan=\"3\" style=\"color:forestgreen; text-align:center;\">No data found.</td>\r\n                ");
            WriteLiteral("</tr>\r\n");
#nullable restore
#line 72 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Trader\GetAllFertilizers.cshtml"
            }
            else
            {
                foreach (var item in Model)
                {
                    if (i == 5 || i == 0)
                    {

#line default
#line hidden
#nullable disable

            WriteLiteral("                        ");
            WriteLiteral("<tr>\r\n");
#nullable restore
#line 80 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Trader\GetAllFertilizers.cshtml"
                        }



#line default
#line hidden
#nullable disable

            WriteLiteral("                              <td style=\"align-items:center\">\r\n                                  ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "771f986a619ccc3f16a7a471322cbe0660e85ab80805cdd6389703a6d268bcb912222", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
            BeginWriteTagHelperAttribute();
            WriteLiteral(
#nullable restore
#line 84 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Trader\GetAllFertilizers.cshtml"
                                              "~/FertilizerImages/" + item.Image

#line default
#line hidden
#nullable disable
            );
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("src", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = 
#nullable restore
#line 84 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Trader\GetAllFertilizers.cshtml"
                                                                                                       true

#line default
#line hidden
#nullable disable
            ;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" <br />\r\n                                        ");
            Write(
#nullable restore
#line 86 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Trader\GetAllFertilizers.cshtml"
                                         Html.Label("Fertilizer Name")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" : ");
            Write(
#nullable restore
#line 86 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Trader\GetAllFertilizers.cshtml"
                                                                          Html.DisplayFor(modelItem => item.FertilizerName)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" <br />\r\n                                       ");
            Write(
#nullable restore
#line 87 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Trader\GetAllFertilizers.cshtml"
                                        Html.Label("Fertilizer Price")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" : Rs. ");
            Write(
#nullable restore
#line 87 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Trader\GetAllFertilizers.cshtml"
                                                                              Html.DisplayFor(modelItem => item.FertilizerPrice)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" <br />\r\n");
            WriteLiteral(@"
                                  <button type=""button"" class=""btn btn-primary"" style=""background-color:white;color:forestgreen;border-color:white""  data-toggle=""ajax-modal""
                                          data-target=""#UpdateFertilizer"" data-url=""");
            Write(
#nullable restore
#line 92 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Trader\GetAllFertilizers.cshtml"
                                                                                     Url.Action($"UpdateFertilizer/{item.FertilizerId}")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(@""">
                                      <i class=""icofont-ui-edit""></i>
                                  </button>
                                  <button type=""button"" class=""btn btn-primary"" style=""background-color:white;color:forestgreen; border-color:white""  data-toggle=""ajax-modal""
                                          data-target=""#FertilizerDetails"" data-url=""");
            Write(
#nullable restore
#line 96 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Trader\GetAllFertilizers.cshtml"
                                                                                      Url.Action($"FertilizerDetails/{item.FertilizerId}")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(@""">
                                      <i class=""bx bx-detail""></i>
                                  </button>
                                  <button type=""button"" class=""btn btn-primary"" style=""background-color:white;color:forestgreen; border-color:white"" data-toggle=""ajax-modal""
                                    data-target=""#DeleteFertilizer"" data-url=""");
            Write(
#nullable restore
#line 100 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Trader\GetAllFertilizers.cshtml"
                                                                               Url.Action($"DeleteFertilizer/{item.FertilizerId}")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\">\r\n                                <i class=\"icofont-delete-alt\"></i>\r\n                            </button>\r\n\r\n\r\n                              </td>\r\n");
#nullable restore
#line 106 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Trader\GetAllFertilizers.cshtml"
                        i -= 1;

                        if (i == 0)
                        {
                            i = 5;

#line default
#line hidden
#nullable disable

            WriteLiteral("                        ");
            WriteLiteral("</tr>\r\n");
#nullable restore
#line 112 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Trader\GetAllFertilizers.cshtml"
                    }
                }
            }
        

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n\r\n    </table>\r\n\r\n ");
            Write(
#nullable restore
#line 120 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Trader\GetAllFertilizers.cshtml"
  Html.PagedListPager((IPagedList)Model, page => Url.Action("GetAllFertilizers", new { page }),
        new X.PagedList.Web.Common.PagedListRenderOptionsBase
        {
            DisplayItemSliceAndTotal = true,
            ContainerDivClasses = new[] { "navigation" },
            LiElementClasses = new[] { "page-item" },
            PageClasses = new[] { "page-link" }
        }
        )

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n\r\n</section>\r\n\r\n\r\n<script type=\"text/javascript\">\r\n\r\n    $(document).ready(function () {\r\n        $(\'ul.pagination > li.disabled > a\').addClass(\'page-link\');\r\n    });\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<X.PagedList.IPagedList<KisaanSnehiWebApplication.Models.FertilizerModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
