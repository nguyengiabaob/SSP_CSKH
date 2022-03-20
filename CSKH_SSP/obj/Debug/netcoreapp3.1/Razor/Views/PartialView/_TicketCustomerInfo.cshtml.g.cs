#pragma checksum "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\PartialView\_TicketCustomerInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1a43662b64408281d2f366bd4d743a9d3ae0f14a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PartialView__TicketCustomerInfo), @"mvc.1.0.view", @"/Views/PartialView/_TicketCustomerInfo.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a43662b64408281d2f366bd4d743a9d3ae0f14a", @"/Views/PartialView/_TicketCustomerInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_PartialView__TicketCustomerInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n    <div class=\"row\" style=\"align-items: flex-end; display: flex\">\r\n        <div class=\"col-sm-9 col-md-3\">\r\n            <div class=\"form-group\">\r\n                <label");
            BeginWriteAttribute("for", " for=\"", 303, "\"", 309, 0);
            EndWriteAttribute();
            WriteLiteral(@"> Mã khách hàng</label><input required class=""form-control"" type=""text"" name=""TicketCustomerCode"" id=""TicketCustomerCode"" readonly>
            </div>
        </div>
        <div class=""col-sm-9 col-md-6"">
            <div class=""form-group"">
                <label");
            BeginWriteAttribute("for", " for=\"", 580, "\"", 586, 0);
            EndWriteAttribute();
            WriteLiteral("> Tên khách hàng</label><input required class=\"form-control\" type=\"text\" id=\"TicketCustomerName\" readonly>\r\n            </div>\r\n        </div>\r\n        <div class=\"col-sm-9 col-md-3\">\r\n            <div class=\"form-group\">\r\n                <label");
            BeginWriteAttribute("for", " for=\"", 832, "\"", 838, 0);
            EndWriteAttribute();
            WriteLiteral(@">Số điện thoại</label><input required class=""form-control"" type=""text"" id=""TicketCustomerNumPhone"" readonly>
            </div>
        </div>
    </div>
    <div class=""row"" style=""align-items: flex-end; display: flex"">
        <div class=""col-sm-9 col-md-4"">
            <div class=""form-group"">
                <label");
            BeginWriteAttribute("for", " for=\"", 1166, "\"", 1172, 0);
            EndWriteAttribute();
            WriteLiteral("> Email</label><input required class=\"form-control\" type=\"text\" id=\"TicketCustomerEmail\" readonly>\r\n            </div>\r\n        </div>\r\n        <div class=\"col-sm-9 col-md-4\">\r\n            <div class=\"form-group\">\r\n                <label");
            BeginWriteAttribute("for", " for=\"", 1410, "\"", 1416, 0);
            EndWriteAttribute();
            WriteLiteral("> Địa chỉ</label><input required class=\"form-control\" type=\"text\" id=\"TicketCustomerAddress\" readonly>\r\n            </div>\r\n        </div>\r\n        <div class=\"col-sm-9 col-md-4\">\r\n            <div class=\"form-group\">\r\n                <label");
            BeginWriteAttribute("for", " for=\"", 1658, "\"", 1664, 0);
            EndWriteAttribute();
            WriteLiteral(@">Số hợp đồng</label>
                <div class=""input-group mb-3"">
                    <input type=""text"" class=""form-control"" placeholder=""Không có dữ liệu hợp đồng"" name=""TicketContractID"" id=""TicketContractCode"" readonly hidden>
                    <div class=""input-group-append"">
                        <span class=""btn btn-primary animate__animated animate__pulse animate__repeat-3"" data-toggle=""modal"" data-target="".TicketContractInfo"" onclick=""getContractInfo()""><i class=""feather icon-info mr-2""></i> Thông tin hợp đồng</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
     function getContractInfo() {
         $(""#modalLoading"").removeClass(""displayModalLoadingNone"");
         var contractCode = $(""#TicketContractCode"").val();
            $.ajax({
                    type: ""GET"",
                url: '");
#nullable restore
#line 54 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\PartialView\_TicketCustomerInfo.cshtml"
                 Write(Url.Action("TicketContracts", "TicketArea"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"' + '?ContractId=' + contractCode ,
                    dataType: 'json',
                    success: function (response) {
                        $(""#modalLoading"").addClass(""displayModalLoadingNone"");
                        $('#records_table > tbody').empty();
                        var trHTML = '';
                        $.each(response, function (i, item) {
                            trHTML += '<tr>' +
                                '<td>' + item.contractCode + '</td>' +
                                '<td>' + item.contractFast + '</td>' +
                                '<td>' + item.contractName + '</td>' +
                                '<td>' + item.department + '</td>' +
                                '</tr>';
                        });

                        $('#records_table > tbody').append(trHTML);
                        
                    }
                });
        }
    </script>");
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
