namespace FSRazor.Mvc

open System
open System.ComponentModel
open System.Web.Mvc

[<EditorBrowsable(EditorBrowsableState.Never)>]
type PreApplicationStartCode() =
    static let mutable startWasCalled = false

    static member Start() =
        if (not startWasCalled) then
            startWasCalled <- true

            FSRazor.PreApplicationStartCode.Start()

            ViewEngines.Engines.Add(new FSRazorViewEngine());
