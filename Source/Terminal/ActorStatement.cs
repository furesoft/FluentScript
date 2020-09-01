using ComLib.Lang.AST;
using ComLib.Lang.Core;
using ComLib.Lang.Helpers;
using ComLib.Lang.Parsing;
using ComLib.Lang.Plugins;
using ComLib.Lang.Types;
using System.Transactions;

namespace Terminal
{

    public class ActorStatement : BlockExpr
    {
        public ActorStatement()
        {
            this.Nodetype = "actor";
        }

        public string ID { get; internal set; }

        public override object DoEvaluate(IAstVisitor visitor)
        {
            return base.DoEvaluate(visitor);
        }
    }
}