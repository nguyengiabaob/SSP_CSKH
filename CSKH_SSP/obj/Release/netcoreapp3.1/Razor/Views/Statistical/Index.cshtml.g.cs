#pragma checksum "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\Statistical\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "96115919c38e0d35d671daaa5b8250308d786df8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Statistical_Index), @"mvc.1.0.view", @"/Views/Statistical/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"96115919c38e0d35d671daaa5b8250308d786df8", @"/Views/Statistical/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_Statistical_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CSKH_SSP.ViewModels.Statistical.Statistical>>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\Statistical\Index.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"">
<link rel=""stylesheet"" href=""https://cdn.datatables.net/1.10.23/css/jquery.dataTables.min.css"">

<style>
    .dataTables_wrapper .dataTables_scroll div.dataTables_scrollBody {
        overflow-y: scroll !important;
    }
    .buttons-html5 {
        color: #fff;
        background-color: #007bff;
        border-color: #007bff;
        display: inline-block;
        font-weight: 400;
        text-align: center;
        white-space: nowrap;
        vertical-align: middle;
        -webkit-user-select: none;
        -moz-user-select: none;
        -ms-user-select: none;
        user-select: none;
        border: 1px solid transparent;
        border-top-color: transparent;
        border-right-color: transparent;
        border-bottom-color: transparent;
        border-left-color: transparent;
        padding: .375rem .75rem;
        font-size: 1rem;
        line-height: 1.5;
        bo");
            WriteLiteral("rder-radius: .25rem;\r\n        transition: color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;\r\n    }\r\n</style>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "96115919c38e0d35d671daaa5b8250308d786df84186", async() => {
                WriteLiteral(@"
    <div style=""padding: 40px"">
    <div class=""col-md-12 col-lg-12 col-xl-12"">
        <table id=""example"" class=""display"" style=""width:100%; overflow-x: scroll"">
            <thead>
                <tr>
                    <th>RequestID</th>
                    <th>Người tạo</th>
                    <th>Tên yêu cầu</th>
                    <th>Trạng thái</th>
                    <th>Ngày tạo</th>
                    <th>Ngày tiếp nhận</th>
                    <th>Ngày hoàn thành</th>
                    <th>Người xử lý</th>
                    <th>Người xử lý Lv2</th>
                    <th>Người xử lý Lv3</th>
                    <th>Danh mục</th>
                    <th>TicketID</th>
                    <th>Mã KH</th>
                    <th>Mã HĐ</th>
");
                WriteLiteral("                    <th>Nội dung trao đổi</th>\r\n                    <th>Tự xử lý</th>\r\n                    <th>SLAResponse</th>\r\n                    <th>SLAResolve</th>\r\n\r\n\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 67 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\Statistical\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 70 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\Statistical\Index.cshtml"
                   Write(item.RequestID);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 71 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\Statistical\Index.cshtml"
                   Write(item.RequestAuthorFullName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 72 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\Statistical\Index.cshtml"
                   Write(item.RequestTittle);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 73 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\Statistical\Index.cshtml"
                   Write(item.RequestStatus);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 74 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\Statistical\Index.cshtml"
                   Write(item.RequestDay);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 75 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\Statistical\Index.cshtml"
                   Write(item.ReceiverTime);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 76 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\Statistical\Index.cshtml"
                   Write(item.TimeDone);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 77 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\Statistical\Index.cshtml"
                   Write(item.AssignBy);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 78 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\Statistical\Index.cshtml"
                   Write(item.AssignLv2);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 79 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\Statistical\Index.cshtml"
                   Write(item.AssignLv3);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 80 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\Statistical\Index.cshtml"
                   Write(item.CategoryName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 81 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\Statistical\Index.cshtml"
                   Write(item.TicketID);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 82 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\Statistical\Index.cshtml"
                   Write(item.TicketCustomerID);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 83 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\Statistical\Index.cshtml"
                   Write(item.ContractID);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n");
                WriteLiteral("                    <td>");
#nullable restore
#line 85 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\Statistical\Index.cshtml"
                   Write(Html.Raw(item.RequestComment));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 86 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\Statistical\Index.cshtml"
                   Write(item.IsPrivate.ToString());

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 87 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\Statistical\Index.cshtml"
                   Write(item.SLAResponse.ToString());

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 88 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\Statistical\Index.cshtml"
                   Write(item.SLAResolve.ToString());

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\r\n\r\n                </tr>\r\n");
#nullable restore
#line 92 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\Statistical\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

            </tbody>
        </table>
    </div>
        </div>

    <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js""></script>
    <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js""></script>


    <script src=""https://code.jquery.com/jquery-3.5.1.js""></script>
    <script src=""https://cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js""></script>
    <script src=""https://cdn.datatables.net/buttons/1.6.5/js/dataTables.buttons.min.js""></script>
    <script src=""https://cdn.datatables.net/buttons/1.6.5/js/buttons.flash.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js""></script>
    <script src=""https://cdn.datatables.net/buttons/1.6.5/js/buttons.html5.min.js""></script>
    <script src=""https://cdn.datatables.net/buttons/1.6.5/js/buttons.print.min.js""></script>
    <script type=");
                WriteLiteral(@"""text/javascript"">
        $(document).ready(function () {
            $('#example').DataTable({
                ""scrollX"": true,
                dom: 'Bfrtip',
                buttons: [
                    { extend: 'excel', text: 'Export Excel' }
                ]
            });
        });
    </script>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CSKH_SSP.ViewModels.Statistical.Statistical>> Html { get; private set; }
    }
}
#pragma warning restore 1591
