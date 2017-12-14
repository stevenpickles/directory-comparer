using System;
using System.Collections.Generic;
using System.IO;

namespace DirectoryComparer
{
    public static class PathList
    {
        /// <summary>
        ///     Gets recursive path list with paths prefixed paths.
        /// </summary>
        ///
        /// <param name="path">
        ///     The starting path.
        ///     </param>
        ///
        /// <returns>
        ///     The recursive path list.
        /// </returns>
        public static List<string> GetRecursivePathList( string path )
        {
            return GetRecursivePathList( path , "" );
        }


        /// <summary>
        ///     Gets recursive path list with paths prefixed paths.
        /// </summary>
        ///
        /// <param name="path">
        ///     The starting path.
        ///     </param>
        /// <param name="prefix">
        ///     The prefix to prepend filenames and subdirectories.
        ///     </param>
        ///
        /// <returns>
        ///     The recursive path list.
        /// </returns>
        private static List<string> GetRecursivePathList( string path , string prefix )
        {
            /* special case -- basePath is a nonexistant directory */
            if ( !Directory.Exists( path ) )
            {
                return new List<string>();
            }

            List<string> pathList = new List<string>();

            /* add all local directory filenames to the path list */
            List<string> filenameList = new List<string>( Directory.GetFiles( path ) );
            foreach ( string filename in filenameList )
            {
                string filenameWithPrefix = prefix + Path.GetFileName( filename );

                pathList.Add( filenameWithPrefix );
            }

            /* recursively add all subdirectories (and subdirectory filenames) to the path list */
            List<string> subdirectoryList = new List<string>( Directory.GetDirectories( path ) );
            foreach ( string subdirectory in subdirectoryList )
            {
                /* generate the subdirectory name with the prefix */
                string subdirectoryFullPath = Path.GetFullPath( subdirectory );
                string subdirectoryFullPathAsFilename = subdirectoryFullPath.TrimEnd( Path.DirectorySeparatorChar );
                string subdirectoryName = Path.GetFileName( subdirectoryFullPath );
                string subdirectoryNameWithPrefix = prefix + subdirectoryName + Path.DirectorySeparatorChar;

                pathList.Add( subdirectoryNameWithPrefix );

                /* go to any subdirectories */
                List<string> subdirectoryPathList = PathList.GetRecursivePathList( subdirectory , subdirectoryNameWithPrefix );

                pathList.AddRange( subdirectoryPathList );
            }

            return pathList;
        }
    }
}
