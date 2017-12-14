using System;
using System.Security.Cryptography;
using System.Diagnostics;
using System.IO;

namespace DirectoryComparer
{
    public class FileHash
    {
        #region Private/Protected Members and Public Properties

        #region Hash String

        /// <summary>
        ///     Local hash string.
        /// </summary>
        private string _hashString;


        /// <summary>
        ///     Gets the hash string.
        /// </summary>
        ///
        /// <value>
        ///     The hash string.
        /// </value>
        public string HashString { get { return _hashString; } }

        #endregion


        #region Time Keeping Statistics

        /// <summary>
        ///     Local stopwatch.
        /// </summary>
        private Stopwatch _stopwatch;


        /// <summary>
        ///     Gets the elapsed hash time in milliseconds.
        /// </summary>
        ///
        /// <value>
        ///     The elapsed hash time in milliseconds.
        /// </value>
        public long ElapsedMilliseconds { get { return _stopwatch.ElapsedMilliseconds; } }

        #endregion

        #endregion


        #region Constructor

        /// <summary>
        ///     Constructor.
        /// </summary>
        ///
        /// <param name="path">
        ///     The path to file to be hashed.
        ///     </param>
        public FileHash( string path )
        {
            FileInfo fileInfo = new FileInfo( path );
            HashFile( fileInfo );
        }

        #endregion


        #region Protected Methods

        /// <summary>
        ///     Hashes a specified file using the previously configured hash algorithm. During the
        ///     hashing process a stopwatch records the amount of time taken by the operation.
        /// </summary>
        ///
        /// <param name="fileInfo">
        ///     Information describing the file to be hashed.
        ///     </param>
        protected void HashFile( FileInfo fileInfo )
        {
            if ( fileInfo.Exists )
            {
                _stopwatch.Reset();

                try
                {
                    using ( FileStream fileStream = fileInfo.OpenRead() )
                    {
                        SHA256Managed hasher = new SHA256Managed();

                        _stopwatch.Start();
                        byte[] hashBytes = hasher.ComputeHash( fileStream );
                        _stopwatch.Stop();

                        string hash = BitConverter.ToString( hashBytes );
                        hash = hash.Replace( "-" , "" );
                        hash = hash.ToLower();

                        _hashString = hash;
                    }
                }
                catch ( Exception e )
                {
                    _hashString = e.Message;
                    _stopwatch.Stop();
                }
            }
            else
            {
                _stopwatch.Reset();
                _hashString = "<file does not exist>";
            }
        }

        #endregion
    }
}
