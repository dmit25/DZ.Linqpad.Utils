using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace DZ.Linqpad.Utils
{
    public static class RegexExtensions
    {
        public static string ReplaceByRegex(this string text, [RegexPattern] string pattern, string replacement)
        {
            return Regex.Replace(text, pattern, replacement);
        }

        public static bool IsMatch(this string text, [RegexPattern] string pattern)
        {
            return Regex.IsMatch(text, pattern);
        }
    }
}