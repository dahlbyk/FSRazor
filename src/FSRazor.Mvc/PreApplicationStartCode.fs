namespace FSRazor.Mvc

open FSRazor
open System
open System.Web.Compilation
open System.Web.Mvc
open System.Web.WebPages.Razor

type PreApplicationStartCode() =
    static let mutable startWasCalled = false

    static member Start() =
        if (not startWasCalled) then
            startWasCalled <- true

            BuildProvider.RegisterBuildProvider(".fshtml", typeof<RazorBuildProvider>)
            FSharpRazorCodeLanguage.Install();
            ViewEngines.Engines.Add(new FSRazorViewEngine());
