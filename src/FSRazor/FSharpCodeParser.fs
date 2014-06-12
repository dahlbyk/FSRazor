namespace FSRazor

open System
open System.Web.Razor.Parser
open System.Web.Razor.Parser.SyntaxTree

type FSharpCodeParser() =
    inherit CodeParser()

    override x.AcceptGenericArgument() =
        ()

    override x.HandleTransition(s) =
        false

    override x.TryAcceptStringOrComment() =
        false

    override x.ParseBlock() =
        let isStatementBlock, complete =
            match x.CurrentCharacter with
            | '{' -> x.StartBlock(BlockType.Statement) |> ignore
                     true, false // x.ParseCodeBlock(new CodeBlockInfo("code", x.CurrentLocation, true), true)
            | '(' -> x.StartBlock(BlockType.Expression) |> ignore
                     false, x.ParseDelimitedBlock(')', new CodeBlockInfo("explicit expression", x.CurrentLocation, true), true, true, null)
            | _   -> if (Char.IsWhiteSpace(x.CurrentCharacter)) then
                         x.OnError(x.CurrentLocation, "Unexpected whitespace after the '@'.")
                     else if x.EndOfFile then
                         x.OnError(x.CurrentLocation, "End-of-file was found after the '@'.")
                     else
                         x.OnError(x.CurrentLocation, "'{0}' is not valid at the start of a code block.", x.CurrentCharacter)
                     x.StartBlock(BlockType.Expression) |> ignore
                     x.End(ImplicitExpressionSpan.Create(context = x.Context,
                                                         keywords = null,
                                                         acceptTrailingDot = false,
                                                         acceptedCharacters = AcceptedCharacters.NonWhiteSpace))
                     false, true

        if isStatementBlock && not x.Context.WhiteSpaceIsImportantToAncestorBlock then
            use b = x.Context.StartTemporaryBuffer()
            x.Context.AcceptWhiteSpace(includeNewLines = false) |> ignore
            if Char.IsWhiteSpace(x.CurrentCharacter) then
                x.Context.AcceptLine(includeNewLineSequence = true) |> ignore
                x.Context.AcceptTemporaryBuffer()

        // End a span if we have any content left and don't have an unterminated block left hanging
        let haveGrowableSpan = x.Context.PreviousSpanCanGrow || complete
        if (not haveGrowableSpan) || x.HaveContent then
            let acceptedCharacters = if complete then AcceptedCharacters.None else AcceptedCharacters.Any
            x.End(CodeSpan.Create(context = x.Context, hidden = false, acceptedCharacters = acceptedCharacters))

        x.EndBlock()

    member private x.ParseDelimitedBlock(terminator, block, allowTransition, useErrorRecovery, autoCompleteString : string) =
        x.Context.AcceptWhiteSpace(includeNewLines = true) |> ignore

        let bracket = x.Context.AcceptCurrent()
        x.End(MetaCodeSpan.Create(x.Context))

        let complete = x.BalanceBrackets(bracket = new Nullable<char>(bracket),
                                         appendOuter = false,
                                         allowTransition = allowTransition,
                                         useTemporaryBuffer = useErrorRecovery,
                                         spanFactory = null)
        match complete with
        | true  -> x.End(CodeSpan.Create(x.Context))
                   x.Context.AcceptCurrent() |> ignore
                   x.End(MetaCodeSpan.Create(x.Context))
        | false -> if useErrorRecovery then
                       () // TryRecover(RecoveryModes.Markup | RecoveryModes.Transition)
                   x.End(CodeSpan.Create(context = x.Context, autoCompleteString = autoCompleteString))
                   x.OnError(block.Start, "The {0} block is missing a closing '{1}' character.", bracket, terminator)

        complete
