namespace FSRazor.WebPages

open System
open System.ComponentModel
open System.Web.WebPages

[<EditorBrowsable(EditorBrowsableState.Never)>]
type PreApplicationStartCode() =
    static let mutable startWasCalled = false

    static member Start() =
        if (not startWasCalled) then
            startWasCalled <- true

            FSRazor.PreApplicationStartCode.Start()

            WebPageHttpHandler.RegisterExtension("fshtml")
