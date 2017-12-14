using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DirectoryComparer.Tests
{
    [TestClass]
    public class FileHashTests
    {
        protected const string rootPath = ".\\root\\";
        protected const string basePath = rootPath + "base\\";

        [TestMethod]
        public void Test_FileHash_WhenFileIsHashed_ThenHashStringIsCorrect()
        {
            FileHash fileHash = new FileHash( basePath + "key.dat" );
            Assert.AreEqual( "045649c641c324b0a64e56e6147facaab986a4554a04bf82eb1d311804bd4bf9" , fileHash.HashString );
        }

        [TestMethod]
        public void Test_FileHash_WhenFileIsNotFound_ThenHashStringIsCorrect()
        {
            FileHash fileHash = new FileHash( basePath + "bogus.dat" );
            Assert.AreEqual( "<file does not exist>" , fileHash.HashString );
        }
    }
}
