#pragma checksum "C:\Users\User\Desktop\EcommerceMvc-master_2\EcommerceMvc-master\Project\Ecommerce_MVC_Core\Ecommerce_MVC_Core\Views\Shared\_ModalFooter.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "836399fad9966fd323f1264ed2a97cb4f4d664ef"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ModalFooter), @"mvc.1.0.view", @"/Views/Shared/_ModalFooter.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_ModalFooter.cshtml", typeof(AspNetCore.Views_Shared__ModalFooter))]
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
#line 1 "C:\Users\User\Desktop\EcommerceMvc-master_2\EcommerceMvc-master\Project\Ecommerce_MVC_Core\Ecommerce_MVC_Core\Views\_ViewImports.cshtml"
using Ecommerce_MVC_Core;

#line default
#line hidden
#line 2 "C:\Users\User\Desktop\EcommerceMvc-master_2\EcommerceMvc-master\Project\Ecommerce_MVC_Core\Ecommerce_MVC_Core\Views\_ViewImports.cshtml"
using Ecommerce_MVC_Core.Models;

#line default
#line hidden
#line 4 "C:\Users\User\Desktop\EcommerceMvc-master_2\EcommerceMvc-master\Project\Ecommerce_MVC_Core\Ecommerce_MVC_Core\Views\_ViewImports.cshtml"
using System.Collections;

#line default
#line hidden
#line 5 "C:\Users\User\Desktop\EcommerceMvc-master_2\EcommerceMvc-master\Project\Ecommerce_MVC_Core\Ecommerce_MVC_Core\Views\_ViewImports.cshtml"
using Ecommerce_MVC_Core.BootstrapModal;

#line default
#line hidden
#line 6 "C:\Users\User\Desktop\EcommerceMvc-master_2\EcommerceMvc-master\Project\Ecommerce_MVC_Core\Ecommerce_MVC_Core\Views\_ViewImports.cshtml"
using Ecommerce_MVC_Core.Code;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"836399fad9966fd323f1264ed2a97cb4f4d664ef", @"/Views/Shared/_ModalFooter.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71cfa9c3ae2f1e0493d4ca25e3a3394ef37b5862", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ModalFooter : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Ecommerce_MVC_Core.BootstrapModal.ModalFooter>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(53, 61, true);
            WriteLiteral("\n\n<div class=\"modal-footer\">\n    <button data-dismiss=\"modal\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 114, "\"", 140, 1);
#line 5 "C:\Users\User\Desktop\EcommerceMvc-master_2\EcommerceMvc-master\Project\Ecommerce_MVC_Core\Ecommerce_MVC_Core\Views\Shared\_ModalFooter.cshtml"
WriteAttributeValue("", 119, Model.CancelButtonID, 119, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(141, 39, true);
            WriteLiteral(" class=\"btn btn-default\" type=\"button\">");
            EndContext();
            BeginContext(181, 22, false);
#line 5 "C:\Users\User\Desktop\EcommerceMvc-master_2\EcommerceMvc-master\Project\Ecommerce_MVC_Core\Ecommerce_MVC_Core\Views\Shared\_ModalFooter.cshtml"
                                                                                             Write(Model.CancelButtonText);

#line default
#line hidden
            EndContext();
            BeginContext(203, 10, true);
            WriteLiteral("</button>\n");
            EndContext();
#line 6 "C:\Users\User\Desktop\EcommerceMvc-master_2\EcommerceMvc-master\Project\Ecommerce_MVC_Core\Ecommerce_MVC_Core\Views\Shared\_ModalFooter.cshtml"
     if (!Model.OnlyCancelButton)
    {

#line default
#line hidden
            BeginContext(253, 42, true);
            WriteLiteral("        <button class=\"btn btn-success al\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 295, "\"", 321, 1);
#line 8 "C:\Users\User\Desktop\EcommerceMvc-master_2\EcommerceMvc-master\Project\Ecommerce_MVC_Core\Ecommerce_MVC_Core\Views\Shared\_ModalFooter.cshtml"
WriteAttributeValue("", 300, Model.SubmitButtonID, 300, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(322, 28, true);
            WriteLiteral(" type=\"submit\">\n            ");
            EndContext();
            BeginContext(351, 22, false);
#line 9 "C:\Users\User\Desktop\EcommerceMvc-master_2\EcommerceMvc-master\Project\Ecommerce_MVC_Core\Ecommerce_MVC_Core\Views\Shared\_ModalFooter.cshtml"
       Write(Model.SubmitButtonText);

#line default
#line hidden
            EndContext();
            BeginContext(373, 19, true);
            WriteLiteral("\n        </button>\n");
            EndContext();
#line 11 "C:\Users\User\Desktop\EcommerceMvc-master_2\EcommerceMvc-master\Project\Ecommerce_MVC_Core\Ecommerce_MVC_Core\Views\Shared\_ModalFooter.cshtml"
    }

#line default
#line hidden
            BeginContext(398, 179, true);
            WriteLiteral("</div> \n<script>\n    $(\".al\").on(\"click\", function() {\n        $(\".alert\").removeClass(\"in\").show();\n        $(\".alert\").delay(600).addClass(\"in\").fadeOut(5000);\n    });\n</script>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Ecommerce_MVC_Core.BootstrapModal.ModalFooter> Html { get; private set; }
    }
}
#pragma warning restore 1591
