#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
#endregion

namespace treeDiM.Basics
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct OptInt : ICloneable
    {
        #region Private fields
        private bool _activated;
        private int _val;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="OptInt"/> struct
        /// </summary>
        public OptInt(bool activated, int val)
        {
            _activated = activated;
            _val = val;
        }
        public OptInt(OptInt optValue)
        {
            _activated = optValue._activated;
            _val = optValue._val;
        }
        #endregion

        #region Constants
        public static readonly OptInt Zero = new OptInt(false, 0);
        #endregion

        #region Public properties
        public bool Activated
        {
            get { return _activated; }
            set { _activated = value; }
        }
        public int Value
        {
            get { return _val; }
            set { _val = value; }
        }
        #endregion

        #region ICloneable members
        object ICloneable.Clone()
        {
            return new OptInt(this);
        }
        public OptInt Clone()
        {
            return new OptInt(this);
        }
        #endregion

        #region Public Static Parse Methods
        /// <summary>
        /// Converts the specified string to its <see cref="OptInt"/> equivalent.
        /// A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="value">A string representation of a <see cref="OptDouble"/>.</param>
        /// <returns>A <see cref="OptInt"/> that represents the OptValue specified by the <paramref name="value"/> parameters.</returns>
        public static OptInt Parse(string value)
        {
            Regex r = new Regex(@"(?<o>.*),(?<v>.*)", RegexOptions.Singleline);
            Match m = r.Match(value);
            if (m.Success)
            {
                string so = m.Result("${o}");
                string sv = m.Result("${v}");
                return new OptInt(
                    int.Parse(so) == 1,
                    int.Parse(sv)
                    );
            }
            else
                throw new ApplicationException("Unsuccessful Match.");
        }
        /// <summary>
        /// Converts the specified string to its <see cref="OptInt"/> equivalent.
        /// </summary>
        /// <param name="value">A string representation of a <see cref="OptInt"/>.</param>
        /// <param name="result">When this method returns, if the conversion succeeded,
        /// contains a <see cref="OptInt"/> reprensention the OptValue specified by <paramref name="value"/>.
        /// </param>
        /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
        public static bool TryParse(string value, out OptInt result)
        {
            Regex r = new Regex(@"(?<o>),(?<v>)", RegexOptions.Singleline);
            Match m = r.Match(value);
            if (m.Success)
            {
                result = new OptInt(
                    int.Parse(m.Result("${o}")) == 1,
                    int.Parse(m.Result("${v}"))
                    );
                return true;
            }
            result = OptInt.Zero;
            return false;
        }
        #endregion

        #region System.Object overrides
        /// <summary>
        /// Returns the hashcode for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return _activated.GetHashCode() ^ _val.GetHashCode();
        }
        /// <summary>
        /// Returns a string representation of this object.
        /// </summary>
        /// <returns>A string representation of this object.</returns>
        public override bool Equals(object obj)
        {
            if (obj is OptDouble)
            {
                OptInt optValue = (OptInt)obj;
                return (_activated == optValue._activated) && (_val == optValue._val);
            }
            return false;
        }
        public override string ToString()
        {
            return string.Format("{0}, {1}", _activated ? 1 : 0, _val.ToString());
        }
        #endregion
    }
}
