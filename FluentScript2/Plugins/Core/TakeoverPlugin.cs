﻿// <lang:using>
using ComLib.Lang.Core;
using ComLib.Lang.Parsing;

// </lang:using>

namespace ComLib.Lang.Plugins
{
    /// <summary>
    /// Combinator for handling comparisons.
    /// </summary>
    public class TakeoverPlugin : LexPlugin
    {
        /// <summary>
        /// Initialize
        /// </summary>
        public TakeoverPlugin()
        {
            _canHandleToken = true;
        }

        /// <summary>
        /// run step 123.
        /// </summary>
        /// <returns></returns>
        public override Token[] Parse()
        {
            // print no quotes needed!
            var takeoverToken = _lexer.LastTokenData;
            var line = _lexer.State.Line;
            var pos = _lexer.State.LineCharPosition;
            var lineToken = _lexer.ReadLine(false);
            var t = new TokenData() { Token = lineToken, Line = line, LineCharPos = pos };
            _lexer.ParsedTokens.Add(takeoverToken);
            _lexer.ParsedTokens.Add(t);
            return new Token[] { takeoverToken.Token, lineToken };
        }
    }
}