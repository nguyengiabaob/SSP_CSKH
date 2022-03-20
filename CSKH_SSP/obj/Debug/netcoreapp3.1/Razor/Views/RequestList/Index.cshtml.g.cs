#pragma checksum "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1487ee657bc0cc70712014bf0b4925af34efa272"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RequestList_Index), @"mvc.1.0.view", @"/Views/RequestList/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1487ee657bc0cc70712014bf0b4925af34efa272", @"/Views/RequestList/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_RequestList_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CSKH_SSP.ViewModels.ListRequest.ListRequestAndPermission>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
  
    bool Reject = false;
    bool Receive = false;

    bool EditCategory = false;
    bool EditDateFinish = false;
    bool EditPriority = false;
    bool AddDepartmentAssign = false;
    bool AddUserFollow = false;
    bool AddUserAssign = false;

    if (Model.GroupUserPermission.IsEditRequest > 0)
    {
        EditCategory = true;
        EditDateFinish = true;
        EditPriority = true;
    }
    if (Model.GroupUserPermission.IsRejectRequest > 0)
    {
        Reject = true;
    }
    if (Model.GroupUserPermission.IsAddDepartmentAssign > 0)
    {
        AddDepartmentAssign = true;
    }
    if (Model.GroupUserPermission.IsAddUserFollow > 0)
    {
        AddUserFollow = true;
    }
    if (Model.GroupUserPermission.IsAddUserAssign > 0)
    {
        AddUserAssign = true;
    }
    if (Model.GroupUserPermission.IsReceiveRequest > 0)
    {
        Receive = true;
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 49 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
 if (Model.ListRequest.Count() > 0)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 91 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
     foreach (var item in Model.ListRequest)
    {
        

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"media border-bottom border-top border-gray RequestCard\"");
            BeginWriteAttribute("id", " id=\"", 4050, "\"", 4074, 2);
            WriteAttributeValue("", 4055, "Req-", 4055, 4, true);
#nullable restore
#line 94 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
WriteAttributeValue("", 4059, item.RequestID, 4059, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"background-color: white;cursor: pointer;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 4124, "\"", 4181, 4);
            WriteAttributeValue("", 4134, "loadRequestContent(\'", 4134, 20, true);
#nullable restore
#line 94 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
WriteAttributeValue("", 4154, item.RequestID, 4154, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4169, "\',", 4169, 2, true);
            WriteAttributeValue(" ", 4171, "\'\',false)", 4172, 10, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n");
            WriteLiteral("            <div class=\"media-body m-2\" style=\"display: flex;min-width: 0;margin-right: 10px !important;\">\r\n                <div class=\"col-12\" style=\"padding-right: 0px !important\">\r\n");
            WriteLiteral("\r\n\r\n                    <div class=\"d-flex justify-content-between align-items-center\">\r\n                        <p style=\"font-size: 13px; font-weight: 600\" class=\"mt-1 mb-0\"> ");
#nullable restore
#line 106 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
                                                                                   Write(item.RequestAuthor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p> <section>\r\n                            <span class=\"badge badge-info\"");
            BeginWriteAttribute("id", " id=\"", 5219, "\"", 5255, 2);
            WriteAttributeValue("", 5224, "requestCategory-", 5224, 16, true);
#nullable restore
#line 107 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
WriteAttributeValue("", 5240, item.RequestID, 5240, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">#");
#nullable restore
#line 107 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
                                                                                            Write(item.RequestCategory);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 108 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
                             if (item.RequestStatus == "Processing" || item.RequestStatus == "Closed" || item.RequestStatus == "Open")
                            {
                                if (item.isDeadLine == "HetHan")
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span class=\"badge badge-danger\">Hết hạn</span>\r\n");
#nullable restore
#line 113 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
                                }
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 117 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
                                   
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span class=\"badge badge-info\">Mới</span>\r\n");
#nullable restore
#line 121 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"

                                }
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </section>
                    </div>


                    <div class=""d-flex justify-content-between mb-1 mt-1"">
                        <div class=""wrapText"">
                            <strong style=""color: #0073e6;font-weight: 900;"">
                                ");
#nullable restore
#line 131 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
                           Write(item.RequestID);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 131 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
                                             Write(item.RequestTittle);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </strong>\r\n                        </div>");
#nullable restore
#line 133 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
                               if (item.attFile == true)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<span style=\"flex-shrink: 0;\"><i class=\"feather icon-paperclip mr-2\" style=\"color: #6c757d;\"></i></span>");
#nullable restore
#line 134 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
                                                                                                                                 }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n\r\n                    <div class=\"d-flex justify-content-between\">\r\n                        <p class=\"d-flex text-muted\" style=\"margin-bottom: 0px;font-size: 12px;letter-spacing: 0.8px;\">\r\n");
            WriteLiteral("                            <i class=\"ti-calendar mr-1\"></i>Ngày tạo ");
#nullable restore
#line 141 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
                                                                Write(item.RequestDay.Value.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </p>\r\n                        <p class=\"text-muted\">\r\n                            <i class=\"ti-bookmark-alt ml-1\"></i>\r\n                            ");
#nullable restore
#line 145 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
                        Write(item.RequestPriority == 1 ? "Ưu tiên thấp" : item.RequestPriority == 2 ? "Ưu tiên trung bình" : item.RequestPriority == 3 ? "Ưu tiên cao" : "Ưu tiên Gấp");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </p>\r\n                    </div>\r\n\r\n");
#nullable restore
#line 149 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
                     if (item.RequestStatus == "Done" && item.TimeDone != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <div class=""d-flex justify-content-end"">
                            <p class=""d-flex"" style=""margin-bottom: 0px;font-size: 12px;letter-spacing: 0.8px;color: red !important "">
                                <i class=""ti-calendar mr-1 text-muted""></i>Ngày hoàn thành : ");
#nullable restore
#line 153 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
                                                                                        Write(item.TimeDone.Value.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n                            </p>\r\n                        </div>\r\n");
#nullable restore
#line 156 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n        <!-- Start col -->\r\n");
            WriteLiteral("        <!-- End col -->\r\n");
#nullable restore
#line 376 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 422 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
                

}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-md-12 col-lg-12 col-xl-12\">\r\n        <div class=\"text-center mt-3 mb-5\">\r\n            <h6 style=\"color: gray\">Không có yêu cầu</h6>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 432 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<script>\r\n    if (");
#nullable restore
#line 434 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
   Write(Model.ListRequest.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral(" > 0) {\r\n            $(\"#currentTotalReq\").text(\'");
#nullable restore
#line 435 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
                                   Write(Model.ListRequest.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("\');\r\n    };\r\n        if (");
#nullable restore
#line 437 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
       Write(Model.TotalItem);

#line default
#line hidden
#nullable disable
            WriteLiteral(" > 0) {\r\n             $(\"#TotalReq\").text(\'");
#nullable restore
#line 438 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
                             Write(Model.TotalItem);

#line default
#line hidden
#nullable disable
            WriteLiteral("\');\r\n    };\r\n\r\n</script>\r\n\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n\r\n\r\n        //$(\".categories\").click(function () {\r\n        //    $(\"#requestID_toUpdatecategory\").val($(this).attr(\"data-requestid\"));\r\n        //})\r\n        //console.log(\'");
#nullable restore
#line 452 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
                  Write(ViewData["Notification"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\');\r\n        if (\'");
#nullable restore
#line 453 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestList\Index.cshtml"
        Write(ViewData["Notification"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"' == ""NewRequest"") {
            AlertForm(""Thêm yêu cầu thành công"", ""success"", false, ""Xác nhận"");
            window.history.pushState("""", """", ""RequestList"");
        }
        //$("".requestID_addDepartment_index"").click(function () {
        //    $(""#RequestID_AddDepartment"").val($(this).attr(""data-requestid""));
        //})
        //$("".requestID_addUserAssign_index"").click(function () {
        //    $(""#RequestID_AddUserAssign"").val($(this).attr(""data-requestid""));
        //})
        //$("".requestID_addUserFollow_index"").click(function () {
        //    $(""#RequestID_AddUserFollow"").val($(this).attr(""data-requestid""));
        //})
        //$("".editCategory_index"").click(function () {
        //    $(""#RequestID_EditCategory"").val($(this).attr(""data-requestid""));
        //})
        //$("".editDateFinish_index"").click(function () {
        //    $(""#RequestID_EditDateFinish"").val($(this).attr(""data-requestid""));
        //})
        //
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CSKH_SSP.ViewModels.ListRequest.ListRequestAndPermission> Html { get; private set; }
    }
}
#pragma warning restore 1591