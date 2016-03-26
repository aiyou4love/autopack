using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autopack
{
    [Serializable]
    public class CopyFile
    {
        public void runCopy(string nSourceDirectory, string nDestDirectory)
        {
            File.Copy(Path.Combine(nSourceDirectory, mSource),
                Path.Combine(nDestDirectory, mDest));
        }

        public string mSource { get; set; }

        public string mDest { get; set; }
    }
}
