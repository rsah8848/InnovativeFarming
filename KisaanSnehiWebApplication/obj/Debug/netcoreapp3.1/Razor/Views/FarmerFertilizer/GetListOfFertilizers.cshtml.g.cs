#pragma checksum "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\GetListOfFertilizers.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1a0b6342b5e2047e86dfb8c897a0df91c0f1cab5c76ceeb03cba4558901a1351"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FarmerFertilizer_GetListOfFertilizers), @"mvc.1.0.view", @"/Views/FarmerFertilizer/GetListOfFertilizers.cshtml")]
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

#line default
#line hidden
#nullable disable
    ;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"1a0b6342b5e2047e86dfb8c897a0df91c0f1cab5c76ceeb03cba4558901a1351", @"/Views/FarmerFertilizer/GetListOfFertilizers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"836f88ad40f24e3399bee6693035cf27c7092749c88a5ae5db77dde5b7e5805d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_FarmerFertilizer_GetListOfFertilizers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<KisaanSnehiWebApplication.Models.FertilizerModel>>
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
#nullable restore
#line 3 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\GetListOfFertilizers.cshtml"
  
    ViewData["Title"] = "GetListOfFertilizers";
    Layout = "~/Views/Shared/_FarmerLayout.cshtml";

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a0b6342b5e2047e86dfb8c897a0df91c0f1cab5c76ceeb03cba4558901a13515556", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a0b6342b5e2047e86dfb8c897a0df91c0f1cab5c76ceeb03cba4558901a13515842", async() => {
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

    <style type=""text/css"">
        .btn {
            background-color: white;
            color: forestgreen;
            border: 2px solid forestgreen;
        }

            .btn:hover {
                background-color: forestgreen;
                color: white;
     ");
                WriteLiteral("       }\r\n    </style>\r\n\r\n");
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
            WriteLiteral("\r\n\r\n<section id=\"GetListOfFertilizers\" class=\"d-flex flex-column justify-content-center align-items-center\" style=\"margin-left:320px\">\r\n    <p style=\"text-align:center\">\r\n\r\n        <div id=\"PlaceHolderHere\"></div>\r\n\r\n\r\n");
#nullable restore
#line 59 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\GetListOfFertilizers.cshtml"
         using (Html.BeginForm("GetListOfFertilizers", "FarmerFertilizer", FormMethod.Get))
        {

#line default
#line hidden
#nullable disable

            WriteLiteral("            <button");
            BeginWriteAttribute("formaction", " formaction=\"", 1649, "\"", 1716, 1);
            WriteAttributeValue("", 1662, 
#nullable restore
#line 61 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\GetListOfFertilizers.cshtml"
                                 Url.Action("DisplayCartContents", "FarmerFertilizer")

#line default
#line hidden
#nullable disable
            , 1662, 54, false);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-secondary\" style=\"background-color:forestgreen; color:white; border:18px;\">Cart</button>\r\n");
            Write(
#nullable restore
#line 69 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\GetListOfFertilizers.cshtml"
             Html.TextBox("searchName", null, new { style = "height:36px; ", placeholder = "Search name..." })

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("            <button type=\"submit\" class=\"btn btn-primary\" style=\"background-color:forestgreen;color:white;\">\r\n                <i class=\"icofont icofont-search-2\"></i>\r\n            </button>\r\n");
            WriteLiteral("            <button");
            BeginWriteAttribute("formaction", " formaction=\"", 2583, "\"", 2657, 1);
            WriteAttributeValue("", 2596, 
#nullable restore
#line 74 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\GetListOfFertilizers.cshtml"
                                 Url.Action("GetAllPurchasedFertilizers", "FarmerFertilizer")

#line default
#line hidden
#nullable disable
            , 2596, 61, false);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-secondary\" style=\"background-color:forestgreen; color:white; border:18px;\">Purchase History</button>\r\n");
#nullable restore
#line 75 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\GetListOfFertilizers.cshtml"


        }

#line default
#line hidden
#nullable disable

            WriteLiteral("    </p>\r\n    <br />\r\n\r\n\r\n    <table class=\"table\">\r\n        <thead></thead>\r\n");
#nullable restore
#line 84 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\GetListOfFertilizers.cshtml"
          
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
#line 91 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\GetListOfFertilizers.cshtml"
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
#line 99 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\GetListOfFertilizers.cshtml"
                        }



#line default
#line hidden
#nullable disable

            WriteLiteral("                        <td style=\"align-items:center\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1a0b6342b5e2047e86dfb8c897a0df91c0f1cab5c76ceeb03cba4558901a135113028", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
            BeginWriteTagHelperAttribute();
            WriteLiteral(
#nullable restore
#line 103 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\GetListOfFertilizers.cshtml"
                                        "~/CropImages/" + item.Image

#line default
#line hidden
#nullable disable
            );
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("src", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = 
#nullable restore
#line 103 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\GetListOfFertilizers.cshtml"
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
            WriteLiteral(" <br />\r\n                            ");
            Write(
#nullable restore
#line 105 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\GetListOfFertilizers.cshtml"
                             Html.DisplayNameFor(model => model.FertilizerName)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" : ");
            Write(
#nullable restore
#line 105 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\GetListOfFertilizers.cshtml"
                                                                                   Html.DisplayFor(modelItem => item.FertilizerName)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" <br />\r\n");
            WriteLiteral("\r\n                            <button type=\"button\" class=\"btn btn-primary\" style=\"background-color:white;color:forestgreen;border-color:white\" data-toggle=\"ajax-modal\"\r\n                                    data-target=\"#GetFertilizerBasedOnID\" data-url=\"");
            Write(
#nullable restore
#line 111 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\GetListOfFertilizers.cshtml"
                                                                                     Url.Action($"GetFertilizerBasedOnID/{item.FertilizerId}")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(@""">
                                <i class=""icofont-2x icofont-shopping-cart""></i>
                            </button>
                            <button type=""button"" class=""btn btn-primary"" style=""background-color:white;color:forestgreen; border-color:white"" data-toggle=""ajax-modal""
                                    data-target=""#FertilizerDetails"" data-url=""");
            Write(
#nullable restore
#line 115 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\GetListOfFertilizers.cshtml"
                                                                                Url.Action($"FertilizerDetails/{item.FertilizerId}")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\">\r\n                                <i class=\"bx bx-detail\"></i>\r\n                            </button>\r\n\r\n\r\n                        </td>\r\n");
#nullable restore
#line 121 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\GetListOfFertilizers.cshtml"
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
#line 127 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\GetListOfFertilizers.cshtml"
                    }
                }
            }
        

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n\r\n    </table>\r\n\r\n\r\n\r\n</section>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<KisaanSnehiWebApplication.Models.FertilizerModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
