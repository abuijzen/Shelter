#pragma checksum "/Users/ElkeBorreij/Documents/GitHub/Shelter/Shelter.Mvc/Views/Shelter/Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f2c14d49fa7e03209fcc806e33c9dbae141de979"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shelter_Detail), @"mvc.1.0.view", @"/Views/Shelter/Detail.cshtml")]
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
#line 1 "/Users/ElkeBorreij/Documents/GitHub/Shelter/Shelter.Mvc/Views/_ViewImports.cshtml"
using Shelter.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/ElkeBorreij/Documents/GitHub/Shelter/Shelter.Mvc/Views/_ViewImports.cshtml"
using Shelter.Mvc.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f2c14d49fa7e03209fcc806e33c9dbae141de979", @"/Views/Shelter/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"805d196ca77ee675306ec8624a7c66a7c11b945d", @"/Views/_ViewImports.cshtml")]
    public class Views_Shelter_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Shelter.Shared.Animal>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/Users/ElkeBorreij/Documents/GitHub/Shelter/Shelter.Mvc/Views/Shelter/Detail.cshtml"
  
      ViewData["Title"] = Model.Name;

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div>\n\t<p>Name: ");
#nullable restore
#line 8 "/Users/ElkeBorreij/Documents/GitHub/Shelter/Shelter.Mvc/Views/Shelter/Detail.cshtml"
        Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n\t<p>Type: ");
#nullable restore
#line 9 "/Users/ElkeBorreij/Documents/GitHub/Shelter/Shelter.Mvc/Views/Shelter/Detail.cshtml"
        Write(Model.Race);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Shelter.Shared.Animal> Html { get; private set; }
    }
}
#pragma warning restore 1591
