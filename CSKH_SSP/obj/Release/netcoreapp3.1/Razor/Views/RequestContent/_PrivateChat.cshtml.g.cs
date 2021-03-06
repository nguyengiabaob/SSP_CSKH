#pragma checksum "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_PrivateChat.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a72ff29c01535eaeaa4a14fd3fc7a1a567471558"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RequestContent__PrivateChat), @"mvc.1.0.view", @"/Views/RequestContent/_PrivateChat.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a72ff29c01535eaeaa4a14fd3fc7a1a567471558", @"/Views/RequestContent/_PrivateChat.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_RequestContent__PrivateChat : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/svg/profile.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("profile"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_PrivateChat.cshtml"
 if (@Model.GroupUserPermission.IsUsePrivateChat > 0) {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <ul class=\"list-unstyled\">\r\n        <li class=\"media\">\r\n            <div class=\"card text-white bg-dark m-b-30\" style=\"width: 100%;\">\r\n\r\n                <div class=\"card-body\">\r\n                    <form id=\"SendPrivateChatOrAdviceForm\" ");
            WriteLiteral(">\r\n                        <h5 class=\"card-title text-white\">Trao ?????i / Ghi ch?? n???i b???.</h5>\r\n                        <input type=\"text\" class=\"form-control\" name=\"RequestID\" id=\"RequestID_PriveteNote\"");
            BeginWriteAttribute("value", " value=\"", 580, "\"", 625, 1);
#nullable restore
#line 9 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_PrivateChat.cshtml"
WriteAttributeValue("", 588, Model.ContentRequestHeader.RequestID, 588, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" readonly hidden>
                        <p class=""card-text"">Ch??? qu???n tr???, ng?????i ???????c ph??n quy???n m???i c?? th??? s??? d???ng v?? ?????c n???i dung ch???c n??ng n??y.</p>
                        <textarea class=""form-control"" name=""ContentPrivateChat"" id=""inputTextarea"" rows=""2"" placeholder=""Nh???p n???i dung""></textarea>
                        <button type=""submit"" id=""BtnSendPrivateChatOrAdviceForm"" class=""btn btn-success-rgba"" style=""margin-top: 8px;""><i class=""feather icon-send mr-2""></i> G???i</button>
                    </form>
                </div>
            </div>
        </li>
");
#nullable restore
#line 17 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_PrivateChat.cshtml"
         if (Model.PrivateChat.Count > 0) {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_PrivateChat.cshtml"
             foreach (var item in Model.PrivateChat) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"media m-b-30\">\r\n                    <span class=\"align-self-center mr-3 action-icon-request\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a72ff29c01535eaeaa4a14fd3fc7a1a5674715586159", async() => {
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
            WriteLiteral("</span>\r\n                    <div class=\"media-body\">\r\n                        <h6 class=\"font-16 mt-0 mb-1\">");
#nullable restore
#line 22 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_PrivateChat.cshtml"
                                                 Write(item.AuthorFullName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span></span></h6>\r\n                        <p class=\"mb-0\">\r\n                            ");
#nullable restore
#line 24 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_PrivateChat.cshtml"
                       Write(Html.Raw(@item.ContentRequest));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </p>\r\n                        <p class=\"mb-0\" style=\"font-size: 10px\">\r\n                            ");
#nullable restore
#line 27 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_PrivateChat.cshtml"
                       Write(item.DateTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </p>\r\n                    </div>\r\n                </li>\r\n");
#nullable restore
#line 31 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_PrivateChat.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_PrivateChat.cshtml"
             
        } else {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"media m-b-30\">\r\n                <div class=\"media-body\">\r\n                    <h6 class=\"font-16 mt-0 mb-1\" style=\"color:#8A98AC \">Ch??a c?? n???i dung</h6>\r\n                </div>\r\n            </li>\r\n");
#nullable restore
#line 38 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_PrivateChat.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </ul>
    <script>
        $(""#BtnSendPrivateChatOrAdviceForm"").click(function (event) {
            event.preventDefault();
            var form = $('#SendPrivateChatOrAdviceForm')[0];
            var data = new FormData(form);
            $(""#BtnSendPrivateChatOrAdviceForm"").prop(""disabled"", true);
            //data.append('RequestID', '");
#nullable restore
#line 46 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_PrivateChat.cshtml"
                                   Write(ViewBag.RequestID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\');\r\n            $.ajax({\r\n                type: \"POST\",\r\n                enctype: \'multipart/form-data\',\r\n                url: \"");
#nullable restore
#line 50 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_PrivateChat.cshtml"
                 Write(Url.Action("SendPrivateChatOrAdvice", "RequestAction"));

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
#line 60 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_PrivateChat.cshtml"
                                       Write(Model.ContentRequestHeader.RequestID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \"review-tab-line\");\r\n                    } else {\r\n                        alert(data);\r\n                        //$(\".close\").click();\r\n                        loadRequestContent(\'");
#nullable restore
#line 64 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_PrivateChat.cshtml"
                                       Write(Model.ContentRequestHeader.RequestID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \"review-tab-line\");\r\n                    }\r\n                },\r\n                error: function (e) {\r\n                }\r\n            });\r\n        })\r\n    </script>\r\n");
#nullable restore
#line 72 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\RequestContent\_PrivateChat.cshtml"
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
