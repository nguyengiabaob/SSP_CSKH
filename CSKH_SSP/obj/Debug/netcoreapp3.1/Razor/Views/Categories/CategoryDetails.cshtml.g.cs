#pragma checksum "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\Categories\CategoryDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d5b282ff9e0b551a6b976f4f1e8bfdd36a1f46dc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Categories_CategoryDetails), @"mvc.1.0.view", @"/Views/Categories/CategoryDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5b282ff9e0b551a6b976f4f1e8bfdd36a1f46dc", @"/Views/Categories/CategoryDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_Categories_CategoryDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CSKH_SSP.Services.CategoryServices.CategoryDetail>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/js/select2.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\Categories\CategoryDetails.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-lg-12\">\r\n        <div class=\"card m-b-30\">\r\n            <div class=\"card-header\">\r\n                <h5 class=\"card-title\">");
#nullable restore
#line 13 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\Categories\CategoryDetails.cshtml"
                                  Write(Model.category.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h5>\r\n                <h6 style=\"margin-top : 40px\"> Deadline Response  (giờ) </h6>\r\n");
#nullable restore
#line 15 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\Categories\CategoryDetails.cshtml"
                  
                    if (@Model.category.ParentId != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <input disabled id=\"HoursDeadline\" style=\"width : 20%\" type=\"number\" class=\"form-control\">\r\n");
#nullable restore
#line 19 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\Categories\CategoryDetails.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <input onchange=\"setHoursDeadline()\" id=\"HoursDeadline\" style=\"width : 20%\" type=\"number\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 881, "\"", 918, 1);
#nullable restore
#line 22 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\Categories\CategoryDetails.cshtml"
WriteAttributeValue("", 889, Model.category.HoursDeadline, 889, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 23 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\Categories\CategoryDetails.cshtml"
                    }
                

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br>\r\n                <h6 style=\"margin-top : 40px\"> Deadline Resolve (giờ) </h6>\r\n");
#nullable restore
#line 28 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\Categories\CategoryDetails.cshtml"
                  
                    if (@Model.category.ParentId != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <input disabled id=\"HourResolve\" style=\"width : 20%\" type=\"number\" class=\"form-control\" data-id=\"");
#nullable restore
#line 31 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\Categories\CategoryDetails.cshtml"
                                                                                                                    Write(Model.category.ParentId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n");
#nullable restore
#line 32 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\Categories\CategoryDetails.cshtml"
                    }
                    else
                    {
                        if (@Model.category.HoursResolve == null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <input onchange=\"setHoursDeadline()\" id=\"HourResolve\" style=\"width : 20%\" type=\"number\" class=\"form-control\" value=\"16\">\r\n");
#nullable restore
#line 38 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\Categories\CategoryDetails.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <input onchange=\"setHoursDeadline()\" id=\"HourResolve\" style=\"width : 20%\" type=\"number\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 1852, "\"", 1888, 1);
#nullable restore
#line 41 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\Categories\CategoryDetails.cshtml"
WriteAttributeValue("", 1860, Model.category.HoursResolve, 1860, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 42 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\Categories\CategoryDetails.cshtml"
                        }
                    }

                

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <br>
                <h6 class=""card-subtitle"" id=""ReponseText""> </h6>
                <h6 class=""card-subtitle"" id=""ResolveText""></h6>
            </div>
        </div>
    </div>
    <div class=""col-lg-12"">
        <div class=""card m-b-30"">
            <div class=""card-header"">
                <h5 class=""card-title"">Danh sách Người xử lý yêu cầu</h5>
            </div>
            <div class=""card-body"">
                <h6 class=""card-subtitle"">Có thể thêm nhiều tên cùng lúc .Click vào tên User xóa khỏi danh sách</h6>
                <div class=""row"">
                    <div class=""col-10"">
                        <div class=""form-group"">
                            <div class=""form-group"">
                                <select class=""select2-multi-select form-control select2-hidden-accessible""");
            BeginWriteAttribute("multiple", " multiple=\"", 2807, "\"", 2818, 0);
            EndWriteAttribute();
            WriteLiteral(@" data-select2-id=""2"" tabindex=""-1"" aria-hidden=""true"" id=""chooseUserAddStaff"">
                                </select>
                            </div>
                        </div>
                    </div>
                    <div class=""col-2"">
                        <button type=""button"" onclick=""AddUserToCategory()"" class=""btn btn-primary"">Thêm</button>
                    </div>
                </div>

                <div class=""button-list"" id=""listStaff"">
                </div>
            </div>
        </div>
    </div>

</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d5b282ff9e0b551a6b976f4f1e8bfdd36a1f46dc9406", async() => {
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
<script>
    var idParent= null;
    //chooseUserAddStaff
    $(document).ready(function () {
        $('#chooseUserAddStaff').select2({
            placeholder: 'Gõ họ tên hoặc user name người cần tìm',
        });
        idParent = $('#HourResolve').data('id');
        getParentHours();
        RenderPriorityText();
    });

        function fetchListUserCanChoose() {
            $('#chooseUserAddAdmin').empty();
            $('#chooseUserAddStaff').empty();
            $.getJSON(""api/Helpers/GetUserCanConfigPermission"", function (data) {
                var toAppend = '';
                $.each(data, function (i, o) {
                    toAppend += '<option value=""' + o.userName + '"">' + o.userName + ' - ' + o.fullName + '</option>';
                });
                $('#chooseUserAddAdmin').append(toAppend);
                $('#chooseUserAddStaff').append(toAppend);
                $(""#chooseUserAddAdmin"").trigger(""change"");
                $(""#chooseUserAddStaff"").trigger(""ch");
            WriteLiteral("ange\");\r\n                //console.log(data);\r\n            });\r\n         }\r\n\r\n\r\n\r\n        function AddUserToCategory() {\r\n            var arr = $(\"#chooseUserAddStaff\").val();\r\n            $.post(\"");
#nullable restore
#line 114 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\Categories\CategoryDetails.cshtml"
               Write(Url.Action("AddUserToCategory", "AdminAction"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n                {\r\n\r\n                        Username: arr,\r\n                        CategoryId: idParent ? idParent : \'");
#nullable restore
#line 118 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\Categories\CategoryDetails.cshtml"
                                                      Write(Model.category.IDCategory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"'
                    },
                    function (data, status) {
                        if (data == ""1"") {
                            fetchPermissionList();
                        } else {
                            alert(""Lỗi"");
                            $("".close"").click();
                        }
                    });
    };

    function setHoursDeadline(){
       let h = document.getElementById(""HoursDeadline"").value;
        let r = document.getElementById(""HourResolve"").value;
       $.post(""");
#nullable restore
#line 133 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\Categories\CategoryDetails.cshtml"
          Write(Url.Action("SetHoursDeadline", "AdminAction"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n                    {\r\n                        hours: h,\r\n                        hourResolve: r,\r\n                        CategoryId: \'");
#nullable restore
#line 137 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\Categories\CategoryDetails.cshtml"
                                Write(Model.category.IDCategory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"'
                    },
                    function (data, status) {
                        if (data == ""1"") {
                            RenderPriorityText();
                            alert(""Thay đổi thành công"")
                        } else {
                            alert(""Lỗi"");
                            $("".close"").click();
                        }
                    });
    }

      // public string DeleteUserFromCategory(string Username, int CategoryId)

        function DeleteUserFromCategory(Username) {
            $.post(""");
#nullable restore
#line 153 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\Categories\CategoryDetails.cshtml"
               Write(Url.Action("DeleteUserFromCategory", "AdminAction"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n                    {\r\n                        Username: Username,\r\n                        CategoryId: idParent ? idParent : \'");
#nullable restore
#line 156 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\Categories\CategoryDetails.cshtml"
                                                      Write(Model.category.IDCategory);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"'
                    },
                    function (data, status) {
                        if (data == ""1"") {
                            fetchPermissionList();
                        } else {
                            alert(""Lỗi"");
                            $("".close"").click();
                        }
                    });
    };
    function fetchListStaff(Id) {
        $('#listStaff').empty();
        $.getJSON(""api/Helpers/CategoryPermission?Id="" + Id, function (data) {
            var toAppend = '';
            $.each(data, function (i, o) {
                toAppend += '<div class=""btn btn-outline-primary categoryClass"" onclick=""DeleteUserFromCategory(\'' + o.userName + '\')"" value=""' + o.userName + '"">' + o.userName + '</div>';
            });
            $('#listStaff').append(toAppend);
            //console.log(data);
        });
    };
    function getParentHours() {
        let a = $('#HourResolve').data('id');
        if (a) {
            $.getJSON('api/Helper");
            WriteLiteral(@"s/GetCategoryById?Id=' + a, function (data) {
                console.log(data);
                $('#HoursDeadline').val(data.hoursDeadline);
                if (a.hourResolve) {
                    $('#HourResolve').val(data.hourResolve);
                }
                else {
                    $('#HourResolve').val(16);
                }
            })
        }
    }
    function RenderPriorityText() {
        $.getJSON('api/Helpers/GetAllPriority', function (data) {
            let txt1 = ""* Deadline Response được cộng thêm số giờ tương ứng với độ ưu tiên:"", txt2 = ""* Deadline Resolve sẽ được cộng thêm số giờ tương ứng với độ ưu tiên:"";
            $.each(data, function (i, e) {
                txt1 += `${e.priorityName}  :  ${e.hours + Number($('#HoursDeadline').val())} giờ ,`;
                txt2 += `${e.priorityName}  :  ${e.hours + Number($('#HourResolve').val())} giờ ,`
            })
            console.log(txt1);
            $('#ReponseText').text(txt1);
            $('#Re");
            WriteLiteral("solveText\').text(txt2);\r\n        })\r\n    }\r\n    function fetchPermissionList() {\r\n        fetchListUserCanChoose();\r\n        fetchListStaff(idParent ? idParent: \'");
#nullable restore
#line 207 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\Categories\CategoryDetails.cshtml"
                                        Write(Model.category.IDCategory);

#line default
#line hidden
#nullable disable
            WriteLiteral("\');\r\n    };\r\n    fetchPermissionList();\r\n\r\n\r\n\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CSKH_SSP.Services.CategoryServices.CategoryDetail> Html { get; private set; }
    }
}
#pragma warning restore 1591