﻿using ComLib.Lang.AST;

// <lang:using>
using ComLib.Lang.Core;
using ComLib.Lang.Parsing;
using ComLib.Lang.Types;
using System;
using System.Linq;

// </lang:using>

namespace ComLib.Lang.Plugins
{
    /* *************************************************************************
    <doc:example>
    // Range plugin is used to represent a range e.g. 1..10
    </doc:example>
    ***************************************************************************/

    /// <summary>
    /// Combinator for handling comparisons.
    /// </summary>
    public class RangePlugin : ExprPlugin
    {
        /// <summary>
        /// Initialize
        /// </summary>
        public RangePlugin()
        {
            StartTokens = new string[] { "$NumberToken" };
        }

        /// <summary>
        /// Whether or not this parser can handle the supplied token.
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        public override bool CanHandle(Token current)
        {
            var n = _tokenIt.Peek(1).Token;
            if (n != Tokens.Dot) return false;
            n = _tokenIt.Peek(2).Token;
            if (n != Tokens.Dot) return false;

            return true;
        }

        /// <summary>
        /// The grammer for the function declaration
        /// </summary>
        public override string Grammer
        {
            get { return "<number>...<number>"; }
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
                    "1...10"
                };
            }
        }

        /// <summary>
        /// run step 123.
        /// </summary>
        /// <returns></returns>
        public override Expr Parse()
        {
            // 1. min
            var min = Convert.ToInt32(_tokenIt.NextToken.Token.Value);

            // 2. "." "." "."
            _tokenIt.Advance(3);

            // 3. max
            var max = Convert.ToInt32(_tokenIt.ExpectNumber());

            return new ConstantExpr(new LRange(min, max));
        }
    }

    public class LRange : LObject
    {
        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="val"></param>
        public LRange(int min, int max)
        {
            Min = min;
            Max = max;
            Type = new LRangeType();
        }

        /// <summary>
        /// Min
        /// </summary>
        public int Min { get; set; }

        /// <summary>
        /// Max
        /// </summary>
        public int Max { get; set; }

        /// <summary>
        /// Gets the value of this object.
        /// </summary>
        /// <returns></returns>
        public override object GetValue()
        {
            return new LArray(Enumerable.Range(Min, Max).ToList()).Value;
        }

        /// <summary>
        /// Clones this value.
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            return new LRange(Min, Max);
        }
    }

    public class LRangeType : LObjectType
    {
        /// <summary>
        /// Initialize.
        /// </summary>
        public LRangeType()
        {
            Name = "range";
            FullName = "sys.range";
            TypeVal = 40;
        }
    }
}