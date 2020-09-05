// <lang:using>
using ComLib.Lang.AST;
using ComLib.Lang.Core;

// </lang:using>

namespace ComLib.Lang.Parsing
{
	/// <summary>
	/// A combinator to extend the parser
	/// </summary>
	public class ExprBlockPlugin : ExprPlugin
	{
		/// <summary>
		/// Parses a block by first pushing symbol scope and then popping after completion.
		/// </summary>
		public virtual void ParseBlock(IBlockExpr stmt)
		{
			Ctx.Symbols.Push(new SymbolsNested(string.Empty), true);
			stmt.SymScope = Ctx.Symbols.Current;
			_parser.ParseBlock(stmt);
			Ctx.Symbols.Pop();
		}

		/// <summary>
		/// Parses a conditional block by first pushing symbol scope and then popping after completion.
		/// </summary>
		/// <param name="stmt"></param>
		public virtual void ParseConditionalBlock(ConditionalBlockExpr stmt)
		{
			Ctx.Symbols.Push(new SymbolsNested(string.Empty), true);
			stmt.SymScope = Ctx.Symbols.Current;
			_parser.ParseConditionalStatement(stmt);
			Ctx.Symbols.Pop();
		}
	}
}