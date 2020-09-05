using System.Collections.Generic;

namespace ComLib.Lang.Parsing.MetaPlugins
{
    // Used to represent a token match for the grammer check in a plugin.
    public class TokenGroup : TokenMatch
    {
        public List<TokenMatch> Matches;

        public TokenGroup()
        {
            Matches = new List<TokenMatch>();
            IsGroup = true;
        }

        /// <summary>
        /// Gets the total number of required plugins.
        /// </summary>
        /// <returns></returns>
        public override int TotalRequired()
        {
            if (!IsRequired)
                return 0;

            if (Matches == null || Matches.Count == 0)
                return 0;

            var totalReq = 0;
            for (var ndx = 0; ndx < Matches.Count; ndx++)
            {
                var match = Matches[ndx];
                totalReq += match.TotalRequired();
            }
            return totalReq;
        }
    }
}