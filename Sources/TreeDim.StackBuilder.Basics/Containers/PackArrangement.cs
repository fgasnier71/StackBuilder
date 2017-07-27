using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace treeDiM.StackBuilder.Basics
{
    public class PackArrangement
    {
        public PackArrangement(int iLength, int iWidth, int iHeight)
        {
            Length = iLength;
            Width = iWidth;
            Height = iHeight;
        }

        public int Number => Length * Width * Height;
        public int Length { get; }
        public int Width { get; }
        public int Height { get; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Length, Width, Height);
        }

        public static PackArrangement TryParse(string value)
        { 
    		Match m = ParseRegex.Match(value);
		    if (m.Success)
                return new PackArrangement(int.Parse(m.Result("${i1}")), int.Parse(m.Result("${i2}")), int.Parse(m.Result("${i3}"))) ;
		    else
			    throw new ArgumentException("Failed parsing int[3] from " + value );
        }

        #region Non-Public Members

        static readonly Regex ParseRegex = new Regex("(?<i1>.*) (?<i2>.*) (?<i3>.*)", RegexOptions.Singleline | RegexOptions.Compiled);

        #endregion
    }
}