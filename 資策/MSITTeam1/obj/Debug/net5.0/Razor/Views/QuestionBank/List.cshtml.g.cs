#pragma checksum "C:\Users\User\Documents\ispanProject\資策\MSITTeam1\Views\QuestionBank\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ba772f3a98507e99481383b8481cb33c6619131"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_QuestionBank_List), @"mvc.1.0.view", @"/Views/QuestionBank/List.cshtml")]
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
#nullable restore
#line 1 "C:\Users\User\Documents\ispanProject\資策\MSITTeam1\Views\_ViewImports.cshtml"
using MSITTeam1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Documents\ispanProject\資策\MSITTeam1\Views\_ViewImports.cshtml"
using MSITTeam1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ba772f3a98507e99481383b8481cb33c6619131", @"/Views/QuestionBank/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c8c432f2506f7ceb94eb7694516981c68ff65a14", @"/Views/_ViewImports.cshtml")]
    public class Views_QuestionBank_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MSITTeam1.Models.TQuestionList>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\User\Documents\ispanProject\資策\MSITTeam1\Views\QuestionBank\List.cshtml"
  
    ViewData["Title"] = "List";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>題目列表</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8ba772f3a98507e99481383b8481cb33c66191313684", async() => {
                WriteLiteral("新增題目");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\User\Documents\ispanProject\資策\MSITTeam1\Views\QuestionBank\List.cshtml"
           Write(Html.DisplayNameFor(model => model.FQuestion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\User\Documents\ispanProject\資策\MSITTeam1\Views\QuestionBank\List.cshtml"
           Write(Html.DisplayNameFor(model => model.FQuestionImage));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\User\Documents\ispanProject\資策\MSITTeam1\Views\QuestionBank\List.cshtml"
           Write(Html.DisplayNameFor(model => model.FQuestionTypeId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Users\User\Documents\ispanProject\資策\MSITTeam1\Views\QuestionBank\List.cshtml"
           Write(Html.DisplayNameFor(model => model.FUpdateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "C:\Users\User\Documents\ispanProject\資策\MSITTeam1\Views\QuestionBank\List.cshtml"
           Write(Html.DisplayNameFor(model => model.FLevel));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 34 "C:\Users\User\Documents\ispanProject\資策\MSITTeam1\Views\QuestionBank\List.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 37 "C:\Users\User\Documents\ispanProject\資策\MSITTeam1\Views\QuestionBank\List.cshtml"
           Write(Html.DisplayFor(modelItem => item.FQuestion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 40 "C:\Users\User\Documents\ispanProject\資策\MSITTeam1\Views\QuestionBank\List.cshtml"
           Write(Html.DisplayFor(modelItem => item.FQuestionImage));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 43 "C:\Users\User\Documents\ispanProject\資策\MSITTeam1\Views\QuestionBank\List.cshtml"
           Write(Html.DisplayFor(modelItem => item.FQuestionTypeId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 46 "C:\Users\User\Documents\ispanProject\資策\MSITTeam1\Views\QuestionBank\List.cshtml"
           Write(Html.DisplayFor(modelItem => item.FUpdateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 49 "C:\Users\User\Documents\ispanProject\資策\MSITTeam1\Views\QuestionBank\List.cshtml"
           Write(Html.DisplayFor(modelItem => item.FLevel));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 52 "C:\Users\User\Documents\ispanProject\資策\MSITTeam1\Views\QuestionBank\List.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { subjectID = item.FSubjectId, questionID = (int)item.FQuestionId }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n");
            WriteLiteral("                ");
#nullable restore
#line 54 "C:\Users\User\Documents\ispanProject\資策\MSITTeam1\Views\QuestionBank\List.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 57 "C:\Users\User\Documents\ispanProject\資策\MSITTeam1\Views\QuestionBank\List.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MSITTeam1.Models.TQuestionList>> Html { get; private set; }
    }
}
#pragma warning restore 1591
