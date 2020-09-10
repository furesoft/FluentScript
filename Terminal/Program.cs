using ComLib.Lang;
using ComLib.Lang.AST;
using ComLib.Lang.Plugins;
using System;

namespace Terminal
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			var i = new Interpreter();

			i.Settings.EnablePrinting = true;
			i.Settings.EnableFluentMode = true;
			i.Settings.EnableFunctionCallCallBacks = true;

			i.Context.Plugins.Init();

			i.Context.Plugins.RegisterAllCustom();
			i.Context.Plugins.RegisterAllSystem();

			i.Context.Plugins.Print();

			i.Context.Plugins.RegisterCustomByType(typeof(TransactionPlugin));
			i.Context.Plugins.RegisterCustomByType(typeof(ActorPlugin));
			i.Context.Plugins.RegisterCustomByType(typeof(OnPlugin));

			i.Context.ExternalFunctions.Register("_blast", Blast);

			i.Execute("function blast(arg) {_blast(arg)}");

			while (true)
			{
				Console.Write(">> ");
				var src = Console.ReadLine();

				i.AppendExecute(src);

				if (!i.Result.Success)
					Console.WriteLine(i.Result);
			}
		}

		private static object Blast(string arg1, string arg2, FunctionCallExpr arg3)
		{
			return null;
		}
	}
}