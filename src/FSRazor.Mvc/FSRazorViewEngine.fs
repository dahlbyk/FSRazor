namespace FSRazor

open Microsoft.FSharp.Collections
open System.Web.Mvc

type FSRazorViewEngine() =
    inherit RazorViewEngine()

    let extensions = [| "fshtml"; "cshtml"; "vbhtml" |]
    let appendExtensions p = extensions |> Array.map (fun e -> p + e)
    let areaLocationFormats = [| "~/Areas/{2}/Views/{1}/{0}."; "~/Areas/{2}/Views/Shared/{0}." |]
    let locationFormats = [| "~/Views/{1}/{0}."; "~/Views/Shared/{0}." |]

    do
        base.FileExtensions <- extensions
        base.AreaViewLocationFormats <- Array.collect appendExtensions areaLocationFormats
        base.AreaMasterLocationFormats <- Array.collect appendExtensions areaLocationFormats
        base.AreaPartialViewLocationFormats <- Array.collect appendExtensions areaLocationFormats
        base.ViewLocationFormats <- Array.collect appendExtensions locationFormats
        base.MasterLocationFormats <- Array.collect appendExtensions locationFormats
        base.PartialViewLocationFormats <- Array.collect appendExtensions locationFormats
