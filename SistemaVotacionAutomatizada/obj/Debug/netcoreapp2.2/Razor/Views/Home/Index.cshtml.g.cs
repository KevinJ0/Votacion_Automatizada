#pragma checksum "C:\Users\KevinJ\source\repos\SistemaVotacionAutomatizada\SistemaVotacionAutomatizada\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aef503f1a0bd904bc07da82f2fa9c1feb0b942bb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Users\KevinJ\source\repos\SistemaVotacionAutomatizada\SistemaVotacionAutomatizada\Views\_ViewImports.cshtml"
using SistemaVotacionAutomatizada;

#line default
#line hidden
#line 2 "C:\Users\KevinJ\source\repos\SistemaVotacionAutomatizada\SistemaVotacionAutomatizada\Views\_ViewImports.cshtml"
using SistemaVotacionAutomatizada.Models;

#line default
#line hidden
#line 3 "C:\Users\KevinJ\source\repos\SistemaVotacionAutomatizada\SistemaVotacionAutomatizada\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aef503f1a0bd904bc07da82f2fa9c1feb0b942bb", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d28c04f9bea0a2813a83b4abfc03208d15afa1e7", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/StyleSheet.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 74, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aef503f1a0bd904bc07da82f2fa9c1feb0b942bb4254", async() => {
                BeginContext(6, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(12, 53, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "aef503f1a0bd904bc07da82f2fa9c1feb0b942bb4636", async() => {
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
                EndContext();
                BeginContext(65, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(74, 528, true);
            WriteLiteral(@"

<div class=""card-deck"">
    <div class=""card"" style=""width:18rem;text-align:center;"">
        <img src=""https://thumbor.forbes.com/thumbor/960x0/https%3A%2F%2Fspecials-images.forbesimg.com%2Fdam%2Fimageserve%2F1063184564%2F960x0.jpg%3Ffit%3Dscale""
             class=""card-img-top"" alt=""Vote Image"" />
        <div class=""card-body"">
            <h5 class=""card-title"">Menú Ciudadanos</h5>
            <p class=""card-text"">Ejerzca su derecho al voto</p>
        </div>
        <div class=""card-body"">
            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 602, "\"", 646, 1);
#line 14 "C:\Users\KevinJ\source\repos\SistemaVotacionAutomatizada\SistemaVotacionAutomatizada\Views\Home\Index.cshtml"
WriteAttributeValue("", 609, Url.Action("ValidadorCedula","Home"), 609, 37, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(647, 6605, true);
            WriteLiteral(@" class=""btn btn-primary btn-lg"">Votar</a>
        </div>
    </div>

    <div class=""card"" style=""width:18rem;text-align:center;"">
        <img src=""data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAOEAAADhCAMAAAAJbSJIAAAAkFBMVEX///+23P5HiMc4gcTK2eyjzPNEhsa74P8xfsO63/8/g8RBhcb1+Ps2gMSZuNw3gcSy2fxim9N9r+CPvem0y+Ws1PlRj8uJuOZpoNbl7fajwOCfyvJil85alc+KueasxuN8ptTb5vPR3++/0+lupNl+qNWJr9js8vng6vWfvd9/sOFpm9CPs9pyp9vD1uvB5v/Pl2VMAAARDElEQVR4nO1d6Xbqug4ucXESGwNlCJShUKAjtPv93+4mkp04IUAGB8O51Y+91m5p8BfJmixLDw9/9Ed/9Ef/Gfr43Gw2j5vN63PH9lJM0+f2a710PE+IHiFECOHxxXr1antZZqiz+doTQRh3qKMRpZwJsV992F5fTeps1z3BUtBSRIlYP9peZA3a7j3CT6KTxEXwa3uh1agzc4jOPBoJJmdInOq/Eos73JGdriac0Z5jwXI6eBkO5/P2fD4cDqZLymL+Uu/d9oJLUueLsEQMmTOdzPst1/WBWvCv67bak2XITPwQCz5tL7oMbXmMj5PlpO2H2Fo55Lvjb4cpNm5tL7swdfZCMoayYDJ2c8HFIP1hIDF6M9srL0i/antRMp2fhycxTqSoel+2116IDh6V/NtdYF+Csf+EbBR3wMXOkkh8T223EDwgd4B/5t289X/mXNq+YQl8EcQhcJGKG3fiPntS9e9axeTzCCLf28Zwll57FO17SQYixBcQVDGyjeIMfaKTRoNxWQYixB8OG/h2I8cP1If8qbSESvIDkPC30ejx2TaYXAoobsEKEioRzgl6QWGIzJbdjW1AWdqz");
            WriteLiteral(@"mgBDOZ0mAQdlgh5uipVf+P6nNQC2Wu3EXQeQ3vp23PFXD9a0rLgFFROXTpq4ONhGpggXFNQD2PKHXrgJCYtjqlDs2W3sxwOa63ZNhK3WuB9Sez6ZOip+pt7KNrqQXgW87iqGPpei+Hj+Q2WMIm4g/l9G75s+mQKI5PZVVEXebAPcAgtp3yhAwCijKmKbi+iLvNTehDkYJ7gdLQeO254JPXoC4hwhelbTjcjCeSMIQ1eOY8BpEeCjAFtvVs3oEMFbYhZN/5o3yMIW7EWQU2tO6odobhdKiGCM+NoWwlX0hnkTijSmsV0mwgtmDeKLon9qcSc+g56pFzRdpD6DYMoOwhUBj9SEkPZPpj+QicTOwcYOtIAJh82dOvNTogChsSVd0zPlc/tD5pBdP5+NmKQSNgBC3MQnBoR0TM/kyv3v6LfCRjAMtoK16wNEoxedd+TuRhBTZsP/fgOHpj4L3W+VhKJOXqbAtbYRIUla3yd1hyRJP7EcheM+UTvudwcS8T91eSiPZVRuhk2OIPoDsBfXz/g/G1E0ioPeSKZmyBFE/yX6jbh+lPhIDMQVag9624fOnuRz0Z9HnyHXLy3akvqq1N9JgJA1PHjIxazVAO+bXP/obcbqpqDccYCSKWSZwkogxIxg9Lkdc4GZ4DoAX1QdRpz3XeEBAU+fQvYhvOheHeE7j05EK29Dt71ECaVC86pHKKhB+rNR7Sa7flYRDH5Q0Ry64500D5ynlGQX86+pkMyPLC+/fmp4XR2hO/5RRxNkn7Fzb3gWqcdkbmDHqamK0HfbOx4fvRzrjwWmEDUVhgjvg4d+VK8XqNJTShY5p6AfwF5dTv1oH3I7+5AWRxiC88fDnyApLGUs/+zsF0+zNJPh2EnVXNClUEYqyW+N28PvacC0qm/mdU95miAdmk+P1sKOPaT59jBkV3/+Mtg9BaFtA2L62W4kn+Rw2pPuwItIlI0tn+brhE8TbrXhLoBybpq+hKCIC746GylAiitmovRLr1/YNwK/dJzF1xo+EZ4L");
            WriteLiteral(@"DLnHBHu7uFh4M2on+kOILa5fmvGbE1v4rYlz8oYFpYx4zqEIL+DtKXVqLT6ERFQ6W+oOndRuo5TKTUiI8Jx997dodh4uLDDcAlBMZCPGh2MZ+q0jnMb8C9klCA8Wu/X67f3QnY1+N6WqR7+0ExE3klm6aArHaepE75kmlV5+P4gtubfobl/rFMQ+Rx64ysUSO+bw4QGKmBKTP5aKk4rFqP6e2Sf59LklY5HNJvqSg4Zu+WAyNtJj/sRSmiaTEXZ3mNXtGXrXn/Euxyd7Zh5bjiAVxVGZ+rIa3TF2lEnURoRzCxuKJlQ1oA0wYepLHWrOaO3BRLjSZ7N0RJokvSULTfodXekU4qMtnR+CqgHPFE/AiEn3fySTlT6ckFq6izGK/bY27JrA5MNVwhkCfFtFQ6jvBr484jNrspRTCNvQQoCPxOVGxApmYdQ3xmORF9fmNlQlUeFGhMyK2Us9oKn55B9aQ1tXokayGKOJU1qJEN3updFHlyAML3ZSkswG4RIhvjxr1y9fwWY57ksDQbhEOAFncGnp7sUGDxlYG3xjz2wQjgiHSxmvWKmi/ZCXmukAXnQTCOlARdRmFXVBWqtbzcFLYwhVUO0wCzX7WFwKEKdNIdSykb3rM3GrFYk4TSF0YpgWzvEP7EoIKWQTLVgMiCyWP7RxhARSXBZcUzxdm7PGES7/WTohladrjfMw9NwsnXLDPqStAW0YIRv3LZV6yyA8vt3aEEL65LYtJUw3WNcW325tCCEburYSph3M9/2b8GYRYvWlY6MbASTeSb/FmkQYxmZ9eJU2mmbgjRkZhTeFkM3db25nG4aOKfjGji91TTMIAx9qvgwngYrSjiMTsRC9Gc/7+x+w0NJ9iw0WvvTRr2kEIRvj1S47EfDDwwLvcYNX1Ux8OEUBsdacB/tFsEljETAfflu+YomFhPSpMSl9wrYw9q7JdrTSkuYiYMfmVeeNdwWEdq+rz+JsjeEDsCQN5FlukHVQKxFmtcFz/Fzrzfi6spWgYZOFPVNuo4HL");
            WriteLiteral(@"loFGNXxu8YvNBpybaMLTgXD/RMVvVcJalpNVttemBsol3uGZRh9ZhwLztXVYU2b0kXUIcqc9o4+EHInt7jsJwaYxqkxBlZIb0KOSsHDC5Hpmxt9ZTWKmUylRYEa5wQfWJUjxG8w0gM9mr2lLDkF62GC2aGW1iiaPsCrDXFEIdoq4FXMPBMlTY2HO5uaEVJ4IGzsfwm19Y4MhqMHqrE/MxBp5ljnCGxJmmAgsvCFzj4RZByOFUZiHtdKR5izhiakJ9zuwVJlwiTqmuo7P4KyJ35SpQMJbg726yubZM/SmGiCQrtpyauYpzRAmj0i9WB/T6IYTd8bogFuxjjuJzT+M3mswSlhK6FXPj/3CJuS3KaMRYRqX9qr6p2gJKbnhWR5bPLkl1bj46NWVgSvQDCF6Vbxm2brF9jnFJTr0qp42YOOWuOHQ7dI7VtaKkk64aoQlrt9LqDS9Iy9YUEbfbCi/Ew5G9CUPN73Ctr/zJg+wbn0PKhrJQjDmFDP+K6b+4JZyT2epq4bi9YLLTFlR1ZLHQj+vqtRNqtwJnZ2z359dlky7vE+E0ciY/Sgf5Mdq4emNQu4OYS/ukkGEc8iC/Dg4CTwcC3lvCMXnUtCEkzRtPF55wj3u7SGlfG8IvdDR3HvaRFU9eTbzkt0ndiF47z4Rhqx6F/FYYBLIliCdUaCuFHHSO0B+7m4RRnDWPQmSEi9Yr9eBJ9UnF+xNueh3jDCkzuM6rnDiPJbb1NDq+0b4EPXtzI6w5ulaoLtH+PC8FzpGLvbpZNP9IwzDh7VHor50lDPirbOBx38BYbgff7vrxXKx7v4eJ7TvBuHHZvW1XgTl2wLhgdpi/TUq1xXsmtR5nK17niBqPHx5hDCInQivt55tbu7Y4nW2IIKl9GUFhLEeYoIsZjdUTfPapeK4mWCp0owRyf45ZcLp3gTIj1lwBE/W1BZPRr0J7e90kMHZ6PIa9Lr2svAIDeRS2bLY8j5U42snoCTzNHZsWK5JG92MU9kVMmqBKUf70UKFw48SFU7w");
            WriteLiteral(@"gLdDtQ6ToXNgKwm+WcTxHw3jv+kL3P8gUUtT91sOec5p9pwlGUhR8h21DRvjxc3JE01kg3pWMH7uE3zM2c1914VWqtix0p2jyXB6uwvP2fXkO4LhHTjqgQ9d15/vEpA06+Q1T52Dkk9KydOw5Uaw+nGjvHCpaiwAC86t7TmQA6/lRG+8EkugRZob9bON8xxXHp7721P5Qk4HY1e2h8Rbz1T1ipzKzXjmmOZXhvpsqjpMwn/jFsLueBA3fWXseq2EO2u5sFA8Jy2ttfhA7//bcieSAyfPIuRhDI0Hk2BX5KhDWtzXth837qVifSWAj8p34c7Q13vQZtfntqXZOOqeD6QOY6jTVm9JvaOW/lR/4sgvZPQqGucQM/A7O5/Jh98EWl/aJa6N02Oj9ioPY/gymdYFHfYcmn1saxCzsfnwo7OQL548jY9azuOEdL0Ftv8jP3505jKSL4ro44bgTmzOOD53LC3sCXEwSK9SQinNmyGGrbdTA4TUtKPseGZ5BpeeBq1sRd5cq6E0P5w22vhrK5Tuy58DhzxITZuLN6PuwyV+Wjv12SMZ0NCrGciOaFCnzmSMw19OzERI2wu5tFYgLQv5grCv8/ilzFyQ2clUtxVHD5czkBs8ZfwSeS8+hSZtL+QP4zY9Ydi37+7DQFL9P++Duq3IQGxLSW3qyp60XidG3OlrzMwqi/ufgAbWgocMt/JsRfoDSjcXcHcrkOQg+zk3tcPnaXuBPxxqp20aZSd85tuK9KOkoyQa4KK88cu+z44lydcV/4JchMG/9MdO2YrUFwxYQ3txK0eGHc+2S79jLb6IfxY6JblEv9MuEfztpdGt8ag2wxpVdYHMn6R5lg9uO8gX0iju0HXWOVuhQ8RR1oa7RT6jA0JOWQnt+0Gr8Pj/fuvnFD7A+KOprbO2QvsK5CJlJlM4WFaZM37xiLLxxTB/EksiqfGA1Uu2QoOIe9FkkeYaj9kHBWYfpdYZuZMqujtmn4TIpIN70VZoEKE1jkOM3TEdgRrlxeZTw2BU");
            WriteLiteral(@"sBe+O6EK37J9xDw1Wi70cSdRDI22ghf6El92/TF0cegT61oLzsmL9UWiYSII7iB9gMgHrvYCIo1TxFYkhKaz9s0AJKyep5d0nHq9Q5lLGmhi6Ms5jRrCfpTLSYR4UMxWxN/SNrgVu9jdoPDEUex7tAySRACwxf3RVQ5FzyiavSM/FoASvmgrFMmorGfAt0EZ5UW0jPxudGAUc2JzMNaVjUKSGBP8fPH5wnJmiAE5hT1Nl8WHVfqDhFm6SZdLQjjJBJ6UQ1DEVsSEmulSPvYibbGhV9446VMI42CJhtG+9nftBIk+gzZ06uIcfiFbkf6e2jPJQd2VkNGWii8SQ6d+PEx0TTpRkZjNs3FFlqRQ1GwtgfPjyo2MRXtxlMnBdLbk7lPmd5iFKWwrkProStaKMrKD+goRMIvsspmcfkrTZIbu+f0dKf9FE3z/dRDitJeyA9THjAVHQ9J1Ic3Lp7nzgBW2FepvcPpLDYvRORqYWfCLB/7Rn+hCeiymrUjjDMoObsXkAaXVEc5KOVIJ5aUa+2nfOyumsODSM7AxVqvRfAHMMKk3XVytPpOrKbnlTj0VI5nKzRy2JF+eqlBaSM09NqhlE/c5yc+q1D+qTawzlj0mFI2qfQDwznHV0dt5KzEvprKyoWJLQ32QZF3KCqk5McUppdWsfnBK51Wgfk4Ww8yTx9VbRcPV7AqmIo/S5l5uRDNiKsdpVQmiQEgN7ZZjITUmpjjjspKYYvhlYhE5mtScNsXIukq7ng+jQpqXFTYlH8CKCv3wttoQztqLyBFSc2IKk/sqGH1szVjS2T9BOZrUnDZFz63C2DdszWiEhXma1KA2hToqWjpfI+eoNuKTGhZTeHz5EAobiplxaHI1qTltism90l3NU/OMa67gxCG32RCqdJffd8ixG/j+00JqTEzHlVQNJILNxBX9ozr8mIgZMYWTkrIRVGY2fJ3vP6FJYSMaEVNwTcsG+jgnp0yO/fT3nxRSU2IKqeGyyvRZDjqt//X+SU0KTMyvjyuJ8LvC");
            WriteLiteral(@"NKENTm9vG6DJWYQTE1+Bflu5AApbolNmgM4BjK44GSDYBiU7Gh7fQ7p56pXzve8QYckpl/eIsFzme+WRe6OStXzPj/dHN9qJ8I/+6I/+H+h/uTUzkcG9tHEAAAAASUVORK5CYII=""
             class=""card-img-top"" alt=""Admin Image"" />
        <div class=""card-body"">
            <h5 class=""card-title"">Menú Administrador</h5>
            <p class=""card-text"">Configurar los Candidatos, Partidos, Puestos Electivos, Ciudadanos y Elecciones</p>
            <div class=""card-body"">
                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 7252, "\"", 7289, 1);
#line 25 "C:\Users\KevinJ\source\repos\SistemaVotacionAutomatizada\SistemaVotacionAutomatizada\Views\Home\Index.cshtml"
WriteAttributeValue("", 7259, Url.Action("Login","Account"), 7259, 30, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(7290, 101, true);
            WriteLiteral(" class=\"btn btn-primary btn-lg\">Acceder</a>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
