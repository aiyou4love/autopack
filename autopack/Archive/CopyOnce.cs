using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace autopack
{
    [Serializable]
    public class CopyOnce
    {
        void runLower(string nDirectory)
        {
            DirectoryInfo directoryInfo_ = new DirectoryInfo(nDirectory);
            foreach (FileInfo fileInfo_ in directoryInfo_.GetFiles())
            {
                if (fileInfo_.Name != fileInfo_.Name.ToLower())
                {
                    string path_ = Path.Combine(nDirectory, fileInfo_.Name.ToLower());
                    fileInfo_.MoveTo(path_);
                }
            }
            foreach (DirectoryInfo suDirectory_ in directoryInfo_.GetDirectories())
            {
                runLower(suDirectory_.FullName);
            }
            Directory.Move(nDirectory, directoryInfo_.Name.ToLower());
        }

        public void runLower(Bundle nBundle)
        {
            if (!(nBundle.mDirectorys.ContainsKey(mDestDirectory)))
            {
                Console.WriteLine("mDirectorys key{0}", mDestDirectory);
                Console.ReadKey(true);
                return;
            }
            string destDirectory_ = nBundle.mDirectorys[mDestDirectory];
            this.runLower(destDirectory_);
        }

        public void runModify(Bundle nBundle, BundleInfo nBundleInfo, string nDirectory)
        {
            if (!(nBundle.mDirectorys.ContainsKey(mSourceDirectory)))
            {
                Console.WriteLine("mDirectorys key{0}", mSourceDirectory);
                Console.ReadKey(true);
                return;
            }
            string sourceDirectory_ = nBundle.mDirectorys[mSourceDirectory];

            foreach (CopyDirectory i in mCopyDirectorys)
            {
                i.runModify(sourceDirectory_, nBundleInfo, nDirectory);
            }
            foreach (CopyFile i in mCopyFiles)
            {
                i.runModify(sourceDirectory_, nBundleInfo, nDirectory);
            }
        }

        public void runMd5(Bundle nBundle, BundleInfo nBundleInfo)
        {
            if (!(nBundle.mDirectorys.ContainsKey(mSourceDirectory)))
            {
                Console.WriteLine("mDirectorys key{0}", mSourceDirectory);
                Console.ReadKey(true);
                return;
            }
            string sourceDirectory_ = nBundle.mDirectorys[mSourceDirectory];

            foreach (CopyDirectory i in mCopyDirectorys)
            {
                i.runMd5(sourceDirectory_, nBundleInfo);
            }
            foreach (CopyFile i in mCopyFiles)
            {
                i.runMd5(sourceDirectory_, nBundleInfo);
            }
        }

        public void runCopy(Bundle nBundle)
        {
            if (!(nBundle.mDirectorys.ContainsKey(mDestDirectory)))
            {
                Console.WriteLine("mDirectorys key{0}", mDestDirectory);
                Console.ReadKey(true);
                return;
            }
            string destDirectory_ = nBundle.mDirectorys[mDestDirectory];

            if (!(nBundle.mDirectorys.ContainsKey(mSourceDirectory)))
            {
                Console.WriteLine("mDirectorys key{0}", mSourceDirectory);
                Console.ReadKey(true);
                return;
            }
            string sourceDirectory_ = nBundle.mDirectorys[mSourceDirectory];

            foreach (CopyDirectory i in mCopyDirectorys)
            {
                i.runCopy(sourceDirectory_, destDirectory_);
            }
            foreach (CopyFile i in mCopyFiles)
            {
                i.runCopy(sourceDirectory_, destDirectory_);
            }
        }

        public List<CopyDirectory> mCopyDirectorys { get; set; }

        public List<CopyFile> mCopyFiles { get; set; }

        public string mDestDirectory { get; set; }

        public string mSourceDirectory { get; set; }
    }
}
