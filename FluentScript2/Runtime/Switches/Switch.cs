using System;
using System.Collections.Generic;

namespace ComLib.Lang.Runtime.Switches
{
    public class Switch
    {
        /// <summary>
        /// Initialize.
        /// </summary>
        public Switch()
        {
            OutputResult = true;
        }

        /// <summary>
        /// Whether or not to show the output of the interpreter results.
        /// </summary>
        public bool OutputResult { get; set; }

        /// <summary>
        /// The arguments supplied as name/value pairs.
        /// </summary>
        public Dictionary<string, object> ArgsMap { get; set; }

        /// <summary>
        /// The arguments supplied as a list
        /// </summary>
        public List<string> ArgsList { get; set; }

        /// <summary>
        /// Prints tokens to file supplied, if file is not supplied, prints to console.
        /// </summary>
        public object Execute(Interpreter i)
        {
            DoExecute(i);
            var runResult = i.Result;

            if (OutputResult)
            {
                WriteScriptStatus(runResult.Success, runResult.Message);
            }
            return runResult;
        }

        /// <summary>
        /// Execute code specific to this switch option.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public virtual object DoExecute(Interpreter i)
        {
            return null;
        }

        /// <summary>
        /// Writes out a line indicating success/failure in different colors.
        /// </summary>
        /// <param name="success"></param>
        public static void WriteScriptStatus(bool success, string message)
        {
            var color = success ? ConsoleColor.Green : ConsoleColor.Red;
            var text = success ? "SUCCESS" : "FAILURE(S)";
            Console.WriteLine();
            WriteText(color, text);
            if (!success)
            {
                WriteText(ConsoleColor.Red, "Failed with error: " + message);
            }
        }

        /// <summary>
        /// Writes out a line indicating success/failure in different colors.
        /// </summary>
        /// <param name="success"></param>
        public static void WriteText(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}