using ComLib.Lang.AST;
using ComLib.Lang.Core;
using ComLib.Lang.Helpers;
using ComLib.Lang.Parsing;
using ComLib.Lang.Types;
using System.Transactions;

namespace Terminal
{
	public class RollBackStatement : Expr
	{
		public RollBackStatement()
		{
			Nodetype = "rollback";
		}

		public override object Evaluate(IAstVisitor visitor)
		{
			Ctx.Memory.SetValue("completed", new LBool(false), true);

			return null;
		}
	}

	public class TransactionStatement : BlockExpr
	{
		public override object Evaluate(IAstVisitor visitor)
		{
			var scope = new TransactionScope();
			try
			{
				var result = ExecuteBlock(visitor);

				return result;
			}
			finally
			{
				scope.Dispose();
				System.Console.WriteLine("Transaction commited");
			}
		}
	}

	public class RollBackPlugin : ExprPlugin
	{
		public RollBackPlugin()
		{
			ConfigureAsSystemStatement(false, true, "rollback");
		}

		public override string Grammer => "rollback";

		public override Expr Parse()
		{
			var stmt = new RollBackStatement();
			// transaction {  }
			//_tokenIt.Expect(Transaction);
			var id = _tokenIt.ExpectIdText("rollback");

			return stmt;
		}
	}

	public class TransactionPlugin : ExprBlockPlugin
	{
		/// <summary>
		/// Intialize.
		/// </summary>
		public TransactionPlugin()
		{
			ConfigureAsSystemStatement(true, true, "transaction");
		}

		/// <summary>
		/// The grammer for the function declaration
		/// </summary>
		public override string Grammer
		{
			get { return "transaction <statementblock>"; }
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
					"transaction { // do some work }",
				};
			}
		}

		public static readonly Token Transaction = TokenBuilder.ToIdentifier("transaction");

		/// <summary>
		/// Parses either the for or for x in statements.
		/// </summary>
		/// <returns></returns>
		public override Expr Parse()
		{
			var stmt = new TransactionStatement();
			// transaction {  }
			//_tokenIt.Expect(Transaction);
			var id = _tokenIt.ExpectIdText("transaction");
			ParseBlock(stmt);
			return stmt;
		}
	}
}