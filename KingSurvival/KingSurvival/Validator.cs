namespace KingSurvival
{
    using System;

    /// <summary>
    /// Static class used to validate all kinds of data and throwing exceptions if needed.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Checks if value is null.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="propertyName">The property name to show if an exception is thrown.</param>
        public static void CheckValueIsNull(object value, string propertyName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(propertyName + " can not be null.");
            }
        }

        /// <summary>
        /// Checks if value is null or empty.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="propertyName">The property name to show if an exception is thrown.</param>
        public static void CheckStringNullOrEmpty(string value, string propertyName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(propertyName + " can not be null or empty.");
            }
        }

        /// <summary>
        /// Checks if value is null or white space.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="propertyName">The property name to show if an exception is thrown.</param>
        public static void CheckStringNullOrWhiteSpace(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(propertyName + " can not be null or white space.");
            }
        }

        /// <summary>
        /// Checks if value is not letter.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="propertyName">The property name to show if an exception is thrown.</param>
        public static void CheckCharIsNotLetter(char value, string propertyName)
        {
            if (!char.IsLetter(value))
            {
                throw new ArgumentException(propertyName + " must be letter.");
            }
        }
    }
}
