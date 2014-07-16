using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace KingSurvival
{
    using System;
    public static class Validator
    {
        public static void CheckValueIsNull(object value, string propertyName,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (value == null)
            {
                try
                {
                    throw new ArgumentNullException(propertyName + " can not be null.");
                }
                catch (ArgumentNullException argumentNullException)
                {
                   Logger.LogException(argumentNullException, sourceFilePath, memberName, sourceLineNumber);
                }
            }
        }

        public static void CheckStringNullOrEmpty(string value, string propertyName,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(propertyName + " can not be null or empty.");
            }
        }

        public static void CheckStringNullOrWhiteSpace(string value, string propertyName,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(propertyName + " can not be null or white space.");
            }
        }

        public static void CheckCharIsNotLetter(char value, string propertyName,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!char.IsLetter(value))
            {
                throw new ArgumentException(propertyName + " must be letter.");
            }
        }

        private static void GetMethodClass(out String className, out String methodName,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var stackTrace = new StackTrace();
            methodName = stackTrace.GetFrame(2).GetMethod().Name;
            className = stackTrace.GetFrame(2).GetType().Name;
        }       
    }
}
