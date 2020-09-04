﻿namespace ComLib.Lang.Runtime.Switches
{
    public class DirectiveSwitch : Switch
    {
        private string _directives;

        public DirectiveSwitch(string directives)
        {
            _directives = directives;
            OutputResult = false;
        }

        /// <summary>
        /// Prints tokens to file supplied, if file is not supplied, prints to console.
        /// </summary>
        public override object DoExecute(Interpreter i)
        {
            i.Context.Directives.RegisterDelimited(_directives);
            return null;
        }
    }
}