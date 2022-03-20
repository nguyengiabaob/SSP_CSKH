#pragma checksum "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8a5730427b13eab0b715be79ea28e3e7f44b0407"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RequestContent__RequestInfo), @"mvc.1.0.view", @"/Views/RequestContent/_RequestInfo.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a5730427b13eab0b715be79ea28e3e7f44b0407", @"/Views/RequestContent/_RequestInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_RequestContent__RequestInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("align-self-center rounded-circle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/svg/profile.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Generic placeholder image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("<!-- Start row -->\r\n");
            WriteLiteral(@"

<div class=""card"" style=""border-bottom: 1px solid rgba(0,0,0,.1)"">
    <div class=""card-header"" id=""headingTwoicon"" style="" display: flex; justify-content: space-between;"">
        <h5 class=""card-title"">
            Người xử lý Lv1
        </h5>

        <button class=""bbtn btn-primary-rgba"" type=""button""
                data-toggle=""collapse"" data-target=""#collapseTwoicon""
                aria-expanded=""true"" aria-controls=""collapseTwoicon"">
            <i class=""feather icon-plus mr-2""></i>Ẩn/Hiện
        </button>

    </div>
    <div id=""collapseTwoicon"" class=""collapse show"" aria-labelledby=""headingTwoicon""
         data-parent=""#accordionwithicon"">
        <div class=""card"">
            <div class=""chat-list"">
                <div class=""chat-user-list"">
                    <ul class=""list-unstyled mb-0"">
");
#nullable restore
#line 80 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                         if (Model.ListUsersAssign.Count > 0)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 82 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                             foreach (var item in Model.ListUsersAssign)
                            {
                                if (item.DepartmentID == 1)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li class=\"media\">\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8a5730427b13eab0b715be79ea28e3e7f44b04075596", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        <div class=\"media-body\">\r\n                                            <h5>\r\n                                                ");
#nullable restore
#line 92 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                                           Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 93 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                                                 if (Model.GroupUserPermission.IsRemoveAssign > 0)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span class=\"badge badge-light ml-2 CursorBtn\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3939, "\"", 4052, 8);
            WriteAttributeValue("", 3949, "DeleteUserAssign(\'", 3949, 18, true);
#nullable restore
#line 95 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
WriteAttributeValue("", 3967, Model.ContentRequestHeader.RequestID, 3967, 37, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4004, "\',\'", 4004, 3, true);
#nullable restore
#line 95 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
WriteAttributeValue("", 4007, item.UserID, 4007, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4019, "\',\'", 4019, 3, true);
#nullable restore
#line 95 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
WriteAttributeValue("", 4022, item.UserName, 4022, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4036, "\',", 4036, 2, true);
            WriteAttributeValue(" ", 4038, "\'UserAssign\')", 4039, 14, true);
            EndWriteAttribute();
            WriteLiteral(" style=\"float: right;\">X</span>\r\n");
#nullable restore
#line 96 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </h5>\r\n                                        <p>");
#nullable restore
#line 98 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                                      Write(item.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / Chức vụ</p>\r\n                                    </div>\r\n                                </li>");
#nullable restore
#line 100 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                                     }
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 101 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                             
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <li class=""media"">
                                <div class=""media-body text-center"">
                                    <h6 class=""text-muted"">
                                        Chưa có người xử lý
                                    </h6>

                                </div>
                            </li>
");
#nullable restore
#line 113 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </ul>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 117 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
             if (Model.GroupUserPermission.IsAddUserAssign > 0)
            {
                

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"card-footer\"><button type=\"button\" class=\"btn btn-primary btn-lg btn-block requestID_addUserAssign\" data-requestid=\"");
#nullable restore
#line 120 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                                                                                                                                           Write(Model.ContentRequestHeader.RequestID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"");
            BeginWriteAttribute("onclick", " onclick=\"", 5520, "\"", 5591, 4);
            WriteAttributeValue("", 5530, "GetUserPermission(\'", 5530, 19, true);
#nullable restore
#line 120 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
WriteAttributeValue("", 5549, Model.ContentRequestHeader.RequestID, 5549, 37, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5586, "\'", 5586, 1, true);
            WriteAttributeValue(" ", 5587, ",1)", 5588, 4, true);
            EndWriteAttribute();
            WriteLiteral(" data-toggle=\"modal\" data-target=\"#AddUserAssignQuickModal\">Thêm</button></div>\r\n");
#nullable restore
#line 121 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </div>
    </div>
</div>

<div class=""card"" style=""border-bottom: 1px solid rgba(0,0,0,.1)"">
    <div class=""card-header"" id=""headingTwoicon"" style="" display: flex; justify-content: space-between;"">
        <h5 class=""card-title"">
            Người xử lý Lv2
        </h5>

        <button class=""bbtn btn-primary-rgba"" type=""button""
                data-toggle=""collapse"" data-target=""#collapseTwoicon2""
                aria-expanded=""true"" aria-controls=""collapseTwoicon2"">
            <i class=""feather icon-plus mr-2""></i>Ẩn/Hiện
        </button>

    </div>
    <div id=""collapseTwoicon2"" class=""collapse show"" aria-labelledby=""headingTwoicon""
         data-parent=""#accordionwithicon"">
        <div class=""card"">
            <div class=""chat-list"">
                <div class=""chat-user-list"">
                    <ul class=""list-unstyled mb-0"">
");
#nullable restore
#line 145 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                         if (Model.ListUsersAssign.Count > 0)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 147 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                             foreach (var item in Model.ListUsersAssign)
                            {
                                if (item.DepartmentID == 2)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li class=\"media\">\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8a5730427b13eab0b715be79ea28e3e7f44b040714209", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        <div class=\"media-body\">\r\n                                            <h5>\r\n                                                ");
#nullable restore
#line 157 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                                           Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 158 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                                                 if (Model.GroupUserPermission.IsRemoveAssign > 0)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span class=\"badge badge-light ml-2 CursorBtn\"");
            BeginWriteAttribute("onclick", " onclick=\"", 7567, "\"", 7683, 8);
            WriteAttributeValue("", 7577, "DeleteUserAssign(\'", 7577, 18, true);
#nullable restore
#line 160 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
WriteAttributeValue("", 7595, Model.ContentRequestHeader.RequestID, 7595, 37, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7632, "\',\'", 7632, 3, true);
#nullable restore
#line 160 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
WriteAttributeValue("", 7635, item.UserID, 7635, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7647, "\',\'", 7647, 3, true);
#nullable restore
#line 160 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
WriteAttributeValue("", 7650, item.UserName, 7650, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7664, "\',", 7664, 2, true);
            WriteAttributeValue(" ", 7666, "\'UserAssignLv2\')", 7667, 17, true);
            EndWriteAttribute();
            WriteLiteral(" style=\"float: right;\">X</span>\r\n");
#nullable restore
#line 161 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </h5>\r\n                                            <p>");
#nullable restore
#line 163 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                                          Write(item.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / Chức vụ</p>\r\n                                        </div>\r\n                                    </li>\r\n");
#nullable restore
#line 166 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                                }


                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 169 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                             
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <li class=""media"">
                                <div class=""media-body text-center"">
                                    <h6 class=""text-muted"">
                                        Chưa có người xử lý
                                    </h6>

                                </div>
                            </li>
");
#nullable restore
#line 181 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </ul>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 185 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
             if (Model.GroupUserPermission.IsAddUserAssign > 0)
            {
                

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"card-footer\"><button type=\"button\" class=\"btn btn-primary btn-lg btn-block requestID_addUserAssign\" data-requestid=\"");
#nullable restore
#line 188 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                                                                                                                                           Write(Model.ContentRequestHeader.RequestID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"");
            BeginWriteAttribute("onclick", " onclick=\"", 9200, "\"", 9270, 3);
            WriteAttributeValue("", 9210, "GetUserPermission(\'", 9210, 19, true);
#nullable restore
#line 188 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
WriteAttributeValue("", 9229, Model.ContentRequestHeader.RequestID, 9229, 37, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 9266, "\',2)", 9266, 4, true);
            EndWriteAttribute();
            WriteLiteral(" data-toggle=\"modal\" data-target=\"#AddUserAssignQuickModal\">Thêm</button></div>\r\n");
#nullable restore
#line 189 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </div>
    </div>
</div>

<div class=""card"" style=""border-bottom: 1px solid rgba(0,0,0,.1)"">
    <div class=""card-header"" id=""headingTwoicon"" style="" display: flex; justify-content: space-between;"">
        <h5 class=""card-title"">
            Người xử lý Lv3
        </h5>

        <button class=""bbtn btn-primary-rgba"" type=""button""
                data-toggle=""collapse"" data-target=""#collapseTwoicon3""
                aria-expanded=""true"" aria-controls=""collapseTwoicon3"">
            <i class=""feather icon-plus mr-2""></i>Ẩn/Hiện
        </button>

    </div>
    <div id=""collapseTwoicon3"" class=""collapse show"" aria-labelledby=""headingTwoicon""
         data-parent=""#accordionwithicon"">
        <div class=""card"">
            <div class=""chat-list"">
                <div class=""chat-user-list"">
                    <ul class=""list-unstyled mb-0"">
");
#nullable restore
#line 213 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                         if (Model.ListUsersAssign.Count > 0)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 215 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                             foreach (var item in Model.ListUsersAssign)
                            {
                                if (item.DepartmentID == 3)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li class=\"media\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8a5730427b13eab0b715be79ea28e3e7f44b040722784", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    <div class=\"media-body\">\r\n                                        <h5>\r\n                                            ");
#nullable restore
#line 225 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                                       Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 226 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                                             if (Model.GroupUserPermission.IsRemoveAssign > 0)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <span class=\"badge badge-light ml-2 CursorBtn\"");
            BeginWriteAttribute("onclick", " onclick=\"", 11218, "\"", 11334, 8);
            WriteAttributeValue("", 11228, "DeleteUserAssign(\'", 11228, 18, true);
#nullable restore
#line 228 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
WriteAttributeValue("", 11246, Model.ContentRequestHeader.RequestID, 11246, 37, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 11283, "\',\'", 11283, 3, true);
#nullable restore
#line 228 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
WriteAttributeValue("", 11286, item.UserID, 11286, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 11298, "\',\'", 11298, 3, true);
#nullable restore
#line 228 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
WriteAttributeValue("", 11301, item.UserName, 11301, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 11315, "\',", 11315, 2, true);
            WriteAttributeValue(" ", 11317, "\'UserAssignLv3\')", 11318, 17, true);
            EndWriteAttribute();
            WriteLiteral(" style=\"float: right;\">X</span>\r\n");
#nullable restore
#line 229 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </h5>\r\n                                        <p>");
#nullable restore
#line 231 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                                      Write(item.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / Chức vụ</p>\r\n                                    </div>\r\n                                </li>\r\n");
#nullable restore
#line 234 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                                }
                                
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 236 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                             
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <li class=""media"">
                                <div class=""media-body text-center"">
                                    <h6 class=""text-muted"">
                                        Chưa có người xử lý
                                    </h6>

                                </div>
                            </li>
");
#nullable restore
#line 248 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </ul>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 252 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
             if (Model.GroupUserPermission.IsAddUserAssign > 0)
            {
                

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"card-footer\"><button type=\"button\" class=\"btn btn-primary btn-lg btn-block requestID_addUserAssign\" data-requestid=\"");
#nullable restore
#line 255 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                                                                                                                                           Write(Model.ContentRequestHeader.RequestID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"");
            BeginWriteAttribute("onclick", " onclick=\"", 12861, "\"", 12931, 3);
            WriteAttributeValue("", 12871, "GetUserPermission(\'", 12871, 19, true);
#nullable restore
#line 255 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
WriteAttributeValue("", 12890, Model.ContentRequestHeader.RequestID, 12890, 37, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 12927, "\',3)", 12927, 4, true);
            EndWriteAttribute();
            WriteLiteral(" data-toggle=\"modal\" data-target=\"#AddUserAssignQuickModal\">Thêm</button></div>\r\n");
#nullable restore
#line 256 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            WriteLiteral(@"
<script>
    function DeleteDepartment(RequestID, DepartmentID, DepartmentName) {
        swal({
                title: ""Xác nhận !!!"",
            text: ""Xác nhận xóa phòng "" + DepartmentName + "" khỏi danh sách"",
                type: 'question',
                showCancelButton: true,
                confirmButtonClass: 'btn btn-success',
                cancelButtonClass: 'btn btn-danger m-l-10',
                cancelButtonText: ""Đóng"",
                confirmButtonText: 'Xác nhận'
            }).then(function () {
                $.ajax({
                    url: '");
#nullable restore
#line 395 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                     Write(Url.Action("DeleteDepartmentAssign", "RequestAction"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"' + '?RequestID=' + RequestID + '&Department=' + DepartmentID,
                    type: 'GET',
                    success: function (result) {
                        if (result == ""OK"") {
                            AlertForm(""Thành công"", ""success"", false, ""OK"");
                            loadRequestContent('");
#nullable restore
#line 400 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                                           Write(Model.ContentRequestHeader.RequestID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \"showSildeBar\",false);\r\n                            //window.location.href = \'");
#nullable restore
#line 401 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                                                 Write(Url.Action("RequestContent", "RequestContent"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"' + '?RequestID=' + RequestID;
                        } else {
                            alert(""Lỗi"");
                        }
                    }
                })
            }, function (dismiss) {
                    if (dismiss === 'cancel') {
                        swal.dismiss();
                }
            });
    };

    function DeleteUserFollow(RequestID, UserID, UserName) {
        swal({
                title: ""Xác nhận !!!"",
            text: ""Xác nhận xóa "" + UserName + "" khỏi danh sách"",
                type: 'question',
                showCancelButton: true,
                confirmButtonClass: 'btn btn-success',
                cancelButtonClass: 'btn btn-danger m-l-10',
                cancelButtonText: ""Đóng"",
                confirmButtonText: 'Xác nhận'
            }).then(function () {
                $.ajax({
                    url: '");
#nullable restore
#line 426 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                     Write(Url.Action("DeleteUserFollow", "RequestAction"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"' + '?RequestID=' + RequestID + '&UserName=' + UserName,
                    type: 'GET',
                    success: function (result) {
                        if (result == ""OK"") {
                            AlertForm(""Thành công"", ""success"", false, ""OK"");
                            loadRequestContent('");
#nullable restore
#line 431 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                                           Write(Model.ContentRequestHeader.RequestID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \"showSildeBar\");\r\n                            //window.location.href = \'");
#nullable restore
#line 432 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                                                 Write(Url.Action("RequestContent", "RequestContent"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"' + '?RequestID=' + RequestID;
                        } else {
                            alert(""Lỗi"");
                        }
                    }
                })
            }, function (dismiss) {
                    if (dismiss === 'cancel') {
                        swal.dismiss();
                }
            });
    };

    function DeleteDepartmentFollow(RequestID, DepartmentID, DepartmentName) {
        swal({
                title: ""Xác nhận !!!"",
            text: ""Xác nhận xóa phòng "" + DepartmentName + "" khỏi danh sách"",
                type: 'question',
                showCancelButton: true,
                confirmButtonClass: 'btn btn-success',
                cancelButtonClass: 'btn btn-danger m-l-10',
                cancelButtonText: ""Đóng"",
                confirmButtonText: 'Xác nhận'
            }).then(function () {
                $.ajax({
                    url: '");
#nullable restore
#line 457 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                     Write(Url.Action("DeleteDepartmentFollow", "RequestAction"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"' + '?RequestID=' + RequestID + '&Department=' + DepartmentID,
                    type: 'GET',
                    success: function (result) {
                        if (result == ""OK"") {
                            AlertForm(""Thành công"", ""success"", false, ""OK"");
                            loadRequestContent('");
#nullable restore
#line 462 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                                           Write(Model.ContentRequestHeader.RequestID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \"showSildeBar\");\r\n                            //window.location.href = \'");
#nullable restore
#line 463 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                                                 Write(Url.Action("RequestContent", "RequestContent"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"' + '?RequestID=' + RequestID;
                        } else {
                            alert(""Lỗi"");
                        }
                    }
                })
            }, function (dismiss) {
                    if (dismiss === 'cancel') {
                        swal.dismiss();
                }
            });
    };
        function DeleteUserAssign(RequestID, UserID, UserName, level) {
        swal({
                title: ""Xác nhận !!!"",
            text: ""Xác nhận xóa "" + UserName + "" khỏi danh sách"",
                type: 'question',
                showCancelButton: true,
                confirmButtonClass: 'btn btn-success',
                cancelButtonClass: 'btn btn-danger m-l-10',
                cancelButtonText: ""Đóng"",
                confirmButtonText: 'Xác nhận'
            }).then(function () {
                $.ajax({
                    url: '");
#nullable restore
#line 487 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                     Write(Url.Action("DeleteUserAssign", "RequestAction"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"' + '?RequestID=' + RequestID + '&UserName=' + UserName + '&level=' + level,
                    type: 'GET',
                    success: function (result) {
                        if (result == ""OK"") {
                            AlertForm(""Thành công"", ""success"", false, ""OK"");
                            loadRequestContent('");
#nullable restore
#line 492 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                                           Write(Model.ContentRequestHeader.RequestID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \"showSildeBar\");\r\n                            //window.location.href = \'");
#nullable restore
#line 493 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_RequestInfo.cshtml"
                                                 Write(Url.Action("RequestContent", "RequestContent"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"' + '?RequestID=' + RequestID;
                        } else {
                            alert(""Lỗi"");
                        }
                    }
                })
            }, function (dismiss) {
                    if (dismiss === 'cancel') {
                        swal.dismiss();
                }
            });
    };

</script>
<!-- End row -->
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
