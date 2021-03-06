#pragma checksum "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\AddCategory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "714dca0909e64ddcb894e35082e03e1786389ced"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ModalContent_AddCategory), @"mvc.1.0.view", @"/Views/ModalContent/AddCategory.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"714dca0909e64ddcb894e35082e03e1786389ced", @"/Views/ModalContent/AddCategory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_ModalContent_AddCategory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\AddCategory.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    .delCategory {
        text-decoration-line: line-through;
    }
</style>
<div class=""card-body"">
    <h6 class=""card-subtitle"">Thêm danh mục: </h6>
   
    
    <form id=""addCategoryForm"">
        <div class=""input-group mb-5"">
            <input type=""text"" class=""form-control"" name=""CategoryName"" id=""CategoryName"">
            <div class=""input-group-append"" id=""button-addon4"">
                <button id=""addCategoryFormBtn"" class=""btn btn-outline-primary"" type=""button""><i class=""feather icon-plus mr-2""></i> Thêm</button>
            </div>
        </div>
    </form>
    <h6 class=""card-subtitle"">Click vào Tên danh mục để xóa hoặc khôi phục.</h6>
    <div class=""button-list"" id=""listCategory"">

");
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");
            WriteLiteral(@"
<script>


    function fetchCategory() {
        $('#listCategory').empty();
        $.getJSON(""api/Helpers/GetAllCategory"", function (data) {
            var toAppend = '';
            $.each(data, function (i, o) {
                if (o.isActive == false) {
                    toAppend += '<div class=""btn btn-light delCategory categoryClass"" value=""' + o.idCategory + '"">' + o.categoryName + '</div>';
                } else {
                    toAppend += '<div class=""btn btn-outline-primary categoryClass"" value=""' + o.idCategory + '"">' + o.categoryName + '</div>';
                }
            });
            $('#listCategory').append(toAppend);
            //console.log(data);
        });
    }
    fetchCategory();
    $(""#addCategoryFormBtn"").click(function (event) {
            event.preventDefault();
        var form = $('#addCategoryForm')[0];
        var data = new FormData(form);
        $(""#addCategoryFormBtn"").prop(""disabled"", true);
            $.ajax({
              ");
            WriteLiteral("  type: \"POST\",\r\n                url: \"");
#nullable restore
#line 64 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\AddCategory.cshtml"
                 Write(Url.Action("AddCategory", "AdminAction"));

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
                    if (data == ""1"") {
                        fetchCategory();
                    } else {
                        alert(""Lỗi hoặc đã tồn tại"");
                        $("".close"").click();
                    }
                },
                error: function (e) {
                }
            });

    });



        //btn-light
        // Create a ""close"" button and append it to each list item

        // Add a ""checked"" symbol when clicking on a list item
        var list = document.querySelector('#listCategory');
    list.addEventListener('click', function (ev) {
        if (ev.target.classList.contains('categoryClass')) {
                        var isEnable = true;
            ev.target.classList.toggle('btn-outline-primary');
            ev.targe");
            WriteLiteral("t.classList.toggle(\'btn-light\');\r\n            ev.target.classList.toggle(\'delCategory\');\r\n            if (ev.target.classList.contains(\"delCategory\")) {\r\n                isEnable = false;\r\n            };\r\n\r\n                $.post(\"");
#nullable restore
#line 101 "D:\SSP_CSKH\Source\CSKH_SSP\CSKH_SSP\Views\ModalContent\AddCategory.cshtml"
                   Write(Url.Action("DisableCategory", "AdminAction"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                    {
                        status: ev.target.getAttribute('value') + ""--"" + isEnable
                    },
                    function (data, status) {
                        if (data == ""1"") {
                            fetchCategory();
                        } else {
                            alert(""Lỗi"");
                            $("".close"").click();
                        }
                    });
        }
        }, false);
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
