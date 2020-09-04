namespace ComLib.Lang.Parsing.MetaPlugins
{
    // Used to represent a token match for the grammer check in a plugin.
    public class TokenGroupOr : TokenMatch
    {
        public TokenMatch Left;
        public TokenMatch Right;

        public TokenGroupOr(TokenMatch left, TokenMatch right)
        {
            Left = left;
            Right = right;
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

            if (Left == null && Right == null)
                return 0;

            var totalReq = Left.TotalRequired() + Right.TotalRequired();
            return totalReq;
        }
    }
}