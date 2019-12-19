#region Using directives
using System;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
#endregion

namespace treeDiM.Basics
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct OptInt : ICloneable
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="OptInt"/> struct
        /// </summary>
        public OptInt(bool activated, int val)
        {
            Activated = activated;
            Value = val;
        }
        public OptInt(OptInt optValue)
        {
            Activated = optValue.Activated;
            Value = optValue.Value;
        }
        #endregion
        #region Public properties
        public bool Activated { get; set; }
        public int Value { get; set; }
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
        #region Constants
        public static readonly OptInt Zero = new OptInt(false, 0);
        #endregion
        #region System.Object overrides
        /// <summary>
        /// Returns the hashcode for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return Activated.GetHashCode() ^ Value.GetHashCode();
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
                return (Activated == optValue.Activated) && (Value == optValue.Value);
            }
            return false;
        }
        public override string ToString() => $"{(Activated ? 1 : 0)}, {Value}";
        public static implicit operator OptInt(int value) => new OptInt(true, value);
        public static bool operator ==(OptInt left, OptInt right) => left.Equals(right);
        public static bool operator !=(OptInt left, OptInt right) => !(left == right);
        #endregion
        #region Static operators
        public static OptInt Min(OptInt opt1, OptInt opt2)
        {
            if (opt1.Activated && !opt2.Activated) return opt1;
            else if (!opt1.Activated && opt2.Activated) return opt2;
            else if (opt1.Activated && opt2.Activated) return new OptInt(true, Math.Min(opt1.Value, opt2.Value));
            else return Zero;
        }
        public static OptInt Max(OptInt opt1, OptInt opt2)
        {
            if (opt1.Activated && !opt2.Activated) return opt1;
            else if (!opt1.Activated && opt2.Activated) return opt2;
            else if (opt1.Activated && opt2.Activated) return new OptInt(true, Math.Max(opt1.Value, opt2.Value));
            else return Zero;
        }
        #endregion
    }
}
