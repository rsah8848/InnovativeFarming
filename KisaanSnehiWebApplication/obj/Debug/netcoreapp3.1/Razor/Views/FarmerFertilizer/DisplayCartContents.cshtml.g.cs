#pragma checksum "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\DisplayCartContents.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5df29ac0c9e1029b0aea64a6504c93afc945ca6c5752b61627b640cb2be052d0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FarmerFertilizer_DisplayCartContents), @"mvc.1.0.view", @"/Views/FarmerFertilizer/DisplayCartContents.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"5df29ac0c9e1029b0aea64a6504c93afc945ca6c5752b61627b640cb2be052d0", @"/Views/FarmerFertilizer/DisplayCartContents.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"836f88ad40f24e3399bee6693035cf27c7092749c88a5ae5db77dde5b7e5805d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_FarmerFertilizer_DisplayCartContents : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<KisaanSnehiWebApplication.Models.FertilizerPurchaseModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\DisplayCartContents.cshtml"
  
    ViewData["Title"] = "DisplayCartContents";
    Layout = "~/Views/Shared/_FarmerLayout.cshtml";

#line default
#line hidden
#nullable disable

            WriteLiteral(@"
<style type=""text/css"">
    .btn {
        background-color: white;
        color: forestgreen;
        border: 2px solid forestgreen;
    }

        .btn:hover {
            background-color: forestgreen;
            color: white;
        }
</style>

<section id=""GetListOfFertilizers"" class=""d-flex flex-column justify-content-center align-items-center"" style=""margin-left:320px"">
    
    <table class=""table"">
        ");
            Write(
#nullable restore
#line 24 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\DisplayCartContents.cshtml"
         Html.ActionLink("Confirm order", "GenerateBill", "FarmerFertilizer", new { @class = "btn" })

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n        <thead>\r\n            <tr>\r\n");
            WriteLiteral("                <th>\r\n                    ");
            Write(
#nullable restore
#line 31 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\DisplayCartContents.cshtml"
                     Html.DisplayNameFor(model => model.FarmerId)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            Write(
#nullable restore
#line 34 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\DisplayCartContents.cshtml"
                     Html.DisplayNameFor(model => model.TraderId)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            Write(
#nullable restore
#line 37 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\DisplayCartContents.cshtml"
                     Html.DisplayNameFor(model => model.FertilizerId)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            Write(
#nullable restore
#line 40 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\DisplayCartContents.cshtml"
                     Html.DisplayNameFor(model => model.FertilizerPurchaseQuantity)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            Write(
#nullable restore
#line 43 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\DisplayCartContents.cshtml"
                     Html.DisplayNameFor(model => model.FertilizerBillAmount)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            Write(
#nullable restore
#line 46 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\DisplayCartContents.cshtml"
                     Html.DisplayNameFor(model => model.FertilizerPurchaseDate)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 52 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\DisplayCartContents.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable

            WriteLiteral("                <tr>\r\n");
            WriteLiteral("                    <td>\r\n                        ");
            Write(
#nullable restore
#line 59 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\DisplayCartContents.cshtml"
                         Html.DisplayFor(modelItem => item.FarmerId)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            Write(
#nullable restore
#line 62 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\DisplayCartContents.cshtml"
                         Html.DisplayFor(modelItem => item.TraderId)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            Write(
#nullable restore
#line 65 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\DisplayCartContents.cshtml"
                         Html.DisplayFor(modelItem => item.FertilizerId)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            Write(
#nullable restore
#line 68 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\DisplayCartContents.cshtml"
                         Html.DisplayFor(modelItem => item.FertilizerPurchaseQuantity)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            Write(
#nullable restore
#line 71 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\DisplayCartContents.cshtml"
                         Html.DisplayFor(modelItem => item.FertilizerBillAmount)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            Write(
#nullable restore
#line 74 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\DisplayCartContents.cshtml"
                         Html.DisplayFor(modelItem => item.FertilizerPurchaseDate)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
            WriteLiteral("                        ");
            Write(
#nullable restore
#line 79 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\DisplayCartContents.cshtml"
                         Html.ActionLink("Remove", "RemoveFromCart", "FarmerFertilizer", new { id = item.FertilizerId }, new { @class = "btn" })

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 82 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\FarmerFertilizer\DisplayCartContents.cshtml"

            }

#line default
#line hidden
#nullable disable

            WriteLiteral("        </tbody>\r\n    </table>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<KisaanSnehiWebApplication.Models.FertilizerPurchaseModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
