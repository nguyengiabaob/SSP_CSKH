#pragma checksum "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_EditCategoryQuickModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cdcb6fafb7fa42f53b016149287df1e675702504"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ModalContent_QuickModalContent__EditCategoryQuickModal), @"mvc.1.0.view", @"/Views/ModalContent/QuickModalContent/_EditCategoryQuickModal.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cdcb6fafb7fa42f53b016149287df1e675702504", @"/Views/ModalContent/QuickModalContent/_EditCategoryQuickModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_ModalContent_QuickModalContent__EditCategoryQuickModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_EditCategoryQuickModal.cshtml"
 if (Model.GroupUserPermission.IsEditRequest > 0) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""modal fade bd-example-modal-lg"" id=""EditCategoryQuickModal"" tabindex=""-1"" role=""dialog"" style=""display: none;"" aria-hidden=""true"">
        <div class=""modal-dialog modal-lg"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""exampleLargeModalLabel"">Sửa danh mục </h5>
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
                                    <form method=""post"" id=""editCategoryForm"">
                                        <div class=""form-group"">
          ");
            WriteLiteral(@"                                  <label for=""sel1"">Chọn danh mục</label>
                                            <select class=""form-control"" id=""ListCategories"" name=""CategoryID"" onchange=""CurrentCategorySelected(this)"">
                                            </select>
                                        </div>
                                        <div class=""form-group"">
                                            <input type=""text"" class=""form-control"" name=""RequestID"" id=""RequestID_EditCategory"" readonly hidden>
                                        </div>
                                        <button type=""submit"" id=""editCategoryFormBtn"" class=""btn btn-primary"">Lưu</button>
                                        <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Đóng</button>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
 ");
            WriteLiteral(@"               </div>

            </div>
        </div>
    </div>
    <script>
        var CurrentCategory = """";
        function CurrentCategorySelected(val) {
             CurrentCategory =  val.options[val.selectedIndex].text;
        }
        function LoadCategoryList(CategoryID, ReqID) {
               $('#RequestID_EditCategory').val(ReqID)
                $.ajax({
                type: 'GET',
                    url: '");
#nullable restore
#line 47 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_EditCategoryQuickModal.cshtml"
                     Write(Url.Action("GetListCategories", "ModalContent"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                    success: function (response) {
                        $('#ListCategories').empty();
                    if (response.length == 0) {
                        $('#ListCategories').append($('<option>No data available</option>'));
                        }
                       // console.log(CategoryID);
                        // console.log(response);
                        $.each(response, function (index, value) {
                            if (value.idCategory == CategoryID) {
                                $('#ListCategories').append($('<option name=""CategoryID"" value=""' + value.idCategory + '"" selected>' + value.categoryName + '</option>'));
                            } else {
                                $('#ListCategories').append($('<option name=""CategoryID""  value=""' + value.idCategory + '"">' + value.categoryName + '</option>'));
                            }
                    });
                },
                error: function (error) {
           ");
            WriteLiteral(@"         console.log(error);
                }
            });
        }

        $(""#editCategoryFormBtn"").click(function (event) {
            event.preventDefault();
            var form = $('#editCategoryForm')[0];

            var data = new FormData(form);
            $(""#editCategoryFormBtn"").prop(""disabled"", true);
            $.ajax({
                type: ""POST"",
                enctype: 'multipart/form-data',
                url: """);
#nullable restore
#line 78 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_EditCategoryQuickModal.cshtml"
                 Write(Url.Action("EditRequest","RequestAction"));

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
                        $(""#requestCategory-"" + $('#RequestID_EditCategory').val()).text(""#"" + CurrentCategory);
                        $('.close').click();
                        loadRequestContent( $('#RequestID_EditCategory').val(), """")
                    }
                },
                error: function (e) {
                }
            });

        })
    </script>
");
#nullable restore
#line 98 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\QuickModalContent\_EditCategoryQuickModal.cshtml"
    }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
