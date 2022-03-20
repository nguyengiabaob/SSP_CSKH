#pragma checksum "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\FilterModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "57acd8fae5b4e3d001de2b6b90ab5e5a657bd216"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ModalContent_FilterModal), @"mvc.1.0.view", @"/Views/ModalContent/FilterModal.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57acd8fae5b4e3d001de2b6b90ab5e5a657bd216", @"/Views/ModalContent/FilterModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_ModalContent_FilterModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CSKH_SSP.ViewModels.Helper.CategoryAndPriority>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\FilterModal.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"col-lg-12\">\r\n    <div class=\"card m-b-30\">\r\n        <form action=\"javascript:Filter()\">\r\n");
            WriteLiteral("            <h6 class=\"card-subtitle\">Chọn trạng thái</h6>\r\n            <div class=\"input-group mb-3\">\r\n                <select class=\"custom-select\" id=\"selectStatus\">\r\n                    <option");
            BeginWriteAttribute("selected", " selected=\"", 631, "\"", 642, 0);
            EndWriteAttribute();
            WriteLiteral(@" value=""Open"">Đang chờ</option>
                    <option value=""Processing"">Đang xử lý</option>
                    <option value=""Closed"">Chờ xác nhận hoàn tất</option>
                    <option value=""Done"">Hoàn tất</option>
                    <option value=""Reject"">Từ chối</option>
                </select>
            </div>
            <h6 class=""card-subtitle"">Chọn danh mục</h6>
            <div class=""input-group mb-3"">
                <select class=""custom-select"" id=""selectCategory"">
                    <option");
            BeginWriteAttribute("value", " value=\"", 1184, "\"", 1192, 0);
            EndWriteAttribute();
            BeginWriteAttribute("selected", " selected=\"", 1193, "\"", 1204, 0);
            EndWriteAttribute();
            WriteLiteral(">.....</option>\r\n");
#nullable restore
#line 26 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\FilterModal.cshtml"
                     foreach (var i in Model.categoryList)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <option");
            BeginWriteAttribute("value", " value=\"", 1336, "\"", 1357, 1);
#nullable restore
#line 28 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\FilterModal.cshtml"
WriteAttributeValue("", 1344, i.IDCategory, 1344, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 28 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\FilterModal.cshtml"
                                                 Write(i.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</option>\r\n");
#nullable restore
#line 29 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\FilterModal.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </select>\r\n            </div>\r\n            <h6 class=\"card-subtitle\">Chọn mức ưu tiên</h6>\r\n            <div class=\"input-group mb-3\">\r\n                <select class=\"custom-select\" id=\"selectPriority\">\r\n                    <option");
            BeginWriteAttribute("value", " value=\"", 1655, "\"", 1663, 0);
            EndWriteAttribute();
            BeginWriteAttribute("selected", " selected=\"", 1664, "\"", 1675, 0);
            EndWriteAttribute();
            WriteLiteral(">.....</option>\r\n");
#nullable restore
#line 36 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\FilterModal.cshtml"
                     foreach (var i in Model.priorityList)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <option");
            BeginWriteAttribute("value", " value=\"", 1807, "\"", 1820, 1);
#nullable restore
#line 38 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\FilterModal.cshtml"
WriteAttributeValue("", 1815, i.ID, 1815, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Mức ưu tiên ");
#nullable restore
#line 38 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\FilterModal.cshtml"
                                                     Write(i.PriorityName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</option>\r\n");
#nullable restore
#line 39 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\FilterModal.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </select>
            </div>
            <button type=""submit"" class=""btn btn-primary"">Lọc</button>
            <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Tắt</button>
        </form>
    </div>
</div>
<script>
function Filter() {
    var statusID = $(""#selectStatus"").val();
    var categoryID = $(""#selectCategory"").val();
    var priorityID = $(""#selectPriority"").val();
    //var searchString = $(""#searchString"").val();
    categoryActive = categoryID;
    priorityActive = priorityID;
    statusActive = statusID;

    $(""#ListRequest"").load(""/RequestList/Index?statusRequest="" + statusID + ""&category="" + categoryID + ""&pri="" + priorityID);
    $("".close"").click();
    //console.log(statusID);
    activeStatus(statusID);
    //window.location.href = """);
#nullable restore
#line 61 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\FilterModal.cshtml"
                         Write(Url.Action("Index","RequestList"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" + \"?statusRequest=\" + statusID + \"&category=\" + categoryID + \"&pri=\" + priorityID;\r\n        };\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CSKH_SSP.ViewModels.Helper.CategoryAndPriority> Html { get; private set; }
    }
}
#pragma warning restore 1591
