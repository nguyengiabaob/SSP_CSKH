#pragma checksum "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_AddUserAssignQuickModalLv2.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "af5da948674d555425702cee752ab9bd58f5e3c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ModalContent_QuickModalContent__AddUserAssignQuickModalLv2), @"mvc.1.0.view", @"/Views/ModalContent/QuickModalContent/_AddUserAssignQuickModalLv2.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"af5da948674d555425702cee752ab9bd58f5e3c1", @"/Views/ModalContent/QuickModalContent/_AddUserAssignQuickModalLv2.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_ModalContent_QuickModalContent__AddUserAssignQuickModalLv2 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_AddUserAssignQuickModalLv2.cshtml"
 if (Model.GroupUserPermission.IsAddUserAssign > 0) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""modal fade bd-example-modal-lg"" id=""AddUserAssignQuickModal2"" tabindex=""-1"" role=""dialog"" style=""display: none;"" aria-hidden=""true"">
        <div class=""modal-dialog modal-lg"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""exampleLargeModalLabel"">Thêm người xử lý Lv2 </h5>
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
                                    <form ");
            WriteLiteral(" id=\"AddUserAssignForm\">\r\n");
            WriteLiteral("                                        <div class=\"form-group\">\r\n                                            <input type=\"text\" class=\"form-control\" name=\"RequestID\" id=\"RequestID_AddUserAssign\"");
            BeginWriteAttribute("value", " value=\"", 1693, "\"", 1738, 1);
#nullable restore
#line 25 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_AddUserAssignQuickModalLv2.cshtml"
WriteAttributeValue("", 1701, Model.ContentRequestHeader.RequestID, 1701, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" readonly hidden>
                                            <input type=""text"" class=""form-control"" name=""FormLevel"" id=""FormLevel"" value=""2"" readonly hidden>
                                            
                                            <div id=""AddUserAssignQuickModalLv2"" class=""row"">

                                                
                                            </div>
                                        </div>
                                        <div class=""form-group"">
                                            <input type=""text"" class=""form-control"" id=""requestIDToAddAssign"" hidden>
                                        </div>
                                        <button type=""submit"" class=""btn btn-primary"" id=""BtnAddUserAssignForm"">Lưu</button>
                                        <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Đóng</button>
                                    </form>
                                </div>
");
            WriteLiteral("                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            WriteLiteral("    <script>\r\n            function LoadListDepartmentLv2(RequestID) {\r\n                $.ajax({\r\n                type: \'GET\',\r\n                    url: \'");
#nullable restore
#line 53 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_AddUserAssignQuickModalLv2.cshtml"
                     Write(Url.Action("GetListDepartment", "ModalContent"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                    success: function (response) {
                        $('#ListDepartmentSelectionLv2').empty();
                        $(""#AddUserAssignQuickModal2"").find(""#AddUserAssignQuickModalLv2"").empty();
                        $(""#ListDepartmentSelectionLv2"").append($('<option value="""" selected> -------- </option>'));
                        if (response.length == 0) {
                            $(""#ListDepartmentSelectionLv2"").append($('<option>No data available</option>'));
                        }

                        $.each(response, function (index, value) {
                            $(""#ListDepartmentSelectionLv2"").append($('<option value=""' + value.departmentID + '"">' + value.departmentCode + '-' + value.departmentName + '</option>'));
                        });
                },
                error: function (error) {
                    console.log(error);
                }
            });
                $('#requestIDToAddAssign').val(RequestID);
      ");
            WriteLiteral(@"  }
        function GetUserOfThisDepartment(sel) {
            $(""#AddUserAssignQuickModal2"").find(""#AddUserAssignQuickModalLv2"").empty();
            $(""#AddUserAssignQuickModal2"").find(""#AddUserAssignQuickModalLv2"").text(""Loading...."");
            $.ajax({
                type: 'GET',
                url: '");
#nullable restore
#line 77 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_AddUserAssignQuickModalLv2.cshtml"
                 Write(Url.Action("GetUserOfDepartment", "ModalContent"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"' + '?DepartmentID=' + sel.value + ""&RequestID="" + $(""#requestIDToAddAssign"").val(),
                success: function (data) {
                    $(""#AddUserAssignQuickModal2"").find(""#AddUserAssignQuickModalLv2"").empty();
                    if (data.length == 0) {
                        $(""#AddUserAssignQuickModal2"").find(""#AddUserAssignQuickModalLv2"").append($('No data available'));
                    }
                    $.each(data, function (index, value) {
                        if (value.isAssignOrFollow == true) {
                            if (value.status === ""Ready"") {
                                $(""#AddUserAssignQuickModal2"").find(""#AddUserAssignQuickModalLv2"").append($('<div class=""col-6""><div class=""form-check form-check-flat""><input type=""checkbox"" class=""form-check-input"" name=""UserAssignLv2"" value=""' + value.userName + '"" checked>' + value.userName + '-' + value.fullName + ' ' + '<span class=""badge badge-success"">' + value.status + '</span></div></div>'));
               ");
            WriteLiteral(@"             } else {
                                $(""#AddUserAssignQuickModal2"").find(""#AddUserAssignQuickModalLv2"").append($('<div class=""col-6""><div class=""form-check form-check-flat""><input type=""checkbox"" class=""form-check-input"" name=""UserAssignLv2"" value=""' + value.userName + '"" checked>' + value.userName + '-' + value.fullName + ' ' + '<span class=""badge badge-warning"">' + value.status + '</span></div></div>'));
                            }
                        } else {
                            if (value.status === ""Ready"") {
                                $(""#AddUserAssignQuickModal2"").find(""#AddUserAssignQuickModalLv2"").append($('<div class=""col-6""><div class=""form-check form-check-flat""><input type=""checkbox"" class=""form-check-input"" name=""UserAssignLv2"" value=""' + value.userName + '"">' + value.userName + '-' + value.fullName + ' ' + '<span class=""badge badge-success"">' + value.status + '</span></div></div>'));
                            } else {
                                $");
            WriteLiteral(@"(""#AddUserAssignQuickModal2"").find(""#AddUserAssignQuickModalLv2"").append($('<div class=""col-6""><div class=""form-check form-check-flat""><input type=""checkbox"" class=""form-check-input"" name=""UserAssignLv2"" value=""' + value.userName + '"">' + value.userName + '-' + value.fullName + ' ' + '<span class=""badge badge-warning"">' + value.status + '</span></div></div>'));
                            }
                        }

                    });
                },
                error: function (error) {
                    console.log(error);
                }
            });
        }

        $(""#BtnAddUserAssignForm"").click(function (event) {
            event.preventDefault();
            var form = $('#AddUserAssignForm')[0];
            var data = new FormData(form);
            $(""#BtnAddUserAssignForm"").prop(""disabled"", true);
            //data.append('RequestID', '");
#nullable restore
#line 111 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_AddUserAssignQuickModalLv2.cshtml"
                                   Write(ViewBag.RequestID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\');\r\n            $.ajax({\r\n                type: \"POST\",\r\n                enctype: \'multipart/form-data\',\r\n                url: \"");
#nullable restore
#line 115 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_AddUserAssignQuickModalLv2.cshtml"
                 Write(Url.Action("UpdateUserAssignRequest", "RequestAction"));

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
#line 125 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_AddUserAssignQuickModalLv2.cshtml"
                                       Write(Model.ContentRequestHeader.RequestID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \"showSildeBar\");\r\n                    } else {\r\n                        alert(data);\r\n                        //$(\".close\").click();s\r\n                        loadRequestContent(\'");
#nullable restore
#line 129 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_AddUserAssignQuickModalLv2.cshtml"
                                       Write(Model.ContentRequestHeader.RequestID);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"', ""showSildeBar"");
                    }
                },
                error: function (e) {
                }
            });

        })

        function GetUserPermissionLv2(RequestID, FormLevel) {
             $('#requestIDToAddAssign').val(RequestID);
             $('#FormLevel').val(FormLevel);
            $(""#AddUserAssignQuickModalLv2"").find(""#ListUserOfThisDepartment"").empty();
            $(""#AddUserAssignQuickModalLv2"").find(""#ListUserOfThisDepartment"").text(""Loading...."");
            $.ajax({
                type: 'GET',
                url: '");
#nullable restore
#line 145 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_AddUserAssignQuickModalLv2.cshtml"
                 Write(Url.Action("GetUserPermission", "ModalContent"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\' + \'?categoryId=\' + ");
#nullable restore
#line 145 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_AddUserAssignQuickModalLv2.cshtml"
                                                                                      Write(Model.ContentRequestHeader.CategoryID);

#line default
#line hidden
#nullable disable
            WriteLiteral(" + \'&RequestID=\' + \'");
#nullable restore
#line 145 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_AddUserAssignQuickModalLv2.cshtml"
                                                                                                                                                Write(Model.ContentRequestHeader.RequestID);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"', //RequestID
                success: function (data) {
                    $(""#AddUserAssignQuickModalLv2"").find(""#ListUserOfThisDepartment"").empty();
                    if (data.length == 0) {
                        $(""#AddUserAssignQuickModalLv2"").find(""#ListUserOfThisDepartment"").append($('No data available'));
                    }
                    $.each(data, function (index, value) {
                        if (value.isAssignOrFollow == true) {
                            if (value.status === ""Ready"") {
                                $(""#AddUserAssignQuickModalLv2"").find(""#ListUserOfThisDepartment"").append($('<div class=""col-6""><div class=""form-check form-check-flat""><input type=""checkbox"" class=""form-check-input"" name=""UserAsssign"" value=""' + value.userName + '"" checked>' + value.userName + '-' + value.fullName + ' ' + '<span class=""badge badge-success"">' + value.status + '</span></div></div>'));
                            } else {
                                $(""#AddUserAssign");
            WriteLiteral(@"QuickModalLv2"").find(""#ListUserOfThisDepartment"").append($('<div class=""col-6""><div class=""form-check form-check-flat""><input type=""checkbox"" class=""form-check-input"" name=""UserAsssign"" value=""' + value.userName + '"" checked>' + value.userName + '-' + value.fullName + ' ' + '<span class=""badge badge-warning"">' + value.status + '</span></div></div>'));
                            }
                        } else {
                            if (value.status === ""Ready"") {
                                $(""#AddUserAssignQuickModalLv2"").find(""#ListUserOfThisDepartment"").append($('<div class=""col-6""><div class=""form-check form-check-flat""><input type=""checkbox"" class=""form-check-input"" name=""UserAsssign"" value=""' + value.userName + '"">' + value.userName + '-' + value.fullName + ' ' + '<span class=""badge badge-success"">' + value.status + '</span></div></div>'));
                            } else {
                                $(""#AddUserAssignQuickModalLv2"").find(""#ListUserOfThisDepartment"").append($('");
            WriteLiteral(@"<div class=""col-6""><div class=""form-check form-check-flat""><input type=""checkbox"" class=""form-check-input"" name=""UserAsssign"" value=""' + value.userName + '"">' + value.userName + '-' + value.fullName + ' ' + '<span class=""badge badge-warning"">' + value.status + '</span></div></div>'));
                            }
                        }

                    });
                },
                error: function (error) {
                    console.log(error);
                }
            });
        }

        


    </script>
");
#nullable restore
#line 178 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_AddUserAssignQuickModalLv2.cshtml"

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