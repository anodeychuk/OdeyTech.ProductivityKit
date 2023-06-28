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
using OdeyTech.ProductivityKit.Extension;

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
        /// Validates the provided file path to ensure it adheres to the system's file path conventions.
        /// </summary>
        /// <param name="filePath">The absolute path of the file to be validated, including the file name and its extension.</param>
        /// <returns>True if the file path is valid and does not contain any illegal characters, otherwise false.</returns>
        public static bool IsValidFilePath(string filePath)
        {
            if (filePath.IsNullOrEmpty() || filePath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
            {
                return false;
            }

            try
            {
                var _ = new FileInfo(filePath);
                return true;
            }
            catch (NotSupportedException)
            {
                // The filePath contains a colon (:) in the middle of the string, which is not supported.
                return false;
            }
        }

        /// <summary>
        /// Creates a directory at the specified directory path if it does not already exist.
        /// </summary>
        /// <param name="dirPath">The absolute path where the directory should be created, including the directory name.</param>
        /// <exception cref="DirectoryNotFoundException">Thrown when the provided directory path is not valid or contains illegal characters.</exception>
        /// <exception cref="IOException">Thrown when an error occurs while creating the directory.</exception>
        public static void CreateDirectoryIfNotExists(string dirPath)
        {
            try
            {
                if (!IsValidFilePath(dirPath))
                {
                    throw new DirectoryNotFoundException($"The provided directory path is not valid or contains illegal characters: {dirPath}");
                }

                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
            }
            catch (Exception ex)
            {
                throw new IOException($"An error occurred while trying to create the directory at {dirPath}.", ex);
            }
        }

        /// <summary>
        /// Checks whether a file exists at the specified file path.
        /// </summary>
        /// <param name="filePath">The absolute path of the file to check, including the file name and its extension.</param>
        /// <exception cref="DirectoryNotFoundException">Thrown when the provided file path is not valid or contains illegal characters.</exception>
        /// <exception cref="FileNotFoundException">Thrown when no file is found at the provided file path.</exception>
        public static void CheckFileExists(string filePath)
        {
            if (!IsValidFilePath(filePath))
            {
                throw new DirectoryNotFoundException($"The provided file path is not valid or contains illegal characters: {filePath}");
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"No file was found at the provided file path: {filePath}");
            }
        }

        /// <summary>
        /// Reads the content of a file located at the specified file path and returns it as a string.
        /// </summary>
        /// <param name="filePath">The absolute path of the file to be read. This should include the file name and its extension.</param>
        /// <returns>A string containing the content of the file.</returns>
        /// <exception cref="ArgumentException">Thrown when the provided file path is not valid or contains illegal characters.</exception>
        /// <exception cref="FileNotFoundException">Thrown when no file is found at the provided file path.</exception>
        /// <exception cref="IOException">Thrown when an error occurs while reading the file.</exception>
        public static string ReadFile(string filePath)
        {
            try
            {
                if (!IsValidFilePath(filePath))
                {
                    throw new ArgumentException($"The provided file path is not valid: {filePath}");
                }

                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"The file at {filePath} could not be found.");
                }

                return File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                throw new IOException($"An error occurred while trying to read the file at {filePath}.", ex);
            }
        }

        /// <summary>
        /// Saves the content to a file at the specified file path.
        /// </summary>
        /// <param name="documentPath">The file path.</param>
        /// <param name="value">The content to save.</param>
        /// <exception cref="IOException">Thrown when an error occurs while saving the file.</exception>
        public static void SaveFile(string documentPath, string value)
        {
            try
            {
                var dir = Path.GetDirectoryName(documentPath);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                File.WriteAllText(documentPath, value, Encoding.Unicode);
            }
            catch (Exception ex)
            {
                throw new IOException($"An error occurred while trying to save the file at {documentPath}.", ex);
            }
        }

        /// <summary>
        /// Replaces invalid characters in a filename with a specified substitution string.
        /// </summary>
        /// <param name="filename">The filename to process.</param>
        /// <param name="substitutionStr">The string to replace invalid characters with.</param>
        /// <returns>The processed filename with invalid characters replaced.</returns>
        public static string ReplaceInvalidChars(string filename, string substitutionStr)
            => string.Join(substitutionStr, filename.Split(Path.GetInvalidFileNameChars()));

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
