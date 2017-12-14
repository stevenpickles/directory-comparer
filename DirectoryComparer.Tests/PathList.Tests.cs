using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DirectoryComparer.Tests
{
    [TestClass]
    public class PathListTests
    {
        protected const string rootPath = ".\\root\\";
        protected const string basePath = rootPath + "base\\";

        [TestMethod]
        public void Test_PathList_WhenGettingPathListOfNonexistingDirectory_ThenEmptyListIsReturned()
        {
            List<string> pathList = PathList.GetRecursivePathList( basePath + "directoryDoesNotExist\\" );
            Assert.AreEqual( 0 , pathList.Count );
        }

        [TestMethod]
        public void Test_PathList_WhenGettingPathListOfDirectory_ThenPathListIsReturned()
        {
            List<string> pathList = PathList.GetRecursivePathList( basePath );
            Assert.AreEqual( 6 , pathList.Count );
            Assert.AreEqual( "hello_world.txt" , pathList[ 0 ] );
            Assert.AreEqual( "key.dat" , pathList[ 1 ] );
            Assert.AreEqual( "some_folder\\" , pathList[ 2 ] );
            Assert.AreEqual( "some_folder\\some_file.txt" , pathList[ 3 ] );
            Assert.AreEqual( "some_folder\\nested_folder\\" , pathList[ 4 ] );
            Assert.AreEqual( "some_folder\\nested_folder\\leaf.txt" , pathList[ 5 ] );
        }
    }
}
