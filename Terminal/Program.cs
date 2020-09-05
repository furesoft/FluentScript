using ComLib.Lang;
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
			i.Context.Plugins.RegisterAll();
			i.Context.Plugins.RegisterCustomByType(typeof(TransactionPlugin));
			i.Context.Plugins.RegisterCustomByType(typeof(ActorPlugin));
			i.Context.Plugins.RegisterCustomByType(typeof(OnPlugin));
			//i.Context.Plugins.RegisterCustomByType(typeof(RangePlugin));

			//ToDo: implement auto collector for Plugins

			while (true)
			{
				Console.Write(">> ");
				var src = Console.ReadLine();

				i.AppendExecute(src);

				if (!i.Result.Success)
					Console.WriteLine(i.Result);
			}
		}
	}
}