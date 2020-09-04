using System;

namespace ComLib.Lang.Types
{
    /// <summary>
    /// Used to represent a version number e.g. 0.9.8.7
    /// </summary>
    public class LVersion : LObject
    {
        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="v"></param>
        public LVersion(Version v)
        {
            Major = v.Major;
            Minor = v.Minor;
            Build = v.Build;
            Revision = v.Revision;
        }

        /// <summary>
        /// The First unit of the version.
        /// </summary>
        public int Major { get; set; }

        /// <summary>
        /// The second unit of the version.
        /// </summary>
        public int Minor { get; set; }

        /// <summary>
        /// The third unit of the version.
        /// </summary>
        public int Build { get; set; }

        /// <summary>
        /// The fourth unit of the version.
        /// </summary>
        public int Revision { get; set; }

        /// <summary>
        /// text based representation of the version.
        /// </summary>
        /// <returns></returns>
        public string Text
        {
            get
            {
                var text = Major + "." + Minor + "." + Build;
                if (Revision < 0)
                    return text;

                return text + "." + Revision.ToString();
            }
        }

        /// <summary>
        /// Get the text based version.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Text;
        }
    }
}