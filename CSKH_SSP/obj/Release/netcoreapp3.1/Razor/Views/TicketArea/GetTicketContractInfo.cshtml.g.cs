#pragma checksum "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\TicketArea\GetTicketContractInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8a5d1ae59e96de97c0f79a3e283595e6441e2550"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TicketArea_GetTicketContractInfo), @"mvc.1.0.view", @"/Views/TicketArea/GetTicketContractInfo.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a5d1ae59e96de97c0f79a3e283595e6441e2550", @"/Views/TicketArea/GetTicketContractInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_TicketArea_GetTicketContractInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CSKH_SSP.ViewModels.TicketArea.TicketContract>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/css/jquery.dataTables.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("charset", new global::Microsoft.AspNetCore.Html.HtmlString("utf8"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/js/jquery.dataTables.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\TicketArea\GetTicketContractInfo.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8a5d1ae59e96de97c0f79a3e283595e6441e25504808", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 6 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\TicketArea\GetTicketContractInfo.cshtml"
 if (Model.Count > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <table id=""TiketContractCustomerTable"" class=""display compact table table-striped"" style=""width:100%"">
        <thead>
            <tr style=""white-space: pre;"">
                <th></th>
                <th id=""shortContractCodeCustomer"">Mã hợp đồng</th>
                <th>Hợp đồng bán</th>
                <th>Tên hợp đồng</th>
                <th>Phòng ban</th>
");
            WriteLiteral("            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 20 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\TicketArea\GetTicketContractInfo.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td style=\"text-align: center; padding-bottom: 30px;\"><input class=\"form-check-input\" type=\"checkbox\"");
            BeginWriteAttribute("value", " value=\"", 846, "\"", 872, 1);
#nullable restore
#line 23 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\TicketArea\GetTicketContractInfo.cshtml"
WriteAttributeValue("", 854, item.ContractFast, 854, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"TicketContractID\"");
            BeginWriteAttribute("id", " id=\"", 897, "\"", 902, 0);
            EndWriteAttribute();
            WriteLiteral("></td>\r\n                    <td>");
#nullable restore
#line 24 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\TicketArea\GetTicketContractInfo.cshtml"
                   Write(item.ContractCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td style=\"max-width: 400px;word-break: break-all;\">");
#nullable restore
#line 25 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\TicketArea\GetTicketContractInfo.cshtml"
                                                                   Write(item.ContractFast);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td style=\"max-width: 600px;word-break: break-all;\">");
#nullable restore
#line 26 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\TicketArea\GetTicketContractInfo.cshtml"
                                                                   Write(item.ContractName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 27 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\TicketArea\GetTicketContractInfo.cshtml"
                   Write(item.Department);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
            WriteLiteral("                </tr>\r\n");
#nullable restore
#line 30 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\TicketArea\GetTicketContractInfo.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </tbody>\r\n    </table>\r\n    <button type=\"button\" class=\"btn btn-primary\" onclick=\"chooseContract()\" data-dismiss=\"modal\">Lưu</button>\r\n");
#nullable restore
#line 35 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\TicketArea\GetTicketContractInfo.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""card m-b-30 quote-bg"">

        <div class=""card-body text-center"">
            <h5 class=""text-primary font-italic my-3"">404 ...<br> Không có dữ liệu hợp đồng.</h5>
            <button type=""button"" class=""btn btn-outline-primary"" onclick=""setNullContract()"">Chấp nhận</button>
        </div>
    </div>
");
#nullable restore
#line 45 "D:\SVN\SSP_TDC\Source\CSKH_SSP\CSKH_SSP\Views\TicketArea\GetTicketContractInfo.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8a5d1ae59e96de97c0f79a3e283595e6441e255010064", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script>
    //$('#TiketContractCustomerTable tbody').on('click', 'tr', function () {
    //    var dataContract = TiketContractCustomerTable.row(this).data();
    //    console.log(dataContract);

    //    $(""#TicketContractCode"").val(dataContract[0]);
    //    $(""#ContractCode_ModalInfo"").val(dataContract[0]);
    //    $(""#ContractFast_ModalInfo"").val(dataContract[1]);
    //    $(""#ContractName_ModalInfo"").val(dataContract[2]);
    //    $(""#Department_ModalInfo"").val(dataContract[3]);

    //    $(""#searchTicketCustomerArea"").addClass(""displayModalLoadingNone"");
    //    $(""#TicketCustomerInfoArea"").removeClass(""displayModalLoadingNone"");
    //    $('.list-ticket-contract-customer').modal('hide');
    //});

    function setNullContract() {
        $(""#searchTicketCustomerArea"").addClass(""displayModalLoadingNone"");
        $(""#TicketCustomerInfoArea"").removeClass(""displayModalLoadingNone"");
        $('.list-ticket-contract-customer').modal('hide');
    }
    function chooseCont");
            WriteLiteral(@"ract() {
        $(""#TicketContractCode"").val(contractIDList.toString());
        $(""#searchTicketCustomerArea"").addClass(""displayModalLoadingNone"");
        $(""#TicketCustomerInfoArea"").removeClass(""displayModalLoadingNone"");
        $('.list-ticket-contract-customer').modal('hide');
    }
   
        var contractIDList = [];
        $(""input[name='TicketContractID']"").change(function () {
            var checked = $(this).val();
            if ($(this).is(':checked')) {
                contractIDList.push(checked);
            } else {
                contractIDList.splice($.inArray(checked, tmp), 1);
            }
        });

        


    //TicketContractCode
</script>

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CSKH_SSP.ViewModels.TicketArea.TicketContract>> Html { get; private set; }
    }
}
#pragma warning restore 1591
