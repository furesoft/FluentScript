using ComLib.Lang.AST;

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