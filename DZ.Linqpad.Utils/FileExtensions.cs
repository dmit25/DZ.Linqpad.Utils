using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using JetBrains.Annotations;

namespace DZ.Linqpad.Utils
{
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public static class FileExtensions
    {
        /// <summary>
        /// extract filename and append suffix to it
        /// </summary>
        public static string WrapName(this string filename, string suffix)
        {
            return Path.GetFileNameWithoutExtension(filename) + suffix;
        }

        /// <summary>
        /// extract filename and append suffix to it
        /// </summary>
        public static string AddSuffix(this string filename, string suffix)
        {
            return Path.Combine(
                Path.GetDirectoryName(filename),
                Path.GetFileNameWithoutExtension(filename) + suffix + Path.GetExtension(filename));
        }

        /// <summary>
        /// Read text from<paramref name="filename"/>
        /// </summary>
        public static string ReadText(this string filename)
        {
            return File.ReadAllText(filename);
        }

        /// <summary>
        /// Reads all text from <paramref name="filename"/> or fails with <paramref name="failMessage"/>
        /// </summary>
        public static string TryReadText(this string filename, string failMessage = null)
        {
            if (filename.IsEmptyOrNull() || !filename.Exists())
            {
                throw new FileNotFoundException(failMessage ?? "File wasn't found [{0}]".FormatWith(filename));
            }
            return filename.ReadText();
        }

        /// <summary>
        /// Tries to read path from console and returns its path if it exists, otherwise fails
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string TryReadFilePathFromConsole(this string message)
        {
            Console.WriteLine(message);
            var path = Console.ReadLine();
            if (path.IsEmptyOrNull() || !path.Exists())
            {
                throw new FileNotFoundException("File wasn't found [{0}]".FormatWith(path ?? "NULL"));
            }
            return path;
        }

        /// <summary>
        /// Read text with encoding <paramref name="encoding"/> from <paramref name="filename"/>
        /// </summary>
        public static string ReadText(this string filename, Encoding encoding)
        {
            return File.ReadAllText(filename, encoding);
        }

        /// <summary>
        /// read lines from <paramref name="filename"/>
        /// </summary>
        public static IEnumerable<string> ReadLines(this string filename)
        {
            return File.ReadLines(filename);
        }
        /// <summary>
        /// Write text info file
        /// </summary>
        public static void WriteText(this string filename, string content)
        {
            File.WriteAllText(filename, content);
        }

        public static void WriteLines(this string filename, IEnumerable<string> content)
        {
            File.WriteAllLines(filename, content);
        }

        public static void WriteTo(this IEnumerable<string> content, string filename)
        {
            File.WriteAllLines(filename, content);
        }

        public static void WriteTo(this string content, string filename)
        {
            File.WriteAllText(filename, content);
        }

        public static bool Exists(this string filename)
        {
            return File.Exists(filename);
        }

        public static bool DirExists(this string path)
        {
            return Directory.Exists(path);
        }

        public static List<string> FilesList(this string directoryName)
        {
            return Directory.EnumerateFiles(directoryName).ToList();
        }

        public static List<string> AllFilesList(this string directoryName)
        {
            return Directory.EnumerateFiles(directoryName, "*", SearchOption.AllDirectories).ToList();
        }

        public static string FileName(this string filename)
        {
            return Path.GetFileNameWithoutExtension(filename);
        }

        public static void Delete(this string filename)
        {
            File.Delete(filename);
        }

        public static void DeleteDirectory(this string path)
        {
            Directory.Delete(path);
        }

        public static string NewDirectory(this string directory)
        {
            Directory.CreateDirectory(directory);
            return directory;
        }

        public static string DirectoryName(this string path)
        {
            return Path.GetDirectoryName(path);
        }

        public static string ReadFromConsole(this string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public static void ToConsole(this object obj)
        {
            Console.WriteLine(obj);
        }

        public static string CombinePath(this string left, string right) { return Path.Combine(left, right); }
    }
}