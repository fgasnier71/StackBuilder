#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace treeDiM.EdgeCrushTest
{
    public class ECTException : System.Exception
    {
        /// <summary>
        /// Expected exception types
        /// </summary>
        public enum ErrorType
        {
            ERROR_INVALIDCARDBOARD
            , ERROR_INVALIDCASETYPE
            , ERROR_INVALIDFORMULATYPE
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public ECTException()
            :base()
        {
        }
        /// <summary>
        /// Constructor with message
        /// </summary>
        public ECTException(string message)
            : base(message)
        { 
        }
        /// <summary>
        /// Constructor with message + inner exception
        /// </summary>
        public ECTException(string message, Exception innerException)
            : base(message, innerException)
        { 
        }
        /// <summary>
        /// Customized exception
        /// </summary>
        public ECTException(ECTException.ErrorType error, string arg)
            : base(ECTException.ExceptionMessage(error, arg))
        { 
        }

        public static string ExceptionMessage(ErrorType error, string arg)
        {
            switch (error)
            {
                case ErrorType.ERROR_INVALIDCARDBOARD:
                    return string.Format(Properties.Resources.EXCEPTION_INVALIDCARDBOARDID, arg);
                case ErrorType.ERROR_INVALIDCASETYPE:
                    return string.Format(Properties.Resources.EXCEPTION_INVALIDCASETYPE, arg);
                case ErrorType.ERROR_INVALIDFORMULATYPE:
                    return Properties.Resources.EXCEPTION_INVALIDFORMULA;
                default:
                    return string.Empty;
            }
        }
    }
}
