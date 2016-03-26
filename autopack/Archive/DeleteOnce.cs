using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace autopack
{
    [Serializable]
    public class DeleteOnce
    {
        void runDelete(string nDirectory)
        {
            DirectoryInfo directoryInfo_ = new DirectoryInfo(nDirectory);
            foreach (FileInfo fileInfo_ in directoryInfo_.GetFiles())
            {
                File.Delete(fileInfo_.FullName);
            }
            foreach (DirectoryInfo suDirectoryInfo_ in directoryInfo_.GetDirectories())
            {
                runDelete(suDirectoryInfo_.FullName);
            }
            Directory.Delete(nDirectory);
        }

        public void runDelete(Bundle nBundle)
        {
            if (!(nBundle.mDirectorys.ContainsKey(mDirectory)))
            {
                Console.WriteLine("mDirectorys key{0}", mDirectory);
                Console.ReadKey(true);
                return;
            }
            string directory_ = nBundle.mDirectorys[mDirectory];

            foreach (string i in mDeleteDirectorys)
            {
                runDelete(Path.Combine(directory_, i));
            }
            foreach (string i in mDeleteFiles)
            {
                if (File.Exists(Path.Combine(directory_, i)))
                {
                    File.Delete(Path.Combine(directory_, i));
                }
            }
        }

        public List<string> mDeleteDirectorys { get; set; }

        public List<string> mDeleteFiles { get; set; }

        public string mDirectory { get; set; }
    }
}
