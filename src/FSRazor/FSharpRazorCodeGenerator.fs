namespace FSRazor

open System.Web.Razor
open System.Web.Razor.Generator

type FSharpRazorCodeGenerator(className, rootNamespaceName, sourceFileName, host) =
    inherit RazorCodeGenerator(className, rootNamespaceName, sourceFileName, host)

    override x.CreateCodeWriter() =
        new FSharpCodeWriter() :> CodeWriter
