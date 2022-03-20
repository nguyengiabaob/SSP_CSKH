#pragma checksum "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c7a810834ccdc535c12bb9122db6d3804d1b3524"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7a810834ccdc535c12bb9122db6d3804d1b3524", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"col-xl-3 col-lg-4 col-12 col-sm-12 ListRequest\" style=\"height: 100vh\">\r\n    <div class=\"border-bottom border-gray mb-2 pl-3 pr-3 pt-2 pb-2\" style=\"background-color: white\">\r\n\r\n");
            WriteLiteral(@"        <div id=""danhSachYeuCauTitle"" class=""row align-items-center"">
            <div class=""col-5"">
                <h6 class=""card-title mb-0"">
                    Danh sách yêu cầu
                </h6>
            </div>
            <div class=""col-7 d-flex"">
                    <div class=""input-group"">
                        <input onchange=""searchRequest()"" id=""searchRequestInput"" placeholder=""Tìm theo tên yêu cầu, người tạo ..."" style=""background-color: rgba(129, 167, 205, 0.1);color: #263a5b;font-size: 16px;padding-left: 20px;border: none;border-radius: 3px 0 0 3px; font-size: 12px"" type=""text"" class=""form-control form-control-sm mr-2"" aria-label=""Amount (to the nearest dollar)"">
                    </div>
                    <button onclick=""searchRequest()"" style=""padding: 2px 6px"" class=""btn btn-primary-rgba""><i class=""feather icon-search""></i></button>
            </div>
        </div>
        <div class=""row align-items-center hideElement"" id=""userStatus"">
            <div class=");
            WriteLiteral(@"""col-9"">
                <h6 class=""card-title mb-0"">
                    Danh mục cha
                </h6>
            </div>
        </div>
        <div class=""col-md-12 col-lg-12 col-xl-12 hideElement"" id=""loadingListRequest"" style=""position: absolute; top:50%; "">
            <div class=""row justify-content-center"">
                <button class=""btn btn-primary"" type=""button""");
            BeginWriteAttribute("disabled", " disabled=\"", 2590, "\"", 2601, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <span class=""spinner-border spinner-border-sm"" role=""status"" aria-hidden=""true""></span>
                    Loading...
                </button>
            </div>
        </div>

    </div>
    <div id=""ListRequest"" style=""height: calc(100vh - 85px); overflow: auto; padding-bottom: 20px;"">
        <div class=""col-md-12 col-lg-12 col-xl-12"" id=""statusListRequest"" style=""position: absolute; top:50%"">
            <div class=""text-center mt-3 mb-5"">
                <h6 style=""color: gray"">Không có yêu cầu</h6>
            </div>
        </div>
    </div>
    <div class=""border-top border-gray mb-2 p-2"" style=""background-color: white; position: sticky; bottom: 0px; border-top: 1px solid #dee2e6 !important"" id=""loadMoreBtn"">
        <div class=""row align-items-center justify-content-center"" onclick=""loadMore()"" style=""cursor: pointer"" id=""loadMore"">
            <h7 class=""card-title mb-0"">
                Tải thêm ( <strong id=""currentTotalReq"" class=""text-muted"" style=""font");
            WriteLiteral(@"-weight: 100;"">0</strong> / <strong id=""TotalReq"" style=""font-weight: 100; color: #0080ff"">0</strong> )
            </h7>
        </div>
    </div>

</div>
<div class=""col-xl-9 col-lg-8 col-12 col-sm-12 RequestContent"" style=""padding-top: 10px; padding-bottom: 20px; height: 100vh; overflow: auto"">
    <div class=""col-md-12 col-lg-12 col-xl-12 hideElement"" id=""loadingRequestContent"" style=""position: absolute; top:50%"">
        <div class=""row justify-content-center"">
            <button class=""btn btn-primary"" type=""button""");
            BeginWriteAttribute("disabled", " disabled=\"", 4163, "\"", 4174, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                <span class=""spinner-border spinner-border-sm"" role=""status"" aria-hidden=""true""></span>
                Loading...
            </button>
        </div>
    </div>
    <div id=""RequestContent"">
        <div class=""col-md-12 col-lg-12 col-xl-12"" id=""loadingRequestContent"" style=""position: absolute; top:50%"">
            <div class=""row justify-content-center"">
                <h6 style=""color: gray"">Không có yêu cầu</h6>
            </div>
        </div>
    </div>
</div>


");
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