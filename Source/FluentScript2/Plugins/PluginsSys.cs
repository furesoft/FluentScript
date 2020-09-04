// ------------------------------------------------------------------------------------------------
// summary: This file contains individual parsers as plugins for parsing system level
//			features like control-flow e..g if, while, for, try, break, continue, return etc.
// version: 0.9.8.10
// author:  kishore reddy
// date:	Wednesday, December 19, 2012
// ------------------------------------------------------------------------------------------------
using ComLib.Lang.AST;
using ComLib.Lang.Core;

namespace ComLib.Lang.Parsing
{
    // Plugin: 15 - NewExpr
    public class NewPlugin : ExprPlugin
    {
        public NewPlugin()
        {
            ConfigureAsSystemStatement(false, false, "new");
            Precedence = 1;
        }

        public override Expr Parse()
        {
            return ExpParser.OnParseNew();
        }

        public override void OnParseComplete(AstNode node)
        {
            var expr = node as Expr;
            ExpParser.OnParseNewComplete(expr);
        }
    }

    // Plugin: 18 - BreakExpr
    public class BreakPlugin : ExprPlugin
    {
        public BreakPlugin()
        {
            ConfigureAsSystemStatement(false, true, "break");
            Precedence = 1;
        }

        public override Expr Parse()
        {
            return ExpParser.OnParseBreak();
        }

        public override void OnParseComplete(AstNode node)
        {
            var expr = node as Expr;
            ExpParser.OnParseBreakComplete(expr);
        }
    }

    // Plugin: 19 - ContinueExpr
    public class ContinuePlugin : ExprPlugin
    {
        public ContinuePlugin()
        {
            ConfigureAsSystemStatement(false, true, "continue");
            Precedence = 1;
        }

        public override Expr Parse()
        {
            return ExpParser.OnParseContinue();
        }

        public override void OnParseComplete(AstNode node)
        {
            var expr = node as Expr;
            ExpParser.OnParseContinueComplete(expr);
        }
    }

    // Plugin: 20 - ForEachExpr
    public class ForEachPlugin : ExprPlugin
    {
        public ForEachPlugin()
        {
            ConfigureAsSystemStatement(true, false, "for");
            Precedence = 1;
        }

        public override Expr Parse()
        {
            return ExpParser.OnParseForEach();
        }

        public override void OnParseComplete(AstNode node)
        {
            var expr = node as Expr;
            ExpParser.OnParseForEachComplete(expr);
        }
    }

    // Plugin: 21 - ForExpr
    public class ForPlugin : ExprPlugin
    {
        public ForPlugin()
        {
            ConfigureAsSystemStatement(true, false, "for");
            Precedence = 2;
        }

        public override Expr Parse()
        {
            return ExpParser.OnParseFor();
        }

        public override void OnParseComplete(AstNode node)
        {
            var expr = node as Expr;
            ExpParser.OnParseForComplete(expr);
        }
    }

    // Plugin: 22 - FunctionDeclareExpr
    public class FunctionDeclarePlugin : ExprPlugin, IParserCallbacks
    {
        public FunctionDeclarePlugin()
        {
            ConfigureAsSystemStatement(true, false, "function");
            Precedence = 1;
        }

        public override Expr Parse()
        {
            return ExpParser.OnParseFunctionDeclare();
        }

        public override void OnParseComplete(AstNode node)
        {
            var expr = node as Expr;
            ExpParser.OnParseFunctionDeclareComplete(expr);
        }
    }

    // Plugin: 23 - IfExpr
    public class IfPlugin : ExprPlugin
    {
        public IfPlugin()
        {
            ConfigureAsSystemStatement(true, false, "if");
            Precedence = 1;
        }

        public override Expr Parse()
        {
            return ExpParser.OnParseIf();
        }

        public override void OnParseComplete(AstNode node)
        {
            var expr = node as Expr;
            ExpParser.OnParseIfComplete(expr);
        }
    }

    // Plugin: 24 - LambdaExpr
    public class LambdaPlugin : ExprPlugin, IParserCallbacks
    {
        public LambdaPlugin()
        {
            ConfigureAsSystemStatement(true, false, "function");
            Precedence = 1;
        }

        public override Expr Parse()
        {
            return ExpParser.OnParseLambda();
        }

        public override void OnParseComplete(AstNode node)
        {
            var expr = node as Expr;
            ExpParser.OnParseLambdaComplete(expr);
        }
    }

    // Plugin: 25 - ReturnExpr
    public class ReturnPlugin : ExprPlugin
    {
        public ReturnPlugin()
        {
            ConfigureAsSystemStatement(false, true, "return");
            Precedence = 1;
        }

        public override Expr Parse()
        {
            return ExpParser.OnParseReturn();
        }

        public override void OnParseComplete(AstNode node)
        {
            var expr = node as Expr;
            ExpParser.OnParseReturnComplete(expr);
        }
    }

    // Plugin: 26 - ThrowExpr
    public class ThrowPlugin : ExprPlugin
    {
        public ThrowPlugin()
        {
            ConfigureAsSystemStatement(false, true, "throw");
            Precedence = 1;
        }

        public override Expr Parse()
        {
            return ExpParser.OnParseThrow();
        }

        public override void OnParseComplete(AstNode node)
        {
            var expr = node as Expr;
            ExpParser.OnParseThrowComplete(expr);
        }
    }

    // Plugin: 27 - TryCatchExpr
    public class TryCatchPlugin : ExprPlugin
    {
        public TryCatchPlugin()
        {
            ConfigureAsSystemStatement(true, false, "try");
            Precedence = 1;
        }

        public override Expr Parse()
        {
            return ExpParser.OnParseTryCatch();
        }

        public override void OnParseComplete(AstNode node)
        {
            var expr = node as Expr;
            ExpParser.OnParseTryCatchComplete(expr);
        }
    }

    // Plugin: 28 - WhileExpr
    public class WhilePlugin : ExprPlugin
    {
        public WhilePlugin()
        {
            ConfigureAsSystemStatement(true, false, "while");
            Precedence = 1;
        }

        public override Expr Parse()
        {
            return ExpParser.OnParseWhile();
        }

        public override void OnParseComplete(AstNode node)
        {
            var expr = node as Expr;
            ExpParser.OnParseWhileComplete(expr);
        }
    }
}