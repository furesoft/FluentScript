// <lang:using>
using ComLib.Lang.Core;

// </lang:using>

namespace ComLib.Lang.AST
{
    /// <summary>
    /// Condition expression less, less than equal, more, more than equal etc.
    /// </summary>
    public class ConditionExpr : Expr
    {
        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="left">Left hand expression</param>
        /// <param name="op">Operator</param>
        /// <param name="right">Right expression</param>
        public ConditionExpr(Expr left, Operator op, Expr right)
        {
            Nodetype = NodeTypes.SysCondition;
            Left = left;
            Right = right;
            AddChild(left);
            AddChild(right);
            Op = op;
        }

        /// <summary>
        /// Left hand expression
        /// </summary>
        public Expr Left;

        /// <summary>
        /// Operator > >= == != less less than
        /// </summary>
        public Operator Op;

        /// <summary>
        /// Right hand expression
        /// </summary>
        public Expr Right;

        /// <summary>
        /// Execute the statement.
        /// </summary>
        public override object Visit(IAstVisitor visitor)
        {
            return visitor.VisitCondition(this);
        }
    }
}