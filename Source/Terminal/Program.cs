using ComLib.Lang;
using ComLib.Lang.Templating;
using System;

namespace Terminal
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var i = new Interpreter();
            i.InitPlugins();
            i.Context.Plugins.RegisterAll();
            i.Settings.EnablePrinting = true;
            i.Settings.EnableFluentMode = true;
            i.Settings.EnableFunctionCallCallBacks = true;
            i.Context.Plugins.RegisterAllCustom();
            i.Context.Plugins.RegisterCustomByType(typeof(TransactionPlugin));
            i.Context.Plugins.RegisterCustomByType(typeof(ActorPlugin));
            i.Context.Plugins.RegisterCustomByType(typeof(OnPlugin));

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