#pragma checksum "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_AttachFileList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "20026b3c250845c35f1d4d7c1d9a775f50c05d20"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RequestContent__AttachFileList), @"mvc.1.0.view", @"/Views/RequestContent/_AttachFileList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20026b3c250845c35f1d4d7c1d9a775f50c05d20", @"/Views/RequestContent/_AttachFileList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_RequestContent__AttachFileList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"row\" style=\"padding-left: 10px;\">\r\n");
#nullable restore
#line 2 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_AttachFileList.cshtml"
     if (Model.AttachFile.Count > 0)
    {
        foreach (var i in Model.AttachFile)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-6 col-md-6 col-lg-6 col-xl-6 padding-left-0 \"");
            BeginWriteAttribute("onclick", " onclick=\"", 221, "\"", 278, 3);
            WriteAttributeValue("", 231, "location.href=\'/UploadedFiles/", 231, 30, true);
#nullable restore
#line 6 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_AttachFileList.cshtml"
WriteAttributeValue("", 261, i.FileNameOnDB, 261, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 276, "\';", 276, 2, true);
            EndWriteAttribute();
            WriteLiteral(@" style=""cursor: pointer"">
                <div class=""media"">
                    <span class=""align-self-center mr-3 action-icon-request badge badge-secondary-inverse"">
                        <i class=""feather icon-clipboard""></i>
                    </span>
                    <div class=""media-body"">
                        <p class=""mb-0"">Lo???i file:</p>
                        <h7 class=""mb-0"">");
#nullable restore
#line 13 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_AttachFileList.cshtml"
                                    Write(i.FileNameOriginal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h7>\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 18 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_AttachFileList.cshtml"
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
