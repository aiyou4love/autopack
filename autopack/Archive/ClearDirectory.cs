using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace autopack
{
    [Serializable]
    public class ClearDirectory
    {
        void runDelete(string nDirectory)
        {
            if (!Directory.Exists(nDirectory))
            {
                return;
            }
            DirectoryInfo directoryInfo_ = new DirectoryInfo(nDirectory);
            foreach (FileInfo fileInfo_ in directoryInfo_.GetFiles())
            {
                fileInfo_.Attributes = fileInfo_.Attributes & ~(FileAttributes.Archive | FileAttributes.ReadOnly | FileAttributes.Hidden);
                fileInfo_.Delete();
            }
            foreach (DirectoryInfo suDirectoryInfo_ in directoryInfo_.GetDirectories())
            {
                runDelete(suDirectoryInfo_.FullName);
            }
            directoryInfo_.Attributes = directoryInfo_.Attributes & ~(FileAttributes.Archive | FileAttributes.ReadOnly | FileAttributes.Hidden);
            directoryInfo_.Delete();
        }

        void runClear(string nDirectory)
        {
            if (!Directory.Exists(nDirectory))
            {
                return;
            }
            DirectoryInfo directoryInfo_ = new DirectoryInfo(nDirectory);
            foreach (FileInfo fileInfo_ in directoryInfo_.GetFiles())
            {
                fileInfo_.Attributes = fileInfo_.Attributes & ~(FileAttributes.Archive | FileAttributes.ReadOnly | FileAttributes.Hidden);
                fileInfo_.Delete();
            }
            foreach (DirectoryInfo suDirectoryInfo_ in directoryInfo_.GetDirectories())
            {
                runDelete(suDirectoryInfo_.FullName);
            }
        }

        public void runClear(Bundle nBundle)
        {
            foreach (string i in mClearDirectorys)
            {
                runClear(i);
            }
        }

        public List<string> mClearDirectorys { get; set; }
    }
}
