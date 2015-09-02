namespace FSRazor

open FSRazor
open System
open System.Web.Compilation
open System.ComponentModel
open System.Web.WebPages.Razor

[<EditorBrowsable(EditorBrowsableState.Never)>]
type PreApplicationStartCode() =
    static let mutable startWasCalled = false

    static member Start() =
        if (not startWasCalled) then
            startWasCalled <- true

            BuildProvider.RegisterBuildProvider(".fshtml", typeof<RazorBuildProvider>)
            FSharpRazorCodeLanguage.Install();
