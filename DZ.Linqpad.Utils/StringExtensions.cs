using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using JetBrains.Annotations;

namespace DZ.Linqpad.Utils
{
    /// <summary>
    /// Расширения для string
    /// </summary>
    [PublicAPI]
    public static class StringExtensions
    {
        /// <summary>
        /// Получение символа или значения по умолчания по заданному индексу в строке
        /// </summary>
        /// <param name="str">строка</param>
        /// <param name="charIndex">индекс символа</param>
        /// <returns>символ или значение по умолчанию</returns>

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char CharOrDefault([NotNull]this string str, int charIndex)
        {
            return (charIndex >= 0) && (charIndex < str.Length) ? str[charIndex] : default(char);
        }

        /// <summary>
        /// Получение заданного количества последних слов
        /// </summary>
        /// <param name="text">текст</param>
        /// <param name="count">количество слов</param>
        /// <returns>последние слова</returns>

        [NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetLastWords([NotNull]this string text, int count)
        {
            var result = new StringBuilder();
            var startIndex = text.Length - 1;
            for (var i = 0; i < count; ++i)
            {
                var word = GetLastWord(text, startIndex);
                startIndex = word.Item1 - 1;
                result.Insert(0, word.Item2);
                result.Insert(0, " ");
            }
            return result.ToString().TrimStart();
        }

        /// <summary>
        /// Получение слов из текста
        /// </summary>
        /// <param name="text">текст</param>
        /// <returns>слова</returns>
        [NotNull]

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string[] GetWords([NotNull]this string text)
        {
            return text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Gets trimmed and lowered string
        /// </summary>
        /// <param name="str">строка</param>
        /// <returns></returns>
        [CanBeNull]

        [ContractAnnotation("null=>null;notnull=>notnull")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string TrimAndLower([CanBeNull]this string str)
        {
            if (str == null)
            {
                return null;
            }
            return str.Trim().ToLowerInvariant();
        }


        /// <summary>
        /// Gets trimmed and uppered string
        /// </summary>
        /// <param name="str">строка</param>
        /// <returns></returns>
        [CanBeNull]
        [ContractAnnotation("null=>null;notnull=>notnull")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static public string TrimAndUpper([CanBeNull]this string str)
        {
            if (str == null)
            {
                return null;
            }

            return str.Trim().ToUpperInvariant();
        }

        /// <summary>
        /// Проверка, что в заданной строке нет текста (только пробелы)
        /// </summary>
        /// <param name="str">строка</param>
        /// <returns>результат проверки</returns>

        [ContractAnnotation("null=>true;notnull=>false")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEmptyText(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// Проверка, что в заданной строке нет текста (только пробелы)
        /// </summary>
        /// <param name="str">строка</param>
        /// <returns>результат проверки</returns>

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEmpty([NotNull]this string str)
        {
            return str.Length == 0;
        }

        /// <summary>
        /// Checks that string is null or empty
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>

        [ContractAnnotation("null=>true;")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEmptyOrNull([CanBeNull]this string text)
        {
            return string.IsNullOrEmpty(text);
        }

        /// <summary>
        /// Returns text wrapped into round brackets
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [NotNull]

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string InRoundBrackets([NotNull]this string text)
        {
            return '(' + text + ')';
        }

        /// <summary>
        /// Returs formatted string
        /// </summary>
        /// <param name="formatText"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        [NotNull]
        [StringFormatMethod("formatText")]
        public static string FormatWith([NotNull]this string formatText, [NotNull] params object[] args)
        {
            return string.Format(formatText, args);
        }

        /// <summary>
        /// Returs formatted string
        /// </summary>
        /// <param name="formatText"></param>
        /// <param name="arg"></param>
        /// <returns></returns>
        [NotNull]
        [StringFormatMethod("formatText")]
        public static string FormatWith<T>([NotNull]this string formatText, [NotNull] T arg)
        {
            return string.Format(formatText, arg);
        }

        /// <summary>
        /// Returs formatted string
        /// </summary>
        /// <param name="formatText"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        [NotNull]
        [StringFormatMethod("formatText")]
        public static string FormatWith<T1, T2>([NotNull]this string formatText, [NotNull] T1 arg1, [NotNull] T2 arg2)
        {
            return string.Format(formatText, arg1, arg2);
        }

        /// <summary>
        /// Returs formatted string
        /// </summary>
        /// <param name="formatText"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <returns></returns>
        [NotNull]
        [StringFormatMethod("formatText")]
        public static string FormatWith<T1, T2, T3>([NotNull]this string formatText, [NotNull] T1 arg1, [NotNull] T2 arg2, [NotNull] T3 arg3)
        {
            return string.Format(formatText, arg1, arg2, arg3);
        }

        /// <summary>
        /// Splits string by defined symbol and removes empty entries
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ch"></param>
        /// <returns></returns>

        [NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string[] SplitBy([NotNull]this string value, char ch)
        {
            return value.Split(new[] { ch }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Changes case of string to lower one
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>

        [CanBeNull]
        [ContractAnnotation("notnull=>notnull;null=>null")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToLowerStr([CanBeNull]this string value)
        {
            return value != null ? value.ToLower(CultureInfo.InvariantCulture) : null;
        }

        /// <summary>
        /// Joins collection of values using defined string as separator
        /// </summary>
        /// <param name="values"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        [NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string JoinBy([NotNull]this IEnumerable<string> values, [NotNull] string separator)
        {
            return string.Join(separator, values.Select(_ => _.Trim()).ToArray());
        }

        /// <summary>
        /// Aggregates collection of elements into string internally using stringbuilder
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static string AggregateString<T>(
            this IEnumerable<T> collection,
            Func<StringBuilder, T, StringBuilder> aggregator)
        {
            return collection.Aggregate(new StringBuilder(), aggregator).ToString();
        }

        /// <summary>
        /// Check if text is in lower case.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLower([NotNull]this string text)
        {
            //NOTE: Do not change to foreach (performance issues)
            for (var i = 0; i < text.Length; i++)
            {
                var c = text[i];
                if (char.IsLetter(c) && !char.IsLower(c))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Получение последнего слова
        /// </summary>
        /// <param name="text">текст</param>
        /// <param name="startIndex">стартовая позиция для поиска</param>
        /// <returns>последнее слово</returns>
        [NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Tuple<int, string> GetLastWord([NotNull]this string text, int startIndex)
        {
            var result = new StringBuilder();
            var endIndex = startIndex;
            for (var i = startIndex; i >= 0; --i)
            {
                if (char.IsLetterOrDigit(text[i]) || ((result.Length > 0) && (text[i] == '-')))
                {
                    endIndex = i;
                    result.Insert(0, text[i]);
                }
                else if (result.Length > 0)
                    break;
            }
            return new Tuple<int, string>(endIndex, result.ToString());
        }

        /// <summary>
        /// Returns true if any character of input str in Upper case.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsAnyUpper(this string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsUpper(str[i]))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if character is from latin alphabet.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsLatin(this char c)
        {
            return c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z';
        }

        /// <summary>
        /// Checks if string do not use any non-latin characters.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsLatin(this string str)
        {
            bool metLatin = false;
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (char.IsLetter(c))
                {
                    if (c.IsLatin())
                    {
                        metLatin = true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return metLatin;
        }
    }
}
