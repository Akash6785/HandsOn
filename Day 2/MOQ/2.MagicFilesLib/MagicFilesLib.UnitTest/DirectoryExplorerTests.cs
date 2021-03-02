using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MagicFilesLib.UnitTest
{
    [TestFixture]
    public class DirectoryExplorerTests
    {
        private Mock<IDirectoryExplorer> directoryExplorer;
        private readonly string file1 = "file.txt";
        private readonly string file2 = "file2.txt";

        [OneTimeSetUp]
        public void Init()
        {
            directoryExplorer = new Mock<IDirectoryExplorer>();
            directoryExplorer.Setup(q => q.GetFiles(It.IsAny<string>())).Returns(() => new List<string> { file1, file2 });
        }

        [Test]
        [TestCase("Pizza")]
        [TestCase("Dominos")]
        public void GetFilesTest(string input)
        {
            var files = directoryExplorer.Object.GetFiles(input);

            Assert.IsNotNull(files);
            Assert.AreEqual(2, files.Count);
            Assert.That(files, Contains.Item(file2));
            Assert.AreEqual(true, files.Contains(file1));
        }
    }
}
