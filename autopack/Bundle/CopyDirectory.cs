using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autopack
{
    [Serializable]
    public class CopyDirectory
    {
        void copyDirectory(string nSource, string nDest)
        {
            if (!Directory.Exists(nDest))
            {
                Directory.CreateDirectory(nDest);
            }
            DirectoryInfo directoryInfo_ = new DirectoryInfo(nSource);
            foreach (FileInfo fileInfo_ in directoryInfo_.GetFiles())
            {
                if (mWithouts.Contains(fileInfo_.Extension))
                {
                    continue;
                }
                File.Copy(fileInfo_.FullName, Path.Combine(nDest, fileInfo_.Name));
            }
            foreach (DirectoryInfo suDirectoryInfo_ in directoryInfo_.GetDirectories())
            {
                copyDirectory(suDirectoryInfo_.FullName, Path.Combine(nDest, suDirectoryInfo_.Name));
            }
        }

        public void runCopy(string nSourceDirectory, string nDestDirectory)
        {
            copyDirectory(Path.Combine(nSourceDirectory, mSourceDirectory),
                Path.Combine(nDestDirectory, mDestDirectory));
        }

        public string mSourceDirectory { get; set; }

        public string mDestDirectory { get; set; }

        public HashSet<string> mWithouts { get; set; }
    }
}
