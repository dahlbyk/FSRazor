namespace FSRazor

open System.Web.Razor
open System.Web.Razor.Generator

type FSharpCodeWriter() =
    inherit CodeWriter()

    member private x.Write (s : string) =
        base.InnerWriter.Write(s)

    member private x.WriteLine () =
        base.InnerWriter.WriteLine()

    override x.EmitStartConstructor(typeName) =
        x.Write "new "
        x.Write typeName
        x.Write "("

    override x.EmitEndConstructor() =
        x.Write ")"

    override x.EmitStartLambdaDelegate(parameterNames) =
        x.EmitStartLambdaExpression parameterNames
        x.WriteLine()

    override x.EmitEndLambdaDelegate() =
        x.WriteLine()

    override x.EmitStartLambdaExpression(parameterNames) =
        x.Write "(fun "
        match parameterNames.Length with
        | 0 -> x.Write "() "
        | _ -> parameterNames |> Array.iter (fun n -> x.Write n; x.Write " ")
        x.Write "-> "

    override x.EmitEndLambdaExpression() =
        x.Write ")"

    override x.EmitStartMethodInvoke(methodName) =
        x.Write "this."
        x.Write methodName
        x.Write "("

    override x.EmitEndMethodInvoke() =
        x.Write ")"

    override x.WriteHelperHeaderPrefix(templateTypeName, isStatic) =
        raise <| new System.NotImplementedException()

    override x.WriteLinePragma(lineNumber, fileName) =
        if lineNumber.HasValue then
            x.WriteLine()
            x.Write "# "
            x.Write (lineNumber.Value.ToString())
            x.Write " \""
            x.Write fileName
            x.Write "\""

    override x.WriteParameterSeparator() =
        x.Write ", "

    override x.WriteReturn() =
        x.WriteLine()

    override x.WriteSnippet(snippet) =
        x.Write snippet

    override x.WriteStringLiteral(literal) =
        x.Write "@\""
        x.Write <| literal.Replace("\"", "\"\"")
        x.Write "\""
