using System;
using System.Text.RegularExpressions;

namespace Infraestructure.Core.Notifications
{
    public static class Assert
    {
        public static Notification Length(string text, int min, int max, string key, string val)
        {
            var length = text.Trim().Length;

            return (length < min || length > max)
                ? new Notification(key, val)
                : null;
        }

        public static Notification Matches(string pattern, string text, string key, string val)
        {
            var regex = new Regex(pattern);

            return (!regex.IsMatch(text))
                ? new Notification(key, val)
                : null;
        }

        public static Notification NotEmpty(string text, string key, string val)
        {
            return (string.IsNullOrWhiteSpace(text))
                ? new Notification(key, val)
                : null;
        }

        public static Notification IsNotNull(object obj, string key, string val)
        {
            return (obj == null)
                ? new Notification(key, val)
                : null;
        }

        public static Notification IsNull(object obj, string key, string val)
        {
            return (obj != null)
                ? new Notification(key, val)
                : null;
        }

        public static Notification IsTrue(bool obj, string key, string val)
        {
            return (!obj)
                ? new Notification(key, val)
                : null;
        }

        public static Notification AreEquals(string text, string match, string key, string val)
        {
            return (text != match)
                ? new Notification(key, val)
                : null;
        }

        public static Notification IsGreaterThan(int value1, int value2, string key, string val)
        {
            return (!(value1 > value2))
                ? new Notification(key, val)
                : null;
        }

        public static Notification IsGreaterThan(decimal value1, decimal value2, string key, string val)
        {
            return (!(value1 > value2))
                ? new Notification(key, val)
                : null;
        }

        public static Notification IsGreaterOrEqualThan(int value1, int value2, string key, string val)
        {
            return (!(value1 >= value2))
                ? new Notification(key, val)
                : null;
        }

        public static Notification IsGreaterOrEqualThan(decimal value1, decimal value2, string key, string val)
        {
            return (!(value1 >= value2))
                ? new Notification(key, val)
                : null;
        }

        public static Notification RegexMatch(string value, string regex, string key, string val)
        {
            return (!Regex.IsMatch(value, regex, RegexOptions.IgnoreCase))
                ? new Notification(key, val)
                : null;
        }

        public static Notification GuidIsNotEmpty(Guid value, string key, string val)
        {
            return (value == Guid.Empty)
                ? new Notification(key, val)
                : null;
        }

        public static Notification EmailIsValid(string email, string key, string val)
        {
            var emailRegex =
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

            return (!Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase))
                ? new Notification(key, val)
                : null;
        }

        public static Notification UrlIsValid(string url, string key, string val)
        {
            if (String.IsNullOrEmpty(url))
                return null;

            var regex = @"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$";

            return (!Regex.IsMatch(url, regex, RegexOptions.IgnoreCase))
                ? new Notification(key, val)
                : null;
        }
    }
}