namespace FSRazor

open System.Web.Razor
open System.Web.Razor.Generator

type FSharpCodeWriter() =
    inherit CodeWriter()

    override x.EmitStartConstructor(typeName) =
        raise <| new System.NotImplementedException()

    override x.EmitEndConstructor() =
        raise <| new System.NotImplementedException()

    override x.EmitStartLambdaDelegate(parameterNames) =
        raise <| new System.NotImplementedException()

    override x.EmitEndLambdaDelegate() =
        raise <| new System.NotImplementedException()

    override x.EmitStartLambdaExpression(parameterNames) =
        raise <| new System.NotImplementedException()

    override x.EmitEndLambdaExpression() =
        raise <| new System.NotImplementedException()

    override x.EmitStartMethodInvoke(methodName) =
        raise <| new System.NotImplementedException()

    override x.EmitEndMethodInvoke() =
        raise <| new System.NotImplementedException()

    override x.WriteHelperHeaderPrefix(templateTypeName, isStatic) =
        raise <| new System.NotImplementedException()

    override x.WriteLinePragma(lineNumber, fileName) =
        raise <| new System.NotImplementedException()

    override x.WriteParameterSeparator() =
        raise <| new System.NotImplementedException()

    override x.WriteReturn() =
        raise <| new System.NotImplementedException()

    override x.WriteSnippet(snippet) =
        raise <| new System.NotImplementedException()

    override x.WriteStringLiteral(literal) =
        raise <| new System.NotImplementedException()
