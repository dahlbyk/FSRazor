namespace FSRazor

open System.Web.Razor.Parser

type FSharpCodeParser() =
    inherit CodeParser()

    override x.AcceptGenericArgument() =
        raise <| new System.NotImplementedException()

    override x.HandleTransition(s) =
        raise <| new System.NotImplementedException()

    override x.TryAcceptStringOrComment() =
        raise <| new System.NotImplementedException()

    override x.ParseBlock() =
        raise <| new System.NotImplementedException()
