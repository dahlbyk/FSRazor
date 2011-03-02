namespace FSRazor.WebPages

open System
open System.ComponentModel
open System.Reflection
open System.Web.WebPages

[<EditorBrowsable(EditorBrowsableState.Never)>]
type PreApplicationStartCode() =
    static let mutable startWasCalled = false

    static member Start() =
        if (not startWasCalled) then
            startWasCalled <- true

            FSRazor.PreApplicationStartCode.Start()

            WebPageHttpHandler.RegisterExtension("fshtml")

            let pascType = typeof<System.Web.WebPages.Deployment.PreApplicationStartCode>
            let lwp = pascType.GetMethod("LoadWebPages", BindingFlags.NonPublic ||| BindingFlags.Static)
            lwp.Invoke(null, null) |> ignore
