namespace KingSurvival
{
    using System;

    public static class Validator
    {
        public static void CheckValueIsNull(object value, string propertyName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(propertyName + " can not be null.");
            }
        }

        public static void CheckStringNullOrEmpty(string value, string propertyName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(propertyName + " can not be null or empty.");
            }
        }

        public static void CheckStringNullOrWhiteSpace(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(propertyName + " can not be null or white space.");
            }
        }

        public static void CheckCharIsNotLetter(char value, string propertyName)
        {
            if (!char.IsLetter(value))
            {
                throw new ArgumentException(propertyName + " must be letter.");
            }
        }
    }
}
