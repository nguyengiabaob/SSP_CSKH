#pragma checksum "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_AddUserFollowQuickModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fb6f2129afa99058f83e03f1d678e10b42bb4a80"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ModalContent_QuickModalContent__AddUserFollowQuickModal), @"mvc.1.0.view", @"/Views/ModalContent/QuickModalContent/_AddUserFollowQuickModal.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb6f2129afa99058f83e03f1d678e10b42bb4a80", @"/Views/ModalContent/QuickModalContent/_AddUserFollowQuickModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_ModalContent_QuickModalContent__AddUserFollowQuickModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_AddUserFollowQuickModal.cshtml"
 if (Model.GroupUserPermission.IsAddUserFollow > 0) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""modal fade bd-example-modal-lg"" id=""AddUserFollowQuickModal"" tabindex=""-1"" role=""dialog"" style=""display: none;"" aria-hidden=""true"">
        <div class=""modal-dialog modal-lg"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""exampleLargeModalLabel"">Thêm người theo dõi </h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">×</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <div class=""row"">
                        <!-- Start col -->

                        <div class=""col-lg-12"">
                            <div class=""card m-b-30"">
                                <div class=""card-body"">
                                    <form method=""post"" ");
            WriteLiteral(@" id=""AddUserFollowForm"">
                                        <div class=""form-group"">
                                            <label for=""sel1"">Chọn phòng ban:</label>
                                            <select class=""form-control"" id=""ListDepartmentSelection_AddUserFollow"" onchange=""GetUserOfThisDepartment_AddUserFollow(this);"">
                                            </select>
                                        </div>
                                        <div class=""form-group"">
                                            <input type=""text"" class=""form-control"" name=""RequestID"" id=""RequestID_AddUserFollow""");
            BeginWriteAttribute("value", " value=\"", 1707, "\"", 1752, 1);
#nullable restore
#line 25 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_AddUserFollowQuickModal.cshtml"
WriteAttributeValue("", 1715, Model.ContentRequestHeader.RequestID, 1715, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" readonly hidden>

                                            <div id=""ListUserOfThisDepartment_AddUserFollow"" class=""row"">

                                            </div>
                                        </div>
                                        <div class=""form-group"">
                                            <input type=""text"" class=""form-control"" id=""requestIDToAddAssign_AddUserFollow"" hidden>
                                        </div>
                                        <button type=""submit"" class=""btn btn-primary"" id=""BtnAddUserFollowForm"">Lưu</button>
                                        <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Đóng</button>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
");
            WriteLiteral("    <script>\r\n            function LoadListDepartment_AddUserFollow(RequestID) {\r\n                $.ajax({\r\n                type: \'GET\',\r\n                    url: \'");
#nullable restore
#line 51 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_AddUserFollowQuickModal.cshtml"
                     Write(Url.Action("GetListDepartment", "ModalContent"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                    success: function (response) {
                        $('#ListDepartmentSelection_AddUserFollow').empty();
                        $(""#AddUserFollowQuickModal"").find(""#ListUserOfThisDepartment_AddUserFollow"").empty();
                        $(""#ListDepartmentSelection_AddUserFollow"").append($('<option value="""" selected> -------- </option>'));
                        if (response.length == 0) {
                            $(""#ListDepartmentSelection_AddUserFollow"").append($('<option>No data available</option>'));
                        }

                        $.each(response, function (index, value) {
                            $(""#ListDepartmentSelection_AddUserFollow"").append($('<option value=""' + value.departmentID + '"">' + value.departmentCode + '-' + value.departmentName + '</option>'));
                        });
                },
                error: function (error) {
                    console.log(error);
                }
            });
           ");
            WriteLiteral(@"     $('#requestIDToAddAssign_AddUserFollow').val(RequestID);
        }
        function GetUserOfThisDepartment_AddUserFollow(sel) {
            $(""#AddUserFollowQuickModal"").find(""#ListUserOfThisDepartment_AddUserFollow"").empty();
            $(""#AddUserFollowQuickModal"").find(""#ListUserOfThisDepartment_AddUserFollow"").text(""Loading...."");

            $.ajax({
                type: 'GET',
                url: '");
#nullable restore
#line 76 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_AddUserFollowQuickModal.cshtml"
                 Write(Url.Action("GetUserOfDepartment", "ModalContent"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"' + '?DepartmentID=' + sel.value + ""&RequestID="" + $(""#requestIDToAddAssign_AddUserFollow"").val(),
                success: function (data) {
                    $('#AddUserFollowQuickModal').find(""#ListUserOfThisDepartment_AddUserFollow"").empty();

                    if (data.length == 0) {
                        $(""#AddUserFollowQuickModal"").find(""#ListUserOfThisDepartment_AddUserFollow"").append($('No data available'));
                    }
                    $.each(data, function (index, value) {
                        if (value.isAssignOrFollow == true) {
                            $(""#AddUserFollowQuickModal"").find(""#ListUserOfThisDepartment_AddUserFollow"").append($('<div class=""col-6""><div class=""form-check form-check-flat""><input type=""checkbox"" class=""form-check-input"" name=""UserFollow"" value=""' + value.userName + '"" checked>' + value.userName + '-' + value.fullName + '</div></div>'));
                        } else {
                            $(""#AddUserFollowQuickModal"").find(""#Li");
            WriteLiteral(@"stUserOfThisDepartment_AddUserFollow"").append($('<div class=""col-6""><div class=""form-check form-check-flat""><input type=""checkbox"" class=""form-check-input"" name=""UserFollow"" value=""' + value.userName + '"">' + value.userName + '-' + value.fullName + '</div></div>'));
                        }

                    });
                },
                error: function (error) {
                    console.log(error);
                }
            });
        }

        $(""#BtnAddUserFollowForm"").click(function (event) {
            event.preventDefault();
            var form = $('#AddUserFollowForm')[0];
            var data = new FormData(form);
            $(""#BtnAddUserFollowForm"").prop(""disabled"", true);
            //data.append('RequestID', '");
#nullable restore
#line 103 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_AddUserFollowQuickModal.cshtml"
                                   Write(ViewBag.RequestID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\');\r\n            $.ajax({\r\n                type: \"POST\",\r\n                enctype: \'multipart/form-data\',\r\n                url: \"");
#nullable restore
#line 107 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_AddUserFollowQuickModal.cshtml"
                 Write(Url.Action("UpdateUserFollowRequest", "RequestAction"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                data: data,
                processData: false,
                contentType: false,
                cache: false,
                timeout: 600000,
                success: function (data) {
                    //console.log(data);
                    if (data == ""OK"") {
                        //$("".close"").click();
                        loadRequestContent('");
#nullable restore
#line 117 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_AddUserFollowQuickModal.cshtml"
                                       Write(Model.ContentRequestHeader.RequestID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \"showSildeBar\");\r\n                    } else {\r\n                        alert(data);\r\n                        //$(\".close\").click();\r\n                        loadRequestContent(\'");
#nullable restore
#line 121 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_AddUserFollowQuickModal.cshtml"
                                       Write(Model.ContentRequestHeader.RequestID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \"showSildeBar\");\r\n                    }\r\n                },\r\n                error: function (e) {\r\n                }\r\n            });\r\n        })\r\n\r\n    </script>\r\n");
#nullable restore
#line 130 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_AddUserFollowQuickModal.cshtml"

}

#line default
#line hidden
#nullable disable
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
