using ComLib.Lang.AST;
using ComLib.Lang.Parsing;

namespace Terminal
{
    public class OnPlugin : ExprBlockPlugin
    {
        public OnPlugin()
        {
            this.ConfigureAsSystemStatement(true, false, "on");
        }

        public override string Grammer
        {
            get { return "on <string> <statementblock>"; }
        }

        /// <summary>
        /// Examples
        /// </summary>
        public override string[] Examples
        {
            get
            {
                return new string[]
                {
                    "on 'myevent' { // do some work }",
                };
            }
        }

        /// <summary>
        /// Parses either the for or for x in statements.
        /// </summary>
        /// <returns></returns>
        public override Expr Parse()
        {
            var stmt = new OnEventStatement();

            _tokenIt.ExpectIdText("on");
            var id = _tokenIt.ExpectId(true, true);
            stmt.EventName = id;
            ParseBlock(stmt);
            return stmt;
        }
    }

    public class ActorPlugin : ExprBlockPlugin
    {
        public ActorPlugin()
        {
            this.ConfigureAsSystemStatement(true, false, "actor");
        }

        /// <summary>
        /// The grammer for the function declaration
        /// </summary>
        public override string Grammer
        {
            get { return "actor <identifier> <statementblock>"; }
        }

        /// <summary>
        /// Examples
        /// </summary>
        public override string[] Examples
        {
            get
            {
                return new string[]
                {
                    "actor hello { // do some work }",
                };
            }
        }

        /// <summary>
        /// Parses either the for or for x in statements.
        /// </summary>
        /// <returns></returns>
        public override Expr Parse()
        {
            var stmt = new ActorStatement();
            // transaction {  }
            _tokenIt.ExpectIdText("actor");
            var id = _tokenIt.ExpectId();
            stmt.ID = id;
            ParseBlock(stmt);
            return stmt;
        }
    }
}