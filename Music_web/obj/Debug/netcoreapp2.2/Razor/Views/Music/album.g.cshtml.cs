#pragma checksum "F:\web\Music_web\Music_web\Views\Music\album.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "df93602d253e6331296e40a15b8fbfda009d6673"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Music_album), @"mvc.1.0.view", @"/Views/Music/album.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Music/album.cshtml", typeof(AspNetCore.Views_Music_album))]
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
#line 1 "F:\web\Music_web\Music_web\Views\_ViewImports.cshtml"
using Music_web;

#line default
#line hidden
#line 2 "F:\web\Music_web\Music_web\Views\_ViewImports.cshtml"
using Music_web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df93602d253e6331296e40a15b8fbfda009d6673", @"/Views/Music/album.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1356eb2545d98ffd3f923159667c1041b67ed5e", @"/Views/_ViewImports.cshtml")]
    public class Views_Music_album : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "F:\web\Music_web\Music_web\Views\Music\album.cshtml"
  
    ViewData["Title"] = "album";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var album = ViewBag.album as IList<Music_web.Music_API.Album_info>;
    var i = 2;

#line default
#line hidden
            BeginContext(179, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "df93602d253e6331296e40a15b8fbfda009d66733506", async() => {
                BeginContext(185, 25, true);
                WriteLiteral("\r\n    <title>歌单</title>\r\n");
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
            BeginContext(217, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(219, 1556, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "df93602d253e6331296e40a15b8fbfda009d66734714", async() => {
                BeginContext(225, 92, true);
                WriteLiteral("\r\n    <div style=\"height:300px;width:300px; margin-top:50px;float:left;margin-left:10%\"><img");
                EndContext();
                BeginWriteAttribute("src", " src=", 317, "", 335, 1);
#line 12 "F:\web\Music_web\Music_web\Views\Music\album.cshtml"
WriteAttributeValue("", 322, album[0].img, 322, 13, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(335, 163, true);
                WriteLiteral(" ; height=\"100%\" width=\"100% \" /></div>\r\n    <div style=\"height:300px;width:500px;float:left;margin-left:15px;margin-top:4%;\">\r\n        <h1 style=\"font-family:楷体\">");
                EndContext();
                BeginContext(499, 13, false);
#line 14 "F:\web\Music_web\Music_web\Views\Music\album.cshtml"
                              Write(album[0].name);

#line default
#line hidden
                EndContext();
                BeginContext(512, 47, true);
                WriteLiteral("</h1><br />\r\n        <p style=\"font-family:楷体\">");
                EndContext();
                BeginContext(560, 19, false);
#line 15 "F:\web\Music_web\Music_web\Views\Music\album.cshtml"
                             Write(album[0].music_name);

#line default
#line hidden
                EndContext();
                BeginContext(579, 73, true);
                WriteLiteral("<p>\r\n        <p style=\"font-family:楷体;max-height:150px;overflow:hidden\" >");
                EndContext();
                BeginContext(653, 12, false);
#line 16 "F:\web\Music_web\Music_web\Views\Music\album.cshtml"
                                                               Write(album[0].dec);

#line default
#line hidden
                EndContext();
                BeginContext(665, 179, true);
                WriteLiteral("</p>\r\n    </div>\r\n    <table class=\"table\" style=\"width: 90%;margin-left:5%\">\r\n        <thead style=\"size: 10ch\">\r\n        <th>歌曲名</th>\r\n        <th>歌手</th>\r\n        <th>专辑</th>\r\n");
                EndContext();
                BeginContext(871, 57, true);
                WriteLiteral("        </thead>\r\n        <tbody style=\"opacity:0.5\">\r\n\r\n");
                EndContext();
#line 27 "F:\web\Music_web\Music_web\Views\Music\album.cshtml"
             foreach (var song in album)
            {
                

#line default
#line hidden
#line 29 "F:\web\Music_web\Music_web\Views\Music\album.cshtml"
                 if (i % 2 == 0)
                {

#line default
#line hidden
                BeginContext(1038, 90, true);
                WriteLiteral("                    <tr style=\"background-color:#f0fcff;\">\r\n                        <td><a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 1128, "\"", 1156, 2);
                WriteAttributeValue("", 1135, "writejson?id=", 1135, 13, true);
#line 32 "F:\web\Music_web\Music_web\Views\Music\album.cshtml"
WriteAttributeValue("", 1148, song.id, 1148, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1157, 1, true);
                WriteLiteral(">");
                EndContext();
                BeginContext(1159, 15, false);
#line 32 "F:\web\Music_web\Music_web\Views\Music\album.cshtml"
                                                       Write(song.music_name);

#line default
#line hidden
                EndContext();
                BeginContext(1174, 39, true);
                WriteLiteral("</a></td>\r\n                        <td>");
                EndContext();
                BeginContext(1214, 11, false);
#line 33 "F:\web\Music_web\Music_web\Views\Music\album.cshtml"
                       Write(song.singer);

#line default
#line hidden
                EndContext();
                BeginContext(1225, 35, true);
                WriteLiteral("</td>\r\n                        <td>");
                EndContext();
                BeginContext(1261, 9, false);
#line 34 "F:\web\Music_web\Music_web\Views\Music\album.cshtml"
                       Write(song.name);

#line default
#line hidden
                EndContext();
                BeginContext(1270, 7, true);
                WriteLiteral("</td>\r\n");
                EndContext();
                BeginContext(1319, 27, true);
                WriteLiteral("                    </tr>\r\n");
                EndContext();
#line 37 "F:\web\Music_web\Music_web\Views\Music\album.cshtml"
                }
                else
                {

#line default
#line hidden
                BeginContext(1406, 56, true);
                WriteLiteral("                    <tr>\r\n                        <td><a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 1462, "\"", 1490, 2);
                WriteAttributeValue("", 1469, "writejson?id=", 1469, 13, true);
#line 41 "F:\web\Music_web\Music_web\Views\Music\album.cshtml"
WriteAttributeValue("", 1482, song.id, 1482, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1491, 1, true);
                WriteLiteral(">");
                EndContext();
                BeginContext(1493, 15, false);
#line 41 "F:\web\Music_web\Music_web\Views\Music\album.cshtml"
                                                       Write(song.music_name);

#line default
#line hidden
                EndContext();
                BeginContext(1508, 39, true);
                WriteLiteral("</a></td>\r\n                        <td>");
                EndContext();
                BeginContext(1548, 11, false);
#line 42 "F:\web\Music_web\Music_web\Views\Music\album.cshtml"
                       Write(song.singer);

#line default
#line hidden
                EndContext();
                BeginContext(1559, 35, true);
                WriteLiteral("</td>\r\n                        <td>");
                EndContext();
                BeginContext(1595, 9, false);
#line 43 "F:\web\Music_web\Music_web\Views\Music\album.cshtml"
                       Write(song.name);

#line default
#line hidden
                EndContext();
                BeginContext(1604, 7, true);
                WriteLiteral("</td>\r\n");
                EndContext();
                BeginContext(1653, 27, true);
                WriteLiteral("                    </tr>\r\n");
                EndContext();
#line 46 "F:\web\Music_web\Music_web\Views\Music\album.cshtml"
                }

#line default
#line hidden
#line 46 "F:\web\Music_web\Music_web\Views\Music\album.cshtml"
                 
                i++;
            }

#line default
#line hidden
                BeginContext(1736, 32, true);
                WriteLiteral("        </tbody>\r\n    </table>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1775, 2, true);
            WriteLiteral("\r\n");
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
