#pragma checksum "C:\Users\Weyquos\source\repos\ProjetoWeb\ProjetoWeb\Views\Livro\Detalhes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1184189853a5033a8e7390bb9dfc98df1649c385"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Livro_Detalhes), @"mvc.1.0.view", @"/Views/Livro/Detalhes.cshtml")]
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
#line 1 "C:\Users\Weyquos\source\repos\ProjetoWeb\ProjetoWeb\Views\_ViewImports.cshtml"
using ProjetoWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Weyquos\source\repos\ProjetoWeb\ProjetoWeb\Views\_ViewImports.cshtml"
using ProjetoWeb.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1184189853a5033a8e7390bb9dfc98df1649c385", @"/Views/Livro/Detalhes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"310c8ba186128c0c96f2d299099d648de9691c8d", @"/Views/_ViewImports.cshtml")]
    public class Views_Livro_Detalhes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProjetoWeb.Models.Livro>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    <fieldset>\r\n        <legend>Detalhes</legend>\r\n        \r\n        <div>\r\n            <dl class=\"row\">\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 9 "C:\Users\Weyquos\source\repos\ProjetoWeb\ProjetoWeb\Views\Livro\Detalhes.cshtml"
               Write(Html.DisplayNameFor(model => model.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 12 "C:\Users\Weyquos\source\repos\ProjetoWeb\ProjetoWeb\Views\Livro\Detalhes.cshtml"
               Write(Html.DisplayFor(model => model.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 15 "C:\Users\Weyquos\source\repos\ProjetoWeb\ProjetoWeb\Views\Livro\Detalhes.cshtml"
               Write(Html.DisplayNameFor(model => model.Autor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 18 "C:\Users\Weyquos\source\repos\ProjetoWeb\ProjetoWeb\Views\Livro\Detalhes.cshtml"
               Write(Html.DisplayFor(model => model.Autor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 21 "C:\Users\Weyquos\source\repos\ProjetoWeb\ProjetoWeb\Views\Livro\Detalhes.cshtml"
               Write(Html.DisplayNameFor(model => model.Editora));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 24 "C:\Users\Weyquos\source\repos\ProjetoWeb\ProjetoWeb\Views\Livro\Detalhes.cshtml"
               Write(Html.DisplayFor(model => model.Editora));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    Número de Páginas\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 30 "C:\Users\Weyquos\source\repos\ProjetoWeb\ProjetoWeb\Views\Livro\Detalhes.cshtml"
               Write(Html.DisplayFor(model => model.NumPag));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    Ano de Publicação\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 36 "C:\Users\Weyquos\source\repos\ProjetoWeb\ProjetoWeb\Views\Livro\Detalhes.cshtml"
               Write(Html.DisplayFor(model => model.AnoPub));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n            </dl>\r\n        </div>\r\n\r\n    </fieldset>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProjetoWeb.Models.Livro> Html { get; private set; }
    }
}
#pragma warning restore 1591
