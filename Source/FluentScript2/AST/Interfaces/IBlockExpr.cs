using System.Collections.Generic;

namespace ComLib.Lang.AST
{
    public interface IBlockExpr : IExpr
    {
        List<Expr> Statements { get; set; }
    }
}