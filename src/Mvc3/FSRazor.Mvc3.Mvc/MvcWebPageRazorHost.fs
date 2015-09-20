namespace FSRazor.Mvc

open FSRazor
open System.Web.Razor.Generator
open System.Web.Razor.Parser

type MvcWebPageRazorHost(virtualPath, physicalPath) =
    inherit System.Web.Mvc.Razor.MvcWebPageRazorHost(virtualPath, physicalPath)

    override x.DecorateCodeGenerator(incomingCodeGenerator) =
        match incomingCodeGenerator with
        | g when (g :? FSharpRazorCodeGenerator)
            -> new MvcFSharpRazorCodeGenerator(g.ClassName, g.RootNamespaceName, g.SourceFileName, g.Host) :> RazorCodeGenerator
        | _ -> base.DecorateCodeGenerator(incomingCodeGenerator)

    override x.DecorateCodeParser(incomingCodeParser) =
        match incomingCodeParser with
        | p when (p :? FSharpCodeParser)
            -> new MvcFSharpCodeParser() :> ParserBase
        | _ -> base.DecorateCodeParser(incomingCodeParser)
