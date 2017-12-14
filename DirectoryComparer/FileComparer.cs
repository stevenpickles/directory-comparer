using System;
using System.IO;

namespace DirectoryComparer
{
    public class FileComparer
    {
        public bool IsDifferent
        {
            get
            {
                if ( IsSizeMismatch ) { return true; }
                if ( IsHashMismatch ) { return true; }
                if ( IsLocationMismatch ) { return true; }

                return false;
            }
        }


        public bool IsSizeMismatch
        {
            get
            {
                return ( _a.Length != _b.Length );
            }
        }


        public bool IsHashMismatch
        {
            get
            {
                return ( _hashA.HashString != _hashB.HashString );
            }
        }


        public bool IsLocationMismatch
        {
            get
            {
                return false;
            }
        }

        protected FileInfo _a;
        protected FileInfo _b;

        protected FileHash _hashA;
        protected FileHash _hashB;


        public FileComparer( string a , string b )
        {
            _a = new FileInfo( a );
            _b = new FileInfo( b );

            _hashA = new FileHash( a );
            _hashB = new FileHash( b );
        }
    }
}
