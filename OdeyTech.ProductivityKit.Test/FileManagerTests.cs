// --------------------------------------------------------------------------
// <copyright file="FileManagerTests.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OdeyTech.ProductivityKit.Test
{
    [TestClass]
    public class FileManagerTests
    {
        private const string TestFileName = "testFile.txt";
        private const string TestDirectoryName = "testDirectory";
        private const string InvalidFileName = "Invalid\\Path:With*Illegal|Characters";
        private const string TestFileContent = "Test content";
        private const string InvalidPath = "InvalidPathWithIllegalCharacters";
        private const string InvalidPathUnderscore = "Invalid_Path_With_Illegal_Characters";

        private string testFilePath;
        private string testDirectoryPath;

        [TestInitialize]
        public void InitializeTestPaths()
        {
            this.testFilePath = Path.Combine(FileManager.CurrentDirectory, TestFileName);
            this.testDirectoryPath = Path.Combine(FileManager.CurrentDirectory, TestDirectoryName);
        }

        [TestMethod]
        public void ShouldGetDirectoryByFilePathCorrectly()
        {
            var directory = FileManager.GetDirectoryByFilePath(this.testFilePath);
            Assert.AreEqual(FileManager.CurrentDirectory, directory);
        }

        [TestMethod]
        public void ShouldCheckFilePathValidityCorrectly()
        {
            Assert.IsTrue(FileManager.IsValidFilePath(this.testFilePath));
            Assert.IsFalse(FileManager.IsValidFilePath(InvalidFileName));
        }

        [TestMethod]
        public void ShouldCreateDirectoryIfNotExists()
        {
            FileManager.CreateDirectoryIfNotExists(this.testDirectoryPath);
            Assert.IsTrue(Directory.Exists(this.testDirectoryPath));
        }

        [TestMethod]
        public void ShouldCheckFileExistsCorrectly()
        {
            File.Create(this.testFilePath).Close();
            FileManager.CheckFileExists(this.testFilePath);
            Assert.IsTrue(File.Exists(this.testFilePath));
        }

        [TestMethod]
        public void ShouldReadFileCorrectly()
        {
            File.WriteAllText(this.testFilePath, TestFileContent);
            var content = FileManager.ReadFile(this.testFilePath);
            Assert.AreEqual(TestFileContent, content);
        }

        [TestMethod]
        public void ShouldSaveFileCorrectly()
        {
            FileManager.SaveFile(this.testFilePath, TestFileContent);
            var content = File.ReadAllText(this.testFilePath);
            Assert.AreEqual(TestFileContent, content);
        }

        [TestMethod]
        public void ShouldReplaceInvalidCharsCorrectly()
        {
            var validFilename = FileManager.ReplaceInvalidChars(InvalidFileName, "_");
            Assert.AreEqual(InvalidPathUnderscore, validFilename);
        }

        [TestMethod]
        public void ShouldRemoveInvalidCharsCorrectly()
        {
            var validFilename = FileManager.RemoveInvalidChars(InvalidFileName);
            Assert.AreEqual(InvalidPath, validFilename);
        }

        [TestMethod]
        public void ShouldGetApplicationFolderCorrectly()
        {
            var applicationFolder = FileManager.GetApplicationFolder();
            Assert.AreEqual(GetExecutingAssemblyDirectory(), applicationFolder);
        }

        [TestCleanup]
        public void CleanupTestPaths()
        {
            if (File.Exists(this.testFilePath))
            {
                File.Delete(this.testFilePath);
            }

            if (Directory.Exists(this.testDirectoryPath))
            {
                Directory.Delete(this.testDirectoryPath);
            }
        }

        private string GetExecutingAssemblyDirectory()
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }
    }
}
