using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace autopack
{
    [Serializable]
    public class IfFile
    {
        public bool isExists(Bundle nBundle)
        {
            if (!(nBundle.mDirectorys.ContainsKey(mDirectory)))
            {
                Console.WriteLine("mDirectorys key:{0}", mDirectory);
                Console.ReadKey(true);
                return false;
            }
            string directory_ = nBundle.mDirectorys[mDirectory];
            foreach (string i in mIfDirectorys)
            {
                if (Directory.Exists(Path.Combine(directory_, i)))
                {
                    return true;
                }
            }
            foreach (string i in mIfFiles)
            {
                if (File.Exists(Path.Combine(directory_, i)))
                {
                    return true;
                }
            }
            return false;
        }

        public List<string> mIfDirectorys { get; set; }

        public List<string> mIfFiles { get; set; }

        public string mDirectory { get; set; }
    }
}
