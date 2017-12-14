using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DirectoryComparer.Tests
{
    [TestClass]
    public class PathListTests
    {
        [TestMethod]
        public void Test_PathList_WhenGettingPathListOfNonexistingDirectory_ThenEmptyListIsReturned()
        {
            List<string> pathList = PathList.GetRecursivePathList( "directoryDoesNotExist" );
            Assert.AreEqual( 0 , pathList.Count );
        }
    }
}
