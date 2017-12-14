using System;
using System.Collections.Generic;
using System.IO;

namespace DirectoryComparer
{
    public static class PathList
    {
        public static List<string> GetRecursivePathList( string basePath )
        {
            /* special case -- basePath is a nonexisting directory */
            if ( !Directory.Exists( basePath ) )
            {
                return new List<string>();
            }

            return new List<string>();
        }
    }
}
