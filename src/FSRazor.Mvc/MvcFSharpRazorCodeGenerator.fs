namespace FSRazor.Mvc

open FSRazor

type MvcFSharpRazorCodeGenerator(className, rootNamespaceName, sourceFileName, host) =
    inherit FSharpRazorCodeGenerator(className, rootNamespaceName, sourceFileName, host)
