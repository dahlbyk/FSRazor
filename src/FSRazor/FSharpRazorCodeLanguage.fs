namespace FSRazor

open System.Web.Razor
open System.Web.Razor.Generator
open System.Web.Razor.Parser

type FSharpRazorCodeLanguage() =
    inherit RazorCodeLanguage()

    static do
        RazorCodeLanguage.Languages.Add("fshtml", new FSharpRazorCodeLanguage())

    override x.LanguageName
        with get() = "fsharp"

    override x.CodeDomProviderType
        with get() = typeof<Microsoft.FSharp.Compiler.CodeDom.FSharpCodeProvider>

    override x.CreateCodeParser() =
        new FSharpCodeParser() :> ParserBase

    override x.CreateCodeGenerator(className, rootNamespaceName, sourceFileName, host) =
        new FSharpRazorCodeGenerator(className, rootNamespaceName, sourceFileName, host) :> RazorCodeGenerator
