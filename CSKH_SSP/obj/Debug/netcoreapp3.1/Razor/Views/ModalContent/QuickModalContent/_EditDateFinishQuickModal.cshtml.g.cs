#pragma checksum "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_EditDateFinishQuickModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4982692798c6ad3de618adc685d527333cc46517"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ModalContent_QuickModalContent__EditDateFinishQuickModal), @"mvc.1.0.view", @"/Views/ModalContent/QuickModalContent/_EditDateFinishQuickModal.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4982692798c6ad3de618adc685d527333cc46517", @"/Views/ModalContent/QuickModalContent/_EditDateFinishQuickModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_ModalContent_QuickModalContent__EditDateFinishQuickModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_EditDateFinishQuickModal.cshtml"
 if (Model.GroupUserPermission.IsEditRequest > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""modal fade"" id=""EditDateFinishQuickModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleStandardModalLabel"" aria-hidden=""true"" style=""display: none;"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""exampleStandardModalLabel"">Thay đổi ngày kết thúc</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">×</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <form method=""post"" id=""editDateForm"">
                        <input type=""text"" class=""form-control"" name=""RequestID"" id=""RequestID_EditDateFinish"" readonly hidden>
                        <div class=""form-group"">
                            <input type=""date"" name=""DateFinish"" id=""DateFinish"" class=""form-control"" aria-described");
            WriteLiteral(@"by=""basic-addon3"" required>
                        </div>
                        <button type=""submit"" id=""editDateFormBtn"" class=""btn btn-primary"">Lưu</button>
                        <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Đóng</button>
                    </form>
                </div>
            </div>
        </div>
    </div>
");
            WriteLiteral(@"    <script>
        function setRequestIdEditDateFinish(ReqID) {
            $(""#RequestID_EditDateFinish"").val(ReqID);
        }
        $(""#editDateFormBtn"").click(function (event) {
            event.preventDefault();
            var form = $('#editDateForm')[0];
            var data = new FormData(form);
            $(""#editDateFormBtn"").prop(""disabled"", true);
            $.ajax({
                type: ""POST"",
                enctype: 'multipart/form-data',
                url: """);
#nullable restore
#line 38 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_EditDateFinishQuickModal.cshtml"
                 Write(Url.Action("EditRequest", "RequestAction"));

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
                    if (data == ""OK"") {
                        AlertForm(""Thành công"", ""success"", false, ""OK"");
                        var tempDate = $(""#DateFinish"").val().split(""-"");
                        var DateFinishForAppend = tempDate[2] + ""/"" + tempDate[1] + ""/"" + tempDate[0];
                        $(""#DateFinish-"" + $('#RequestID_EditDateFinish').val()).text(DateFinishForAppend);
                        $('.close').click();
                        loadRequestContent($('#RequestID_EditDateFinish').val(), """")
                    }
                },
                error: function (e) {
                }
            });

        })
    </script>
");
#nullable restore
#line 60 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_EditDateFinishQuickModal.cshtml"
}
else { }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
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
