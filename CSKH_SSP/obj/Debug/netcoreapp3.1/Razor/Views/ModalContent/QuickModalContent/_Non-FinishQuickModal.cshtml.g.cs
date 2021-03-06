#pragma checksum "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_Non-FinishQuickModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fd2a0392d2d89ff953ebe9e02e1d2d0f4978ebb7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ModalContent_QuickModalContent__Non_FinishQuickModal), @"mvc.1.0.view", @"/Views/ModalContent/QuickModalContent/_Non-FinishQuickModal.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd2a0392d2d89ff953ebe9e02e1d2d0f4978ebb7", @"/Views/ModalContent/QuickModalContent/_Non-FinishQuickModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_ModalContent_QuickModalContent__Non_FinishQuickModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_Non-FinishQuickModal.cshtml"
  
    //var af = Model.ContentRequestHeader;
    var tempRequestID = Model.ContentRequestHeader.RequestID;
    var tempCategoryId = Model.ContentRequestHeader.CategoryID;


#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_Non-FinishQuickModal.cshtml"
 if (Model.GroupUserPermission.IsFinishRequest > 0 && @Model.RenderButton.FinishBtn)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""modal fade"" id=""Non-FinishQuickModal"" tabindex=""-1"" role=""dialog""
         aria-labelledby=""exampleStandardModalLabel"" aria-hidden=""true"" style=""display: none;"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""exampleStandardModalLabel"">T???m ho??n t???t y??u c???u</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">??</span>
                    </button>
                </div>

                <div class=""modal-body"">
                    <div class=""card-body"">
                        <form id=""Non-FinishForm"" ");
            WriteLiteral(@">
                            <div class=""form-group"">
                                <h6 class=""card-subtitle"">Ph??n lo???i l???i</h6>
                                <select class=""form-control"" id=""formSelectReason"" name=""ReasonId"">
                                </select>
                            </div>
                            <input type=""text"" class=""form-control"" name=""RequestID"" id=""RequestIDReject""");
            BeginWriteAttribute("value", "\r\n                                   value=\"", 1531, "\"", 1589, 1);
#nullable restore
#line 29 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_Non-FinishQuickModal.cshtml"
WriteAttributeValue("", 1575, tempRequestID, 1575, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" hidden>\r\n                            <input type=\"text\" class=\"form-control\" name=\"CategoryID\"");
            BeginWriteAttribute("value", " value=\"", 1685, "\"", 1708, 1);
#nullable restore
#line 30 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_Non-FinishQuickModal.cshtml"
WriteAttributeValue("", 1693, tempCategoryId, 1693, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" hidden>
                            <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">????ng</button>
                            <button type=""submit"" id=""Non-FinishFormBtn"" class=""btn btn-primary"">X??c nh???n</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        $.getJSON('");
#nullable restore
#line 40 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_Non-FinishQuickModal.cshtml"
              Write(Url.Action("GetReason","RequestContent"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"', function (data) {
            var toAppend = '';
            $.each(data, function (i, o) {
                toAppend += '<option value=""' + o.id + '"">' + o.title + '</option>';
            });

            $('#formSelectReason').append(toAppend);

            //console.log(data);
        });

        function FinishRequest(RequestID, CategoryID, Status) {
            swal({
                text: ""X??c nh???n ho??n th??nh Y??u c???u?"",
                type: 'question',
                showCancelButton: true,
                confirmButtonClass: 'btn btn-success',
                cancelButtonClass: 'btn btn-danger m-l-10',
                cancelButtonText: ""????ng"",
                confirmButtonText: 'X??c nh???n'
            }).then(function () {
                $.ajax({
                    url: '");
#nullable restore
#line 62 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_Non-FinishQuickModal.cshtml"
                     Write(Url.Action("ChangeStatusRequest", "RequestAction"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"' + '?RequestID=' + RequestID + '&CategoryID=' + CategoryID + '&Status=' + Status,
                    type: 'GET',
                    success: function (result) {
                        if (result == ""OK"") {
                            AlertForm(""Th??nh c??ng"", ""success"", false, ""OK"");
                            loadRequestContent('");
#nullable restore
#line 67 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_Non-FinishQuickModal.cshtml"
                                           Write(Model.ContentRequestHeader.RequestID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \"\");\r\n                            loadListRequest(\'");
#nullable restore
#line 68 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_Non-FinishQuickModal.cshtml"
                                        Write(Model.ContentRequestHeader.RequestID);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"');
                        } else {
                            alert(""L???i"");
                        }
                    }
                })
            }, function (dismiss) {
                if (dismiss === 'cancel') {
                    swal.close();
                }
            });
        }

        $(""#Non-FinishFormBtn"").click(function (event) {
            event.preventDefault();
            var form = $('#Non-FinishForm')[0];
            var data = new FormData(form);
            $(""#Non-FinishFormBtn"").prop(""disabled"", true);
            data.append('RequestID', '");
#nullable restore
#line 86 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_Non-FinishQuickModal.cshtml"
                                 Write(tempRequestID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\');\r\n            data.append(\'Status\', \'Closed\');\r\n\r\n            $.ajax({\r\n                type: \"POST\",\r\n                //enctype: \'multipart/form-data\',\r\n                url: \"");
#nullable restore
#line 92 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_Non-FinishQuickModal.cshtml"
                 Write(Url.Action("ChangeStatusRequest", "RequestAction"));

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
                        //animate__backOutLeft
                        flyToElement('RequestTitle', 'Closed');
                        toastr.success('Th??ng b??o !!!', 'Th??nh c??ng');
                        //AlertForm(""Th??nh c??ng"", ""success"", false, ""OK"");
                        $('.close').click();
                        loadListRequest(statusActive);
                        loadRequestContent('");
#nullable restore
#line 106 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_Non-FinishQuickModal.cshtml"
                                       Write(tempRequestID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \"\")\r\n                    }\r\n                },\r\n                error: function (e) {\r\n                }\r\n            });\r\n\r\n        });\r\n\r\n    </script>\r\n");
#nullable restore
#line 116 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_Non-FinishQuickModal.cshtml"
}
else { }

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
