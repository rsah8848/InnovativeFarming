#pragma checksum "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\AdminProfilePage.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4edefe7f5178cf0c2a475ecb71f4ccb86c036feee5f79f05a47c434e82bbff29"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_AdminProfilePage), @"mvc.1.0.view", @"/Views/Admin/AdminProfilePage.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"4edefe7f5178cf0c2a475ecb71f4ccb86c036feee5f79f05a47c434e82bbff29", @"/Views/Admin/AdminProfilePage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"836f88ad40f24e3399bee6693035cf27c7092749c88a5ae5db77dde5b7e5805d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_AdminProfilePage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<KisaanSnehiWebApplication.Models.RegistrationModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\AdminProfilePage.cshtml"
  
    ViewData["Title"] = "AdminProfilePage";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable

            WriteLiteral(@"
<section id=""Profile"" class=""d-flex flex-column justify-content-center align-items-center"">

    

    <div style=""margin-left: 25%; margin-right: 2%;"">
        <h1>Profile</h1>
        <h4></h4>
        <hr />
        <dl class=""row"">

            <dt class=""col-sm-2"">
                ");
            Write(
#nullable restore
#line 19 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\AdminProfilePage.cshtml"
                 Html.DisplayNameFor(model => model.Name)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
            Write(
#nullable restore
#line 22 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\AdminProfilePage.cshtml"
                 Html.DisplayFor(model => model.Name)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
            Write(
#nullable restore
#line 25 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\AdminProfilePage.cshtml"
                 Html.DisplayNameFor(model => model.EmailId)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
            Write(
#nullable restore
#line 28 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\AdminProfilePage.cshtml"
                 Html.DisplayFor(model => model.EmailId)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
            Write(
#nullable restore
#line 31 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\AdminProfilePage.cshtml"
                 Html.DisplayNameFor(model => model.PhoneNo)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
            Write(
#nullable restore
#line 34 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\AdminProfilePage.cshtml"
                 Html.DisplayFor(model => model.PhoneNo)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
            Write(
#nullable restore
#line 37 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\AdminProfilePage.cshtml"
                 Html.DisplayNameFor(model => model.Address)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
            Write(
#nullable restore
#line 40 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\AdminProfilePage.cshtml"
                 Html.DisplayFor(model => model.Address)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </dd>\r\n\r\n        </dl>\r\n        <div>\r\n            ");
            Write(
#nullable restore
#line 45 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\AdminProfilePage.cshtml"
             Html.ActionLink("Edit Profile", "EditAdminProfile", new { Model = Model })

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" |\r\n            ");
            Write(
#nullable restore
#line 46 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\AdminProfilePage.cshtml"
             Html.ActionLink("Change Password", "ChangeAdminPassword", new { Model = Model })

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" |\r\n            ");
            Write(
#nullable restore
#line 47 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\AdminProfilePage.cshtml"
             Html.ActionLink("Change Profile Picture", "UploadProfilePicture", new { Model = Model })

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" |\r\n            ");
            Write(
#nullable restore
#line 48 "D:\FYP\Innovate Farming\Kisan-Snehi-Project\KisaanSnehiWebApplication\Views\Admin\AdminProfilePage.cshtml"
             Html.ActionLink("Deactivate account", "DeactivateAdmin", new { id = Model.RegId })

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n        </div>\r\n\r\n    </div>\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<KisaanSnehiWebApplication.Models.RegistrationModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
