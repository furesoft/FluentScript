using ComLib.Lang;
using ComLib.Lang.Core;
using ComLib.Lang.Plugins;
using System;

namespace Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            var i = new Interpreter();
            i.InitPlugins();
            i.Context.Plugins.RegisterAll();
            i.Settings.EnablePrinting = true;
            i.Settings.EnableFluentMode = true;
            i.Settings.EnableFunctionCallCallBacks = true;

            while (true)
            {
                var src = Console.ReadLine();

                i.AppendExecute(src);

                if (!i.Result.Success)
                    Console.WriteLine(i.Result);
            }

        }
    }
}