// --------------------------------------------------------------------------
// <copyright file="FileManager.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace OdeyTech.ProductivityKit
{
    /// <summary>
    /// Provides utility methods for working with files and directories.
    /// </summary>
    public static class FileManager
    {
        /// <summary>
        /// Gets the current application domain's base directory.
        /// </summary>
        public static string CurrentDirectory => AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// Retrieves the directory part of a given file path.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>The directory part of the file path.</returns>
        public static string GetDirectoryByFilePath(string filePath) => Path.GetDirectoryName(filePath);

        /// <summary>
        /// Determines whether a given file path is valid.
        /// </summary>
        /// <param name="filePath">The file path to validate.</param>
        /// <returns>True if the file path is valid, otherwise false.</returns>
        public static bool IsValidFilePath(string filePath)
        {
            if (filePath == null || filePath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
            {
                return false;
            }

            try
            {
                var tempFileInfo = new FileInfo(filePath);
                return true;
            }
            catch (NotSupportedException)
            {
                return false;
            }
        }

        /// <summary>
        /// Creates a directory if it does not already exist for the specified file path.
        /// </summary>
        /// <param name="fileName">The file path.</param>
        public static void CreateDirectoryIfNotExists(string fileName)
        {
            if (!IsValidFilePath(fileName))
            {
                throw new DirectoryNotFoundException();
            }

            var dir = GetDirectoryByFilePath(fileName);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }

        /// <summary>
        /// Validates whether a file exists at the specified file path.
        /// </summary>
        /// <param name="fileName">The file path.</param>
        public static void CheckFileExists(string fileName)
        {
            if (!IsValidFilePath(fileName))
            {
                throw new DirectoryNotFoundException();
            }

            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException();
            }
        }

        /// <summary>
        /// Reads the content of a file and returns it as a string.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>The content of the file as a string.</returns>
        public static string ReadFile(string filePath)
            => !(IsValidFilePath(filePath) && File.Exists(filePath))
                ? throw new FileNotFoundException()
                : File.ReadAllText(filePath);

        /// <summary>
        /// Saves the content to a file at the specified file path.
        /// </summary>
        /// <param name="documentPath">The file path.</param>
        /// <param name="value">The content to save.</param>
        public static void SaveFile(string documentPath, string value)
        {
            var dir = Path.GetDirectoryName(documentPath);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            File.WriteAllText(documentPath, value, Encoding.Unicode);
        }

        /// <summary>
        /// Replaces invalid characters in a filename with a specified substitution string.
        /// </summary>
        /// <param name="filename">The filename to process.</param>
        /// <param name="substitutionStr">The string to replace invalid characters with.</param>
        /// <returns>The processed filename with invalid characters replaced.</returns>
        public static string ReplaceInvalidChars(string filename, string substitutionStr) => string.Join(substitutionStr, filename.Split(Path.GetInvalidFileNameChars()));

        /// <summary>
        /// Removes invalid characters from a filename.
        /// </summary>
        /// <param name="filename">The filename to process.</param>
        /// <returns>The processed filename with invalid characters removed.</returns>
        public static string RemoveInvalidChars(string filename) => string.Concat(filename.Split(Path.GetInvalidFileNameChars()));

        /// <summary>
        /// Gets the folder containing the executing assembly.
        /// </summary>
        /// <returns>The folder containing the executing assembly.</returns>
        public static string GetApplicationFolder() => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}
