using ComLib.Lang.AST;
using ComLib.Lang.Core;
using System.Collections.Generic;

namespace Terminal
{
    public class ActorStatement : BlockExpr
    {
        public ActorStatement()
        {
            this.Nodetype = "actor";
        }

        public string ID { get; internal set; }
        public Dictionary<string, List<Expr>> Events { get; set; } = new Dictionary<string, List<Expr>>();

        public override object DoEvaluate(IAstVisitor visitor)
        {
            //do something with actor
            return base.DoEvaluate(visitor);
        }
    }

    public class OnEventStatement : BlockExpr
    {
        public OnEventStatement()
        {
            this.Nodetype = "on";
        }

        public string EventName { get; set; }

        public override object DoEvaluate(IAstVisitor visitor)
        {
            if (Parent is ActorStatement p)
            {
                p.Events.Add(EventName, Statements);
                return base.DoEvaluate(visitor);
            }

            throw new LangException("Semantic Error", "on statement must be used in a actor statement", "", 0);
        }
    }
}