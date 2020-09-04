﻿using ComLib.Lang.Parsing;
using System;
using System.Collections.Generic;

namespace ComLib.Lang.Runtime.Bindings
{
    public class LanguageBinding
    {
        /// <summary>
        /// Context of the runtime.
        /// </summary>
        public Context Ctx { get; set; }

        /// <summary>
        /// Component name for this binding.
        /// </summary>
        public string ComponentName { get; set; }

        /// <summary>
        /// The namespace of the binding
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Whether or not this binding supports functions
        /// </summary>
        public bool SupportsFunctions { get; set; }

        /// <summary>
        /// The exported publically available functions.
        /// </summary>
        public List<string> ExportedFunctions { get; set; }

        /// <summary>
        /// Can optionally set a naming convention.
        /// </summary>
        public string NamingConvention { get; set; }

        /// <summary>
        /// Executes a function in this language binding.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public object ExecuteFunction(string name, object[] args)
        {
            // Naming convention ? default to camel case
            if (!string.IsNullOrEmpty(NamingConvention))
            {
                name = name[0].ToString().ToUpper() + name.Substring(1);
            }
            var method = GetType().GetMethod(name);
            if (method == null)
                throw new ArgumentException("Binding for " + ComponentName + " does not have function " + name);
            var result = method.Invoke(this, args);
            return result;
        }
    }
}